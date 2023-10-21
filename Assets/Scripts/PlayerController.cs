using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    public bool IsAttacking { get; private set; } = false;

    public float moveSpeed = 1f;
    
    [Header("Combat")]
    [SerializeField] private int health = 1;
    [SerializeField] private int damage = 1;
    [SerializeField] private float attackOffset = 1f;

    // [Header("Dash")]
    // [SerializeField] private float dashSpeed = 4f;
    // [SerializeField] private float dashDuration = 0.2f;
    // [SerializeField] private float dashCooldown = 1f;
    // private float _originalMoveSpeed = 1f;
    // private bool _isDashing = false;
    
    private PlayerControls _playerControls;
    private Vector2 _movementInput;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Vector3 _lastMoveDirection;
    private TrailRenderer _trailRenderer;
    private LayerMask _enemyLayerMask;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
        _playerControls = new PlayerControls();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        // _trailRenderer = GetComponentInChildren<TrailRenderer>();
    }

    private void Start()
    {
        _enemyLayerMask = LayerMask.GetMask("Enemy");
        
        _lastMoveDirection = Vector3.down;
        _playerControls.Combat.Attack.performed += _ => Attack();
        _playerControls.Combat.Dash.performed += _ => UseActiveCard();
        // _originalMoveSpeed = moveSpeed;
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    { 
        AdjustPlayerDirection();
        Move();
    }

    private void PlayerInput()
    {
        _movementInput = _playerControls.Movement.Move.ReadValue<Vector2>().normalized;

        if (_movementInput.magnitude != 0)
        {
            _lastMoveDirection = _movementInput;
        }
        
        _animator.SetFloat("moveX", _movementInput.x);
        _animator.SetFloat("moveY", _movementInput.y);
    }

    private void Move()
    {
        _rigidbody.MovePosition(_rigidbody.position + _movementInput * (moveSpeed * Time.fixedDeltaTime));
    }
    
    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        CheckDeath();
    }

    private void CheckDeath()
    {
        if (health > 0) return;
        Die();
    }

    private void AdjustPlayerDirection()
    {
        if (_movementInput.x < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if (_movementInput.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
    }

    private void Attack()
    {
        if (IsAttacking) return;
        
        IsAttacking = true;
        _animator.SetTrigger("attack");
        Damage();
    }
    
    private void Damage()
    {
        var hit = Physics2D.Raycast(transform.position, _lastMoveDirection, attackOffset, _enemyLayerMask);
        if (hit.collider == null) return;
        var enemy = hit.collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
    }

    public void Dash()
    {
        _animator.SetBool("isDashing", true);
    }

    public void EndDash()
    {
        _animator.SetBool("isDashing", false);
    }

    // private IEnumerator EndDashRoutine()
    // {
    //     yield return new WaitForSeconds(dashDuration);
    //     moveSpeed = _originalMoveSpeed;
    //     _trailRenderer.emitting = false;
    //     yield return new WaitForSeconds(dashCooldown);
    //     _isDashing = false;
    // }

    private void UseActiveCard()
    {
        CardManager.Instance.UseActiveCard();
    }
    
    public Vector2 GetPosition() => transform.position;
    
    public void AnimationFinished()
    {
        IsAttacking = false;
    }

    private void Die()
    {
        // Play death animation
        Debug.Log("Player died");
        
        // Disable player controls
        _playerControls.Disable();
        
        // End game (stop game time for now)
        Time.timeScale = 0f;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        var position = transform.position;
        Gizmos.DrawLine(position, position + _lastMoveDirection * attackOffset);
    }
}

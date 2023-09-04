using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }

    public void AnimationFinished()
    {
        IsAttacking = false;
    }

    public bool IsAttacking { get; private set; } = false;

    [SerializeField] private float moveSpeed = 1f;
    private PlayerControls _playerControls;
    private Vector2 _movementInput;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

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
    }

    private void Start()
    {
        _playerControls.Combat.Attack.performed += _ => Attack();
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
        _movementInput = _playerControls.Movement.Move.ReadValue<Vector2>();
        
        _animator.SetFloat("moveX", _movementInput.x);
        _animator.SetFloat("moveY", _movementInput.y);
    }

    private void Move()
    {
        if (IsAttacking) return;
        _rigidbody.MovePosition(_rigidbody.position + _movementInput * (moveSpeed * Time.fixedDeltaTime));
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
        IsAttacking = true;
        _animator.SetTrigger("attack");
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private int health = 1;
    [SerializeField] private int damage = 1;
    [field: SerializeField] public float AttackRange { get; private set; } = 1f;
    [SerializeField] private float attackCooldown = 2f;
    private float lastAttackedTime;
    
    private Animator _animator;
    private LayerMask _playerLayerMask;
    private Vector3 _playerPosition;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _playerLayerMask = LayerMask.GetMask("Player");
        _animator.SetBool("isWalking", true);
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        CheckDeath();
    }
    
    private void CheckDeath()
    {
        if (health > 0) return;
        _animator.SetTrigger("die");
        Destroy(gameObject, 5f);
    }

    public void Attack(Vector3 direction)
    {
        _playerPosition = direction;
        
        if (Time.time < attackCooldown + lastAttackedTime) return;
        // Play attack animation
        Debug.Log("Attack animation is triggered!");
        _animator.SetTrigger("attack");
        lastAttackedTime = Time.time;
    }

    public void PerformAttackTrigger()
    {
        // Check if the player is within attack radius
        Debug.Log("PerformAttackTrigger is called!");
        var position = transform.position;
        var hit = Physics2D.Raycast(position, _playerPosition - position, AttackRange, _playerLayerMask);
        if (hit.collider == null) return;
        Debug.Log("A collider is found!");
        var player = hit.collider.GetComponent<PlayerController>();
        if (player != null)
        {
            Debug.Log("Player is hit!");
            player.TakeDamage(damage);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        var position = transform.position;
        Gizmos.DrawWireSphere(position, AttackRange);
        Gizmos.DrawLine(position, _playerPosition);
    }
}

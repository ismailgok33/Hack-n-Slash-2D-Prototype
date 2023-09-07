using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private int health = 1;
    [SerializeField] private int damage = 1;
    [SerializeField] private float attackOffset = 1f;
    [SerializeField] private float attackCooldown = 1f;
    
    private Animator _animator;
    private LayerMask _playerLayerMask;
    private Vector3 _playerDirection;

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
        _playerDirection = direction;
        
        if (Time.time < attackCooldown) return;
        // Play attack animation
        _animator.SetTrigger("attack");
        attackCooldown += Time.time;
    }

    public void PerformAttackTrigger()
    {
        // Check if the player is within attack radius
        var hit = Physics2D.Raycast(transform.position, _playerDirection, attackOffset, _playerLayerMask);
        if (hit.collider == null) return;
        var player = hit.collider.GetComponent<PlayerController>();
        if (player != null)
        {
            player.TakeDamage(damage);
        }
    }
}

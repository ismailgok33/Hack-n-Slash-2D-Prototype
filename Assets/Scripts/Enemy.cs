using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private int health = 1;
    [SerializeField] private int damage = 1;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
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

    public void Attack()
    {
        // Play attack animation
        
        // Check if the player is within attack radius
        
        // If so, deal damage to the player
    }
}

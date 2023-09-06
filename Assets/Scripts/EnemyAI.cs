using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private enum State
    {
        Chase,
        Attack,
        Dead
    }

    [SerializeField] private float attackRange = 3f;
    
    private State _state;
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        switch (_state)
        {
            case State.Chase:
                ChasePlayer();
                break;
            case State.Attack:
                AttackPlayer();
                break;
            case State.Dead:
                break;
            default:
                Debug.LogError("Wrong state in EnemyAI");
                break;
        }
        
    }

    // Chases the player
    private void ChasePlayer()
    {
        // TODO: Chase the player
        
        // Check if the player is within attack range
        if (Vector3.Distance(transform.position, PlayerController.Instance.GetPosition()) <= attackRange)
        {
            _state = State.Attack;
        }
    }
    
    // Attacks the player withing a certain range
    private void AttackPlayer()
    {
        _enemy.Attack();
        
        // Check if the player is outside of attack range
        if (Vector3.Distance(transform.position, PlayerController.Instance.GetPosition()) > attackRange)
        {
            _state = State.Chase;
        }
    }
    
}

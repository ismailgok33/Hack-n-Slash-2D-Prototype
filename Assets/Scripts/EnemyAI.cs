using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private enum State
    {
        Chase,
        Attack,
        Dead
    }

    [SerializeField] private float attackRange = 1f;
    
    private State _state;
    private Enemy _enemy;
    private NavMeshAgent _navMeshAgent;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
        _state = State.Chase;
        attackRange = _enemy.AttackRange;
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
        // Chase player
        _navMeshAgent.SetDestination(PlayerController.Instance.GetPosition());
        _navMeshAgent.isStopped = false;
        
        FlipSprite();
        
        // Check if the player is within attack range
        if (Vector2.Distance(transform.position, PlayerController.Instance.GetPosition()) <= attackRange)
        {
            _state = State.Attack;
        }
    }
    
    // Attacks the player withing a certain range
    private void AttackPlayer()
    {
        _navMeshAgent.isStopped = true;
        
        _enemy.Attack(PlayerController.Instance.GetPosition());
        
        // Check if the player is outside of attack range
        if (Vector3.Distance(transform.position, PlayerController.Instance.GetPosition()) > attackRange)
        {
            _state = State.Chase;
        }
    }
    
    private void FlipSprite()
    {
        var playerPosition = PlayerController.Instance.GetPosition();
        var isPlayerToTheRight = playerPosition.x > transform.position.x;
        transform.localScale = new Vector3(isPlayerToTheRight ? 1 : -1, 1, 1);
    }
}

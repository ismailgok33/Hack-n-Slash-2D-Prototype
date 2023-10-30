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
    private Enemy_2 enemy2;
    private NavMeshAgent _navMeshAgent;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        enemy2 = GetComponent<Enemy_2>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
        _state = State.Chase;
        attackRange = enemy2.AttackRange;
        enemy2.OnEnemyKilled += Enemy2OnOnEnemy2Killed;
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
                _navMeshAgent.isStopped = true;
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
        
        enemy2.Attack(PlayerController.Instance.GetPosition());
        
        // Check if the player is outside of attack range
        if (Vector3.Distance(transform.position, PlayerController.Instance.GetPosition()) > attackRange)
        {
            _state = State.Chase;
        }
    }
    
    private void Enemy2OnOnEnemy2Killed(object sender, EventArgs e)
    {
        _state = State.Dead;
    }
    
    private void FlipSprite()
    {
        var playerPosition = PlayerController.Instance.GetPosition();
        var isPlayerToTheRight = playerPosition.x > transform.position.x;
        transform.localScale = new Vector3(isPlayerToTheRight ? 1 : -1, 1, 1);
    }
}

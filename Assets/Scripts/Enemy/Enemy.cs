using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Entity
{
    [Header("Move info")]
    public float moveSpeed = 1.5f;
    private float defaultMoveSpeed;
    
    [Header("Attack info")]
    public float attackDistance = 2;
    public float attackCooldown;
    public float minAttackCooldown = 1;
    public float maxAttackCooldown= 2;
    [HideInInspector] public float lastTimeAttacked;
    
    private NavMeshAgent _navMeshAgent;
    public static event EventHandler OnEnemyDeath;
    public EnemyStateMachine stateMachine { get; private set; }
    // public EntityFX fx { get; private set; }
    [HideInInspector] public Player player;
    public string lastAnimBoolName {  get; private set; }
    protected override void Awake()
    {
        base.Awake();
        stateMachine = new EnemyStateMachine();

        defaultMoveSpeed = moveSpeed;
    }

    protected override void Start()
    {
        base.Start();
        
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
        player = PlayerManager.Instance.player;

        // fx = GetComponent<EntityFX>();
    }
    
    protected override void Update()
    {
        base.Update();

        stateMachine.CurrentState.Update();
    }
    
    public virtual void AssignLastAnimName(string animBoolName) => lastAnimBoolName = animBoolName;
    
    protected override void ReturnDefaultSpeed()
    {
        base.ReturnDefaultSpeed();

        moveSpeed = defaultMoveSpeed;
    }
    
    public virtual void AnimationFinishTrigger() => stateMachine.CurrentState.AnimationFinishTrigger();

    // public virtual Vector2 DistanceToPlayer() => player.transform.position - transform.position;
    public virtual float DistanceToPlayer() => Vector2.Distance(player.transform.position, transform.position);
    
    public virtual void ChasePlayer()
    {
        // Chase player
        _navMeshAgent.SetDestination(PlayerManager.Instance.player.transform.position);
        _navMeshAgent.isStopped = false;
        
        // FlipSprite();
        FlipSprite();
    }

    public virtual void StopChase()
    {
        _navMeshAgent.isStopped = true;
    }
    
    public void FlipSprite()
    {
        var playerPosition = PlayerManager.Instance.player.transform.position;
        var isPlayerToTheRight = playerPosition.x > transform.position.x;
        facingRight = isPlayerToTheRight;
        facingDir = facingRight ? 1 : -1;
        transform.localScale = new Vector3(isPlayerToTheRight ? 1 : -1, 1, 1);
    }

    public override void PositionAttackCheck(float xInput, float yInput)
    {
        attackCheck.localPosition = (player.transform.position - transform.position).normalized * 0.8f * new Vector2(facingRight ? 1 : -1, 1);
        facingDirection = (player.transform.position - transform.position).normalized;
        // attackCheck.localPosition = _navMeshAgent.destination.normalized * 0.8f;
    }

    public override void Die()
    {
        base.Die();
        
        OnEnemyDeath?.Invoke(this, EventArgs.Empty);
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
        
        // Debug.Log("AttackCheck gizmos are drown.");
    }
}

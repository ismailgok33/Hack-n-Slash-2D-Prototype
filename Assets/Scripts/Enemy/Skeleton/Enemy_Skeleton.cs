using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Skeleton : Enemy
{
    public SkeletonIdleState IdleState { get; private set; }
    public SkeletonMoveState MoveState { get; private set; }
    public SkeletonBattleState BattleState { get; private set; }
    public SkeletonAttackState AttackState { get; private set; }
    public SkeletonDeathState DeathState { get; private set; }
    
    protected override void Awake()
    {
        base.Awake();
        
        IdleState = new SkeletonIdleState(this, stateMachine, "Idle", this);
        MoveState = new SkeletonMoveState(this, stateMachine, "Move", this);
        BattleState = new SkeletonBattleState(this, stateMachine, "Move", this);
        AttackState = new SkeletonAttackState(this, stateMachine, "Attack", this);
        DeathState = new SkeletonDeathState(this, stateMachine, "Die", this);
    }

    protected override void Start()
    {
        base.Start();
        // stateMachine.Initialize(IdleState);
        stateMachine.Initialize(MoveState);
    }
    
    public override void Die()
    {
        base.Die();
        stateMachine.ChangeState(DeathState);
        Destroy(gameObject, 3f);
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
    }
}

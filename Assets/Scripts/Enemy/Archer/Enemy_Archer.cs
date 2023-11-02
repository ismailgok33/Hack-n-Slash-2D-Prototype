using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Archer : Enemy
{
    public ArcherIdleState IdleState { get; private set; }
    public ArcherMoveState MoveState { get; private set; }
    public ArcherBattleState BattleState { get; private set; }
    public ArcherAttackState AttackState { get; private set; }
    public ArcherDeathState DeathState { get; private set; }
    
    protected override void Awake()
    {
        base.Awake();
        
        IdleState = new ArcherIdleState(this, stateMachine, "Idle", this);
        MoveState = new ArcherMoveState(this, stateMachine, "Move", this);
        BattleState = new ArcherBattleState(this, stateMachine, "Move", this);
        AttackState = new ArcherAttackState(this, stateMachine, "Attack", this);
        DeathState = new ArcherDeathState(this, stateMachine, "Die", this);
    }

    protected override void Start()
    {
        base.Start();

        stateMachine.Initialize(MoveState);
    }
    
    public override void Die()
    {
        base.Die();
        stateMachine.ChangeState(DeathState);
        Destroy(gameObject, 3f);
    }
    
    public void ShootArrow()
    {
        Debug.Log("Archer shoots arrow");
    }
    
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
    }
}

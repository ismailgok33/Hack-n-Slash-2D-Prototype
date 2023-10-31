using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Goblin : Enemy
{
    public GoblinIdleState IdleState { get; private set; }
    public GoblinMoveState MoveState { get; private set; }
    public GoblinBattleState BattleState { get; private set; }
    public GoblinAttackState AttackState { get; private set; }
    public GoblinDeathState DeathState { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        
        IdleState = new GoblinIdleState(this, stateMachine, "Idle", this);
        MoveState = new GoblinMoveState(this, stateMachine, "Move", this);
        BattleState = new GoblinBattleState(this, stateMachine, "Move", this);
        AttackState = new GoblinAttackState(this, stateMachine, "Attack", this);
        DeathState = new GoblinDeathState(this, stateMachine, "Die", this);
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

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
    }

    // public override void PositionAttackCheck(float xInput, float yInput)
    // {
    //     attackCheck.localPosition = (player.transform.position - transform.position).normalized * 0.4f * new Vector2(facingRight ? 1 : -1, 1);
    //
    // }
}

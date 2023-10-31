using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinGroundedState : EnemyState
{
    protected Enemy_Goblin enemy;
    
    public GoblinGroundedState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, Enemy_Goblin enemy) : base(enemyBase, stateMachine, animBoolName)
    {
        this.enemy = enemy;
    }
    
    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }
}

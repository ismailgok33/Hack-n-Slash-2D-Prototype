using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinMoveState : GoblinGroundedState
{
    public GoblinMoveState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, Enemy_Goblin enemy) : base(enemyBase, stateMachine, animBoolName, enemy)
    {
    }
    
    public override void Enter()
    {
        base.Enter();
        
        // enemy.ChasePlayer();
    }

    public override void Exit()
    {
        base.Exit();
        
        enemy.StopChase();
    }

    public override void Update()
    {
        base.Update();
        
        enemy.ChasePlayer();
        enemy.PositionAttackCheck(0,0);
        
        if (enemy.DistanceToPlayer() < enemy.attackDistance)
            stateMachine.ChangeState(enemy.BattleState);
    }
}

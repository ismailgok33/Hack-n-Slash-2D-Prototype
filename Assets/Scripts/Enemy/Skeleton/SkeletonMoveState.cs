using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMoveState : SkeletonGroundedState
{
    public SkeletonMoveState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, Enemy_Skeleton enemy) : base(enemyBase, stateMachine, animBoolName, enemy)
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
        
        // if ((enemy.DistanceToPlayer().x < enemy.attackDistance) || (enemy.DistanceToPlayer().y < enemy.attackDistance))
        if (enemy.DistanceToPlayer() < enemy.attackDistance)
            stateMachine.ChangeState(enemy.BattleState);
    }
}

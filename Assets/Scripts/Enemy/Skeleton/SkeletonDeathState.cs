using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonDeathState : EnemyState
{
    private Enemy_Skeleton enemy;
    
    public SkeletonDeathState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, Enemy_Skeleton enemy) : base(enemyBase, stateMachine, animBoolName)
    {
        this.enemy = enemy;
    }
    
    public override void Enter()
    {
        base.Enter();

        // enemy.anim.SetBool(enemy.lastAnimBoolName, true);
        // enemy.anim.speed = 0;
        // enemy.cd.enabled = false;

        // stateTimer = 3f;
    }

    public override void Update()
    {
        base.Update();

        // if (stateTimer > 0)
        //     Destroy(enemy.Game);
    }
}

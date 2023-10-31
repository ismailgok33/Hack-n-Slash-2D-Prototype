using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinIdleState : GoblinGroundedState
{
    private Transform player;
    
    public GoblinIdleState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, Enemy_Goblin enemy) : base(enemyBase, stateMachine, animBoolName, enemy)
    {
    }
    
    public override void Enter()
    {
        base.Enter();
        
        player = PlayerManager.Instance.player.transform;

        stateTimer = enemy.attackCooldown;

    }

    public override void Exit()
    {
        base.Exit();

        // AudioManager.instance.PlaySFX(14,enemy.transform);
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer < 0 && player.GetComponent<PlayerStats>().IsDead == false)
            stateMachine.ChangeState(enemy.BattleState);

    }
}

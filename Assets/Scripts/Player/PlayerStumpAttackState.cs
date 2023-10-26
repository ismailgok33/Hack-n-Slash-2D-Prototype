using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStumpAttackState : PlayerState
{
    public PlayerStumpAttackState(Player player, PlayerStateMachine stateMachine, string animBoolName, PlayerControls playerControls) : base(player, stateMachine, animBoolName, playerControls)
    {
    }
    
    public override void Enter()
    {
        base.Enter();

        stateTimer = 1f;
        // player.stats.MakeInvincible(true);
    }

    public override void Exit()
    {
        base.Exit();

        // player.SetDefaultMovementSpeed();
        // player.stats.MakeInvincible(false);
    }

    public override void Update()
    {
        base.Update();
        
        player.SetZeroVelocity();
        
        if (stateTimer >= 0) return;
        
        stateMachine.ChangeState(player.IdleState);
    }

}

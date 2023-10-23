using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player player, PlayerStateMachine stateMachine, string animBoolName, PlayerControls playerControls) : base(player, stateMachine, animBoolName, playerControls)
    {
    }
    
    public override void Enter()
    {
        base.Enter();

        stateTimer = player.dashDuration;

        player.stats.MakeInvincible(true);
    }

    public override void Exit()
    {
        base.Exit();

        player.SetZeroVelocity();

        player.stats.MakeInvincible(false);
    }
    
    public override void Update()
    {
        base.Update();

        player.SetVelocity(player.dashSpeed * player.dashDir, 0);

        if (stateTimer < 0)
            stateMachine.ChangeState(player.IdleState);
    }
}

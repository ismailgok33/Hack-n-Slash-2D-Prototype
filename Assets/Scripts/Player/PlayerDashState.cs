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
        
        stateTimer = SkillManager.Instance.DashSkill.dashDuration;
        
        player.stats.MakeInvincible(true);
    }

    public override void Exit()
    {
        base.Exit();

        // player.SetZeroVelocity();
        player.SetDefaultMovementSpeed();

        player.stats.MakeInvincible(false);
    }
    
    public override void Update()
    {
        base.Update();

        player.SetVelocity(xInput * player.moveSpeed, yInput * player.moveSpeed);

        if (stateTimer >= 0) return;
        
        stateMachine.ChangeState(player.IdleState);

    }
}

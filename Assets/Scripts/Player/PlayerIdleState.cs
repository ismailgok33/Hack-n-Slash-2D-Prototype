using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, string animBoolName, PlayerControls playerControls) : base(player, stateMachine, animBoolName, playerControls)
    {
    }
    
    public override void Enter()
    {
        base.Enter();

        player.SetZeroVelocity();
    }
    
    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if((xInput != 0 || yInput != 0) && !player.isBusy)
            stateMachine.ChangeState(player.MoveState);
    }
}

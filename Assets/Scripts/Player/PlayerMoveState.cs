using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, string animBoolName, PlayerControls playerControls) : base(player, stateMachine, animBoolName, playerControls)
    {
    }
    
    public override void Enter()
    {
        base.Enter();

        // AudioManager.instance.PlaySFX(8,null);
    }

    public override void Exit()
    {
        base.Exit();

        // AudioManager.instance.StopSFX(8);
    }

    public override void Update()
    {
        base.Update();

        player.SetVelocity(xInput * player.moveSpeed, yInput * player.moveSpeed);
        player.PositionAttackCheck(xInput, yInput);


        if (xInput == 0 && yInput == 0)
            stateMachine.ChangeState(player.IdleState);
    }
}

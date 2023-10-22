using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrimaryAttackState : PlayerState
{
    public PlayerPrimaryAttackState(Player player, PlayerStateMachine stateMachine, string animBoolName, PlayerControls playerControls) : base(player, stateMachine, animBoolName, playerControls)
    {
    }
    
    public override void Enter()
    {
        base.Enter();

        //AudioManager.instance.PlaySFX(2); // attack sound effect

        xInput = 0;
        yInput = 0;

        float attackDir = player.facingDir;

        if (xInput != 0)
            attackDir = xInput;

        stateTimer = .1f;
    }

    public override void Exit()
    {
        base.Exit();

        // player.StartCoroutine("BusyFor", .15f);
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer < 0)
            player.SetZeroVelocity();

        if (triggerCalled)
            stateMachine.ChangeState(player.IdleState);
    }
}

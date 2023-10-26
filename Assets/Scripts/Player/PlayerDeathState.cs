using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class PlayerDeathState : PlayerState
{
    public PlayerDeathState(Player player, PlayerStateMachine stateMachine, string animBoolName, PlayerControls playerControls) : base(player, stateMachine, animBoolName, playerControls)
    {
    }
    
    public override void Enter()
    {
        base.Enter();

        // GameObject.Find("Canvas").GetComponent<UI>().SwitchOnEndScreen();
        // TODO: Show End Screen after a couple of seconds
        GameManager.Instance.PauseGame(true);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        player.SetZeroVelocity();
    }
}

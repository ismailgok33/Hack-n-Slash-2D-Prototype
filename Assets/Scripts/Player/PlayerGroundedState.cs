using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player player, PlayerStateMachine stateMachine, string animBoolName, PlayerControls playerControls) : base(player, stateMachine, animBoolName, playerControls)
    {
    }
    
    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }
    
    public override void Update()
    {
        base.Update();

        // if (Input.GetKeyDown(KeyCode.Mouse1) && HasNoSword() && player.skill.sword.swordUnlocked)
        //     stateMachine.ChangeState(player.aimSowrd);
        //
        // if (Input.GetKeyDown(KeyCode.Q) && player.skill.parry.parryUnlocked)
        //     stateMachine.ChangeState(player.counterAttack);
        
        _playerControls.Combat.Attack.performed += _ => Attack();

        // if (!player.IsGroundDetected())
        //     stateMachine.ChangeState(player.airState);
        //
        // if (Input.GetKeyDown(KeyCode.Space) && player.IsGroundDetected())
        //     stateMachine.ChangeState(player.jumpState);
    }

    private void Attack()
    {
        stateMachine.ChangeState(player.PrimaryAttackState);
    }
}

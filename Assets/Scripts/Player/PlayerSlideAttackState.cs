using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSlideAttackState : PlayerState
{
    public PlayerSlideAttackState(Player player, PlayerStateMachine stateMachine, string animBoolName, PlayerControls playerControls) : base(player, stateMachine, animBoolName, playerControls)
    {
    }
    
    public override void Enter()
    {
        base.Enter();

        stateTimer = SkillManager.Instance.SlideAttackSkill.slideDuration;
        player.stats.MakeInvincible(true);
    }

    public override void Exit()
    {
        base.Exit();

        player.SetDefaultMovementSpeed();
        player.stats.MakeInvincible(false);
    }

    public override void Update()
    {
        base.Update();
        
        player.SetVelocity(xInput * player.moveSpeed, yInput * player.moveSpeed);

        CalculateDamagedEnemies();
        
        if (stateTimer >= 0) return;
        
        stateMachine.ChangeState(player.IdleState);
    }

    // TODO: Find a better algorithm to calculate which enemies are hit
    // Maybe draw a line to where animation will end and get the enemies in that line
    private void CalculateDamagedEnemies()
    {
        var playerCollider = player.GetComponent<CapsuleCollider2D>();
        
        // Physics2D.OverlapCollider(player.GetComponent<CapsuleCollider2D>(), null, out Collider2D[] colliders);
        var colliders = Physics2D.OverlapCapsuleAll(player.transform.position, playerCollider.size, playerCollider.direction, 0);
        foreach (var hit in colliders)
        {
            var enemy = hit.GetComponent<Enemy_2>();
            if (enemy != null)
            {
                player.DoDamage(enemy);
            }
        }
    }
}

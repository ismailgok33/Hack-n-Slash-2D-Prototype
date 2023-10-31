using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBattleState : EnemyState
{
    private Transform player;
    private Enemy_Goblin enemy;
    
    public GoblinBattleState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, Enemy_Goblin enemy) : base(enemyBase, stateMachine, animBoolName)
    {
        this.enemy = enemy;
    }
    
    public override void Enter()
    {
        base.Enter();

        player = PlayerManager.Instance.player.transform;

        if (player.GetComponent<PlayerStats>().IsDead)
            stateMachine.ChangeState(enemy.IdleState);
    }
    
    public override void Exit()
    {
        base.Exit();
    }
    
    public override void Update()
    {
        base.Update();
        
        if (enemy.DistanceToPlayer() < enemy.attackDistance)
        {
            if (CanAttack())
                stateMachine.ChangeState(enemy.AttackState);
            else
                stateMachine.ChangeState(enemy.IdleState);
        }
        else
        {
            stateMachine.ChangeState(enemy.MoveState);
        }
        
    }
    
    private bool CanAttack()
    {
        if (Time.time < enemy.lastTimeAttacked + enemy.attackCooldown) return false;
        
        enemy.attackCooldown = Random.Range(enemy.minAttackCooldown, enemy.maxAttackCooldown);
        enemy.lastTimeAttacked = Time.time;
        return true;
    }
}

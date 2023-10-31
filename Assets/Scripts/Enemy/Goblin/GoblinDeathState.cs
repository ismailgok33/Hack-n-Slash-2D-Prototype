using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinDeathState : EnemyState
{
    private Enemy_Goblin enemy;
    
    public GoblinDeathState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, Enemy_Goblin enemy) : base(enemyBase, stateMachine, animBoolName)
    {
        this.enemy = enemy;
    }
    
    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();
    }
}

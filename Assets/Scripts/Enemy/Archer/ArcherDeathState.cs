using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherDeathState : EnemyState
{
    private Enemy_Archer enemy;

    public ArcherDeathState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, Enemy_Archer enemy) : base(enemyBase, stateMachine, animBoolName)
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

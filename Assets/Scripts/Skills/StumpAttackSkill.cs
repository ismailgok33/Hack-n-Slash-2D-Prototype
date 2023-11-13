using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StumpAttackSkill : Skill
{
    // public float stumpDuration;
    
    protected override void Start()
    {
        base.Start();
    }
    
    public override bool CanUseSkill(Card card)
    {
        return base.CanUseSkill(card);
    }
    
    public override void UseSkill()
    {
        base.UseSkill();
        
        player.StateMachine.ChangeState(player.PlayerStumpAttackState);
    }
}

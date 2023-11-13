using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashSkill : Skill
{
    [SerializeField] private float dashSpeed;
    public float dashDuration;
    
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

        player.SetMoveSpeed(dashSpeed);
        
        player.StateMachine.ChangeState(player.PlayerDashState);
    }
    
}

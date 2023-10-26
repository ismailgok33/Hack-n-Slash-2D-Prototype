using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SlideAttackSkill : Skill
{
    [SerializeField] private float slideSpeed;
    public float slideDuration;
    
    protected override void Start()
    {
        base.Start();
    }
    
    public override bool CanUseSkill()
    {
        return base.CanUseSkill();
    }
    
    public override void UseSkill()
    {
        base.UseSkill();

        player.SetMoveSpeed(slideSpeed);
        
        player.StateMachine.ChangeState(player.PlayerSlideAttackState);
    }
}

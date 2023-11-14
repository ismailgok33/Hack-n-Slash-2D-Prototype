using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermanentCard : Card
{
    [SerializeField] private float cooldown;
    [SerializeField] private float cooldownTimer;

    private Skill _skill;
    
    private void Start()
    {
        // _skill = SkillManager.Instance.GetCardSkill(cardSO.skill);
    }

    private void Update()
    {
        if (_skill == null) return;
        
        UpdateCardCooldown(); // TODO: Make this more efficient by not calling it every frame
    }

    public override void SetupCard()
    {
        base.SetupCard();

        _skill = SkillManager.Instance.GetCardSkill(cardSO.skill);
        
        cooldown = _skill.cooldown;
        cooldownTimer = 0f;
    }
    
    private void UpdateCardCooldown()
    {
        cooldownTimer = _skill.cooldownTimer;
        
        amountSlider.value = 1 - (cooldownTimer / cooldown); // TODO: Make this more efficient by not redrawing the whole slider every frame
    }

    protected override void UseCard()
    {
        base.UseCard();
        
        Debug.Log("UseCard is called inside PermanentCard.");
    }

    public override bool CanUseCard()
    {
        return base.CanUseCard();
    }
}

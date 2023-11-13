using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public float cooldown;
    public float cooldownTimer;

    protected Player player;
    
    protected virtual void Start()
    {
        player = PlayerManager.Instance.player;
    }

    protected virtual void Update()
    {
        cooldownTimer -= Time.deltaTime;
    }
    
    public virtual bool CanUseSkill(Card card)
    {
        // if (cooldownTimer > 0 || !CardManager.Instance.GetActiveCard().CanUseCard()) return false;
        if (cooldownTimer > 0 || !card.CanUseCard()) return false;
        
        Debug.Log("CanUseSkill is called inside Skill.");
        
        UseSkill();
        cooldownTimer = cooldown;
        return true;
        
        // player.fx.CreatePopUpText("Cooldown");
        // return false;
    }
    
    public virtual void UseSkill()
    {
        // do some skill spesific things
    }
    
}

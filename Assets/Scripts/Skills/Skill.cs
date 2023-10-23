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
    
    public virtual bool CanUseSkill()
    {
        if (cooldownTimer < 0)
        {
            UseSkill();
            cooldownTimer = cooldown;
            return true;
        }

        // player.fx.CreatePopUpText("Cooldown");
        return false;
    }
    
    public virtual void UseSkill()
    {
        // do some skill spesific things
    }
    
}

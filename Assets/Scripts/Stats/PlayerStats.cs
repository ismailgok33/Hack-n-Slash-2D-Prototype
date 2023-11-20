using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    private Player player;
    
    protected override void Start()
    {
        base.Start();

        player = GetComponent<Player>();
    }

    public override void IncreaseStatBy(int modifier, float duration, Stat statToModify)
    {
        base.IncreaseStatBy(modifier, duration, statToModify);

        if (statToModify == agility)
        {
            player.defaultMoveSpeed += agility.GetValue();
            player.SetDefaultMovementSpeed();
        }
    }

    public override void TakeDamage(int damageAmount)
    {
        base.TakeDamage(damageAmount);
    }
    
    protected override void Die()
    {
        base.Die();
        player.Die();

        // TODO: Remove temporary cards and points
        // GameManager.instance.lostCurrencyAmount = PlayerManager.instance.currency;
        // PlayerManager.instance.currency = 0;

    }
    
    
    
}

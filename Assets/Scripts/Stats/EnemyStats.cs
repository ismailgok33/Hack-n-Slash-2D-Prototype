using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    private Enemy enemy;
    
    protected override void Start()
    {
        base.Start();

        enemy = GetComponent<Enemy>();
    }
    
    // TODO: Change stats of a specific enemy
    // private void Modify(Stat statToApply)
    // {
    //     for (int i = 1; i < level; i++)
    //     {
    //         float modifier = statToApply.GetValue() * percantageModifier;
    //
    //         statToApply.AddModifier(Mathf.RoundToInt(modifier));
    //     }
    // }
    
    public override void TakeDamage(int damageAmount)
    {
        base.TakeDamage(damageAmount);
    }
    
    protected override void Die()
    {
        base.Die();

        enemy.Die();

        // Destroy(gameObject, 3f);
    }
}

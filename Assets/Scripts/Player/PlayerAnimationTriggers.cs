using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTriggers : MonoBehaviour
{
    private Player player => GetComponentInParent<Player>();

    private void AnimationTrigger()
    {
        player.AnimationTrigger();
    }
    
    private void AttackTrigger()
    {
        // AudioManager.instance.PlaySFX(2,null);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.attackCheck.position, player.attackCheckRadius);

        DamageEnemies(colliders);
    }
    
    private void StumpAttackTrigger()
    {
        // AudioManager.instance.PlaySFX(2,null);

        Collider2D[] colliders =
            Physics2D.OverlapBoxAll(player.stumpAttackCheck.position, player.stumpAttackCheckSize, 0);

        DamageEnemies(colliders);
    }

    private void DamageEnemies(Collider2D[] colliders)
    {
        foreach (var hit in colliders)
        {
            var enemy = hit.GetComponent<Enemy>();
            if (enemy != null)
            {
                // TODO: Replace this with stats.DoDamage after refactoring the Enemy
                // player.DoDamage(enemy);
                
                EnemyStats target = hit.GetComponent<EnemyStats>();
                
                if(target != null) 
                    player.stats.DoDamage(target);
            }
        }
    }
}

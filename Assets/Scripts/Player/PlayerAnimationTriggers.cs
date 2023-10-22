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

        foreach (var hit in colliders)
        {
            var enemy = hit.GetComponent<Enemy>();
            if (enemy != null)
            {
                player.DoDamage(enemy);
                
                // EnemyStats _target = hit.GetComponent<EnemyStats>();
                //
                // if(_target != null) 
                //     player.stats.DoDamage(_target);
            }
        }
    }
}

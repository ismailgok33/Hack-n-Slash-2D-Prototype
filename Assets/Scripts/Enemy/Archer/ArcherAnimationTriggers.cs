using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAnimationTriggers : EnemyAnimationTriggers
{
    private Enemy_Archer Enemy => GetComponentInParent<Enemy_Archer>();
    
    private void ShootArrow() => Enemy.ShootArrow();
}

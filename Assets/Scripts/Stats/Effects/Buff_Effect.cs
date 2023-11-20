using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Buff effect", menuName = "ScriptableObjects/Card effects/Buff effect")]
public class Buff_Effect : CardEffect
{
    private PlayerStats stats;
    [SerializeField] private StatType buffType;
    [SerializeField] private int buffAmount;
    [SerializeField] private float buffDuration;

    public override void ExecuteEffect(Transform enemyPosition)
    {
        stats = PlayerManager.Instance.player.GetComponent<PlayerStats>();
        stats.IncreaseStatBy(buffAmount, buffDuration, stats.GetStat(buffType));
    }
}

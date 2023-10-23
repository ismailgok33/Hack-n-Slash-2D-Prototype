using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
   [Header("Major stats")]
   public Stat agility;
   public Stat maxHealth;
   public Stat damage;
   
   public bool isDead { get; private set; }
   public bool isInvincible { get; private set; }
   private bool isVulnerable;
   public int currentHealth;
   
   // public System.Action onHealthChanged;
   
   protected virtual void Start()
   {
      currentHealth = GetMaxHealthValue();
   }
   
   protected virtual void Update()
   {
      
   }
   
   public void MakeVulnerableFor(float duration) => StartCoroutine(VulnerableCoroutine(duration));
   
   private IEnumerator VulnerableCoroutine(float duration)
   {
      isVulnerable = true;

      yield return new WaitForSeconds(duration);

      isVulnerable = false;
   }
   
   public virtual void IncreaseStatTemporaryBy(int modifier, float duration, Stat statToModify)
   {
      StartCoroutine(StatModCoroutine(modifier, duration, statToModify));
   }

   private IEnumerator StatModCoroutine(int modifier, float duration, Stat statToModify)
   {
      statToModify.AddModifier(modifier);

      yield return new WaitForSeconds(duration);

      statToModify.RemoveModifier(modifier);
   }
   
   public virtual void DoDamage(CharacterStats targetStats)
   {
      if (targetStats.isInvincible)
         return;

      // if (TargetCanAvoidAttack(targetStats))
      //    return;
      
      var totalDamage = damage.GetValue();
      
      targetStats.TakeDamage(totalDamage);
   }
   
   public virtual void TakeDamage(int damageAmount)
   {

      if (isInvincible)
         return;

      DecreaseHealthBy(damageAmount);
      
      // GetComponent<Entity>().DamageImpact();

      if (currentHealth < 0 && !isDead)
         Die();
   }
   
   protected virtual void DecreaseHealthBy(int damageAmount)
   {

      // if (isVulnerable)
      //    damageAmount = Mathf.RoundToInt( damageAmount * 1.1f);

      currentHealth -= damageAmount;

      // if (damageAmount > 0)
      //    fx.CreatePopUpText(damageAmount.ToString());

      // if (onHealthChanged != null)
      //    onHealthChanged();
   }

   protected virtual void Die()
   {
      isDead = true;
   }

   public void KillEntity()
   {
      if (!isDead)
         Die();
   }
   
   public void MakeInvincible(bool invincible) => isInvincible = invincible;
   
   public int GetMaxHealthValue()
   {
      return maxHealth.GetValue();
   }
   
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private CardScriptableObject cardSO;

    [SerializeField] private int amount;
    
    [SerializeField] private TMP_Text cardNameText;
    [SerializeField] private Image cardIconImage;
    [SerializeField] private Image cardColor;
    [SerializeField] private Slider amountSlider;
    
    private CardSkill cardSkill;

    private bool onCooldown = false;

    public void SetupCard()
    {
        if (cardSO == null) return;

        amount = cardSO.amount;
        
        cardNameText.text = cardSO.cardName;
        cardIconImage.sprite = cardSO.icon;
        cardColor.color = cardSO.color;

        amountSlider.maxValue = cardSO.amount;
        cardSkill = cardSO.skill;
        UpdateCardAmount();
        // amountSlider.value = 0;
    }

    private void UpdateCardAmount()
    {
        amountSlider.value = cardSO.amount - amount;
    }

    private void UseCard()
    {
        // if (cardSO == null || amount == 0 || onCooldown) return;

        // onCooldown = true;
        amount--;
        // SkillManager.Instance.UseSkill(cardSO.skill);
        
        UpdateCardAmount();
        // StartCoroutine(EndCardRoutine());
    }

    public bool CanUseCard()
    {
        if (cardSO == null || amount == 0) return false;

        Debug.Log("CanUseCard is called inside Card.");
        
        UseCard();
        return true;
    }
    
    private IEnumerator EndCardRoutine()
    {
        yield return new WaitForSeconds(cardSO.cooldown);
        onCooldown = false;
    }

    public CardSkill GetCardSkill()
    {
        return cardSkill;
    }
}

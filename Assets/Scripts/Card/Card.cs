using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public CardScriptableObject cardSO;

    // [SerializeField] private int amount;
    
    [SerializeField] protected TMP_Text cardNameText;
    [SerializeField] protected Image cardIconImage;
    [SerializeField] protected Image cardColor;
    [SerializeField] protected Slider amountSlider;
    
    protected CardSkill cardSkill;

    // private bool onCooldown = false;
    
    public virtual void SetupCard()
    {
        if (cardSO == null) return;

        // amount = cardSO.amount;
        
        cardNameText.text = cardSO.cardName;
        cardIconImage.sprite = cardSO.icon;
        cardColor.color = cardSO.color;

        amountSlider.maxValue = cardSO.amount;
        cardSkill = cardSO.skill;
        // UpdateCardAmount();
        // amountSlider.value = 0;
    }

    // private void UpdateCardAmount()
    // {
    //     amountSlider.value = cardSO.amount - amount;
    //     
    //     DestroyActiveCard();
    // }

    protected virtual void UseCard()
    {
        // // If the card is a permanent card
        // if (amount == -1)
        // {
        //      
        // }
        // else // if the card is a consumable card
        // {
        //     amount--;
        //     UpdateCardAmount();
        // }
    }

    public virtual bool CanUseCard()
    {
        // if (cardSO == null || amount == 0) return false;
        if (cardSO == null) return false;

        Debug.Log("CanUseCard is called inside Card.");
        
        UseCard();
        return true;
    }

    // private void DestroyActiveCard()
    // {
    //     if (amount > 0) return;
    //     
    //     // TODO: Play Card Destruction FX
    //     
    //     CardManager.Instance.DestroyActiveCard();
    // }

    public virtual CardSkill GetCardSkill()
    {
        return cardSkill;
    }
}

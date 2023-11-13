using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableCard : Card
{
    [SerializeField] private int amount;
    
    public override void SetupCard()
    {
        base.SetupCard();
        
        amount = cardSO.amount;
        UpdateCardAmount();
    }
    
    private void UpdateCardAmount()
    {
        amountSlider.value = cardSO.amount - amount;
        
        DestroyActiveCard();
    }
    
    private void DestroyActiveCard()
    {
        if (amount > 0) return;
        
        // TODO: Play Card Destruction FX
        
        CardManager.Instance.DestroyActiveCard();
    }

    protected override void UseCard()
    {
        base.UseCard();
        
        Debug.Log("UseCard is called inside ConsumableCard.");

        if (amount == 0) return;
        
        amount--;
        UpdateCardAmount();
    }

    public override bool CanUseCard()
    {
        return base.CanUseCard();
    }
}

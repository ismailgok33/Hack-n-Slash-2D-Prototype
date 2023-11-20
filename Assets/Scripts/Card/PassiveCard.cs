using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveCard : Card
{
    [SerializeField] private CardEffect cardEffect;
    public override void SetupCard()
    {
        base.SetupCard();
     
        // TODO: Create separate scriptable object for passive cards and other card types
        // cardEffect = cardSO.cardEffect;
    }
    
    protected override void UseCard()
    {
        base.UseCard();
        
        cardEffect.ExecuteEffect(null);
    }
    
    public override bool CanUseCard()
    {
        return base.CanUseCard();
    }
    
    
}

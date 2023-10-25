using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance { get; private set; }
    
    [SerializeField] private List<Card> cards = new List<Card>();
    [SerializeField] private Card activeCard;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        if (cards.Count > 0)
        {
            activeCard = cards[0];
            activeCard.SetupCard();
        }
    }

    public void UseActiveCard()
    {
        if (activeCard == null) return;
        
        Debug.Log("UseActiveCard is called inside CardManager.");
        
        // activeCard.UseCard();
        SkillManager.Instance.UseSkill(activeCard.GetCardSkill());
    }
    
    public Card GetActiveCard()
    {
        return activeCard;
    }

}

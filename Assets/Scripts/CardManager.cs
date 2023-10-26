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
        Transform cardTemplate = transform.Find("CardTemplate");

        for (var i = 0; i < cards.Count; i++)
        {
            var cardTransform = Instantiate(cardTemplate, transform);
            cardTransform.gameObject.SetActive(true);

            var offset = new Vector2(-20, 10);
            cardTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(offset.x * i, offset.y * i);
            
            cardTransform.GetComponent<Card>().SetupCard();
        }
        
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

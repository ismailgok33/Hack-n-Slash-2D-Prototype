using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance { get; private set; }
    
    private List<Card> currentCards = new List<Card>();
    public Card ActiveCard { get; private set; }
    public int ActiveCardIndex { get; private set; }
    [SerializeField] private List<CardScriptableObject> cardSOList = new List<CardScriptableObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        var cardTemplate = transform.Find("CardTemplate");

        for (var i = cardSOList.Count - 1; i >= 0; i--)
        {
            var cardTransform = Instantiate(cardTemplate, transform);
            cardTransform.gameObject.SetActive(true);

            var offset = new Vector2(-20, 10);
            cardTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(offset.x * i -120, offset.y * i + 150);

            var card = cardTransform.GetComponent<Card>();

            card.cardSO = cardSOList[i];
            cardTransform.GetComponent<Card>().SetupCard();
            currentCards.Insert(0, card);
        }
        
        if (currentCards.Count > 0)
        {
            ActiveCard = currentCards[0];
            // activeCard.SetupCard();
        }
    }

    public void UseActiveCard()
    {
        if (ActiveCard == null) return;
        
        Debug.Log("UseActiveCard is called inside CardManager.");
        
        // activeCard.UseCard();
        SkillManager.Instance.UseSkill(ActiveCard.GetCardSkill());
    }
    
    public Card GetActiveCard() => ActiveCard;

    public void DestroyActiveCard()
    {
        currentCards.RemoveAt(0);
        
        Destroy(ActiveCard.gameObject);
        
        if (currentCards.Count > 0)
        {
            ActiveCard = currentCards[0];
            UpdateCardUI();
        }
        else
        {
            ActiveCard = null;
        }
    }
    
    private void UpdateCardUI()
    {
        var offset = new Vector2(-20, 10);
        var index = 0;
        foreach (var card in currentCards)
        {
            var cardPosition = card.GetComponent<RectTransform>().anchoredPosition;
            
            // Vector2.Lerp(cardPosition, new Vector2(cardPosition.x + offset.x, cardPosition.y + offset.y), 0.5f);
            // card.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(cardPosition, new Vector2(offset.x * index -120, offset.y * index + 150), Time.deltaTime);
            StartCoroutine(MoveTo(card, cardPosition, new Vector2(offset.x * index - 120, offset.y * index + 150), 0.1f));
            index++;
        }
    }
    
    private IEnumerator MoveTo(Card card, Vector2 startPosition, Vector2 endPosition, float time)
    {
        float t = 0;

        while(t < 1)
        {
            yield return null;
            t += Time.deltaTime / time;
            card.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(startPosition, endPosition, t);
        }
        card.GetComponent<RectTransform>().anchoredPosition = endPosition;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardType
{
    Attack,
    Defense,
    Utility
}

[CreateAssetMenu(fileName = "New Card", menuName = "ScriptableObjects/Card")]
public class CardScriptableObject : ScriptableObject
{
    public string cardName;
    public Color color;
    public Sprite icon;
    public int damage;
    public int amount;
    public CardType type;
    public CardSkill skill;
    // public Skill skill;
    public float cooldown;
}

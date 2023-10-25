using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance { get; private set; }
    
    public DashSkill DashSkill { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        DashSkill = GetComponent<DashSkill>();
    }

    public void UseSkill(CardSkill cardSkill)
    {
        switch (cardSkill)
        {
            case CardSkill.Dash:
                DashSkill.CanUseSkill();
                break;
            case CardSkill.Pistol:
                Debug.Log("Pistol is used");
                break;
            default:
                Debug.Log("Skill cannot be identified!");
                break;
        }
    }
}

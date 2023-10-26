using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public enum CardSkill
{
    Dash,
    SlideAttack,
    StumpAttack,
    Pistol
}

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance { get; private set; }
    
    public DashSkill DashSkill { get; private set; }
    public SlideAttackSkill SlideAttackSkill { get; private set; }
    public StumpAttackSkill StumpAttackSkill { get; private set; }

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
        SlideAttackSkill = GetComponent<SlideAttackSkill>();
        StumpAttackSkill = GetComponent<StumpAttackSkill>();
    }

    public void UseSkill(CardSkill cardSkill)
    {
        switch (cardSkill)
        {
            case CardSkill.Dash:
                DashSkill.CanUseSkill();
                break;
            case CardSkill.SlideAttack:
                SlideAttackSkill.CanUseSkill();
                break;
            case CardSkill.StumpAttack:
                StumpAttackSkill.CanUseSkill();
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

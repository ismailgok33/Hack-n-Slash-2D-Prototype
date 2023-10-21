using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardSkill
{
    Dash,
    Pistol
}

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance { get; private set; }
    
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 1f;
    
    [Header("Dash")]
    [SerializeField] private float dashSpeed = 4f;
    [SerializeField] private float dashDuration = 0.2f;
    // [SerializeField] private float dashCooldown = 1f;
    private float _originalMoveSpeed = 1f;
    private bool _isDashing = false;
    
    private TrailRenderer _trailRenderer;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
        _trailRenderer = GetComponentInChildren<TrailRenderer>();
    }

    private void Start()
    {
        moveSpeed = PlayerController.Instance.moveSpeed;
        _originalMoveSpeed = moveSpeed;
    }

    public void UseSkill(CardSkill skill)
    {
        switch (skill)
        {
            case CardSkill.Dash:
                Dash();
                break;
            case CardSkill.Pistol:
                Debug.Log("Pistol is used");
                break;
            default:
                Debug.Log("Default state is triggered!");
                break;
        }
    }
    
    private void Dash()
    {
        if (_isDashing) return;
        _isDashing = true;
        PlayerController.Instance.Dash();
        Debug.Log("moveSpeed before dash: " + moveSpeed);
        moveSpeed *= dashSpeed;
        PlayerController.Instance.moveSpeed = moveSpeed;
        Debug.Log("moveSpeed after dash: " + moveSpeed);
        _trailRenderer.emitting = true;
        StartCoroutine(EndDashRoutine());
    }

    private IEnumerator EndDashRoutine()
    {
        yield return new WaitForSeconds(dashDuration);
        moveSpeed = _originalMoveSpeed;
        PlayerController.Instance.moveSpeed = moveSpeed;
        _trailRenderer.emitting = false;
        // yield return new WaitForSeconds(dashCooldown);
        _isDashing = false;
        PlayerController.Instance.EndDash();
    }

}

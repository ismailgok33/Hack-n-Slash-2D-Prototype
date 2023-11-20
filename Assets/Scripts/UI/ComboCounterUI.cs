using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComboCounterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI comboCounterText;
    
    private int _comboCounter = 0;
    public float cooldown = 5f;
    public float cooldownTimer;

    private void Awake()
    {
        comboCounterText = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        comboCounterText.text = "";
        cooldownTimer = cooldown;
    }

    private void Update()
    {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0)
        {
            _comboCounter = 0;
            comboCounterText.text = "";
        }
    }

    private void UpdateComboCounter(object sender, EventArgs e)
    {
        _comboCounter++;
        comboCounterText.text = "X" + _comboCounter;
        cooldownTimer = cooldown;
        
        Animate();
    }

    private void Animate()
    {
        // TODO: Animate the combo counter when increased with a circular timer animation
    }
    
    private void OnEnable()
    {
        Enemy.OnEnemyDeath += UpdateComboCounter;
    }

    private void OnDisable()
    {
        Enemy.OnEnemyDeath -= UpdateComboCounter;
    }
}

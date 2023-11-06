using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillCounterUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI killCounterText;
    
    private int _killCounter = 0;

    private void Awake()
    {
        killCounterText = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        killCounterText.text = _killCounter.ToString();
    }

    private void OnEnable()
    {
        Enemy.OnEnemyDeath += UpdateKillCounter;
    }

    private void OnDisable()
    {
        Enemy.OnEnemyDeath -= UpdateKillCounter;
    }
    
    private void UpdateKillCounter(object sender, EventArgs e)
    {
        _killCounter++;
        killCounterText.text = _killCounter.ToString();
    }
}

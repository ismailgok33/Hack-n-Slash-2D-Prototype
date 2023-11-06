using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    private float _elapsedTime = 0f;

    private void Awake()
    {
        timerText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _elapsedTime += Time.deltaTime;
        var hours = Mathf.FloorToInt(_elapsedTime / 3600f);
        var minutes = Mathf.FloorToInt(_elapsedTime / 60f);
        var seconds = Mathf.FloorToInt(_elapsedTime % 60f);
        
        if (hours > 0)
            timerText.text = $"{hours:00}:{minutes:00}:{seconds:00}";
        else
            timerText.text = $"{minutes:00}:{seconds:00}";
    }
}

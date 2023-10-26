using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    private Transform player;
    private bool gameIsPaused;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        player = PlayerManager.Instance.player.transform;
        
        // TODO: Register ESC key as menu key here and make the game pause in Update
    }
    
    public void PauseGame(bool pause)
    {
        if (pause)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }
    
}

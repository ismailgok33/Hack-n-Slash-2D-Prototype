using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    private Transform player;
    public bool gameIsPaused;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        player = PlayerManager.Instance.player.transform;
    }
    
    public void RestartScene()
    {   
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    
    public void PauseGame(bool pause)
    {
        if (pause)
        {
            Time.timeScale = 0;
            gameIsPaused = true;
        }
        else
        {
            Time.timeScale = 1;
            gameIsPaused = false;
        }
    }
    
}

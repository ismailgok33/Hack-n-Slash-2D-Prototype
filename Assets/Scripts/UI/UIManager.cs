using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject inGameUI;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        SwitchTo(null);
    }

    public void SwitchTo(GameObject showMenu)
    {
        for (var i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        if (showMenu != null)
        {
            showMenu.SetActive(true);
            GameManager.Instance.PauseGame(true);
        }
        else
        {
            inGameUI.SetActive(true);
            GameManager.Instance.PauseGame(false);
        }
    }
    
    public void ResumeGameButton() => SwitchTo(null);
    
    public void RestartGameButton() => GameManager.Instance.RestartScene();

    public void TogglePauseMenu() => SwitchTo(pauseMenu.activeSelf ? null : pauseMenu);
}

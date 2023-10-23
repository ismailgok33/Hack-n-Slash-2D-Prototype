using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    public Player player;

    private void Awake()
    {
        if (Instance != null)
            Destroy(Instance.gameObject);
        else
            Instance = this;
    }
    
    // public void LoadData(GameData data)
    // {
    //     this.currency = data.currency;
    // }
    //
    // public void SaveData(ref GameData data)
    // {
    //     data.currency = this.currency;
    // }
}

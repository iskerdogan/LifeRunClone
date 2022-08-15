using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class SaveManager : Singleton<SaveManager>
{
    private int currentLevel;

    public int CurrentLevel => currentLevel;

    private void Awake() 
    {
        currentLevel = PlayerPrefs.GetInt("Level");    
    }
    private void Start() 
    {
        GameManager.OnAfterStateChanged += OnAfterStateChanged;
        Debug.Log(currentLevel);
    }

    public void SaveMoney(int money)
    {
        PlayerPrefs.SetInt("Money", money);
    }


    private void OnAfterStateChanged(GameState newState)
    {
        switch (newState)
        {
            case GameState.Success:
                currentLevel++;
                if (currentLevel > 9)
                {
                    currentLevel = 0;
                }
                PlayerPrefs.SetInt("Level",currentLevel);
                break;
            
        }
    }
}

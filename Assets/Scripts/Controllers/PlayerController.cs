using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Utilities;

public class PlayerController : Singleton<PlayerController>
{

    // [SerializeField]
    // private int[] levelValues;

    // [SerializeField]
    // private TextMeshPro popUpText;

    private int oldSpermCount;
    private int value;


    private void Start()
    {
        GameManager.OnAfterStateChanged += OnAfterStateChanged;
    }

    public void DecraseSpermCount(int gateValue,OperationType operationType)
    {
        var newValue = SpermController.Instance.CurrentSpermCount;
        oldSpermCount = SpermController.Instance.CurrentSpermCount;
        switch (operationType)
        {
            case OperationType.Div:
                value = newValue - (newValue / gateValue);
                newValue /= gateValue;
            break;
            case OperationType.Sum:
                value = gateValue;
                newValue -= gateValue;
            break;
        }
        
        if (newValue < 1)
        {
            GameManager.Instance.ChangeGameState(GameState.Fail);
        }
        for (int i = 0; i < oldSpermCount-newValue; i++)
        {
            SpermController.Instance.Remove();
        }
    }

    public void IncreaseSpermCount(int gateValue,OperationType operationType)
    {
        var newValue = SpermController.Instance.CurrentSpermCount;
        oldSpermCount = SpermController.Instance.CurrentSpermCount;
        switch (operationType)
        {
            case OperationType.Mul: 
                newValue *= gateValue;
            break;
            case OperationType.Sub:
                newValue += gateValue;
            break;
        }
        if (newValue < 1)
        {
            GameManager.Instance.ChangeGameState(GameState.Fail);
        }

        for (int i = 0; i < newValue - oldSpermCount; i++)
        {
            SpermController.Instance.Add();
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        var collectable = other.GetComponent<ICollectable>();
        if (collectable != null)
        {
            collectable.Collect();
        }
        var finishLine = other.GetComponent<FinishLine>();
        if (finishLine != null)
        {
            GameManager.Instance.ChangeGameState(GameState.Final); 
        }
    }

    private void OnAfterStateChanged(GameState newState)
    {
        switch (newState)
        {
            case GameState.Start:
                break;
            case GameState.Final:
                break;

        }
    }

}

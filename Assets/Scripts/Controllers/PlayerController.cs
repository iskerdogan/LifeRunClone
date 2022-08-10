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
    private int temp = 1;
    private int playerCurrentLevel;
    private float timer;
    private bool isTimerActive = false;
    public int OldSpermCount => oldSpermCount;
    public int PlayerCurrentLevel => playerCurrentLevel;
    
    // private Vector3 priceTagCurrentPosition;
    // private Vector3 priceTagCurrentScale;
    // private Material priceTagColor;
    // private Color priceTagGreen;
    // private Color priceTagBlue;
    // private Color priceTagRed;
    // private Color priceTagPopupRed;


    private void Start()
    {
        GameManager.OnAfterStateChanged += OnAfterStateChanged;
    }


    private void FixedUpdate()
    {
        // if (isTimerActive)
        // {
        //     timer -= Time.deltaTime;
        // }
        // if (GameManager.Instance.State == GameState.Final)
        // {
        //     isTimerActive = true;
        //     if (timer <= 0)
        //     {
        //         isTimerActive = false;
        //         // FinalLevelChange();
        //     }
        // }
    }

    // private void OnChangeSpermCount()
    // {

    //     if (SpermController.Instance.CurrentSpermCount < oldSpermCount)
    //     {
    //         for (int i = SpermController.Instance.CurrentSpermCount; i <= oldSpermCount; i++)
    //         {
    //             sperms[i].SetActive(false);
    //         }
    //     }
    //     else
    //     {
    //         Debug.Log(SpermController.Instance.CurrentSpermCount);
    //         Debug.Log(oldSpermCount);
    //         for (int i = oldSpermCount; i < SpermController.Instance.CurrentSpermCount; i++)
    //         {
    //             sperms[i].SetActive(true);
    //         }
    //     }

    // }
    public void DecrasePrice(int gateValue,OperationType operationType)
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

    public void IncreasePrice(int gateValue,OperationType operationType)
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

    // private void OnChangePrice()
    // {
    //     if (levelValues[playerCurrentLevel + 1] <= currentPrice && levelValues.Length != playerCurrentLevel + 1)
    //     {
    //         var increaseCount = 0;
    //         for (int i = playerCurrentLevel + 1; i < levelValues.Length; i++)
    //         {
    //             if (levelValues[i] <= currentPrice)
    //             {
    //                 increaseCount++;
    //             }
    //             else
    //             {
    //                 break;
    //             }
    //         }
    //         levels[playerCurrentLevel].SetActive(false);
    //         transform.LeanScale(Vector3.zero, 0).setOnComplete(()=> transform.LeanScale(currentScale, .3f).setEaseOutExpo());
    //         playerCurrentLevel += increaseCount;
    //         levels[playerCurrentLevel].SetActive(true);
    //     }
    //     else if (!(playerCurrentLevel <= 0))
    //     {
    //         if (levelValues[playerCurrentLevel] > currentPrice)
    //         {
    //             var decreaseCount = 0;
    //             for (int i = playerCurrentLevel; i >= 0; i--)
    //             {
    //                 if (levelValues[i] > currentPrice)
    //                 {
    //                     decreaseCount++;
    //                 }
    //                 else break;
    //             }
    //             levels[playerCurrentLevel].SetActive(false);
    //             playerCurrentLevel -= decreaseCount;
    //             levels[playerCurrentLevel].SetActive(true);
    //             transform.LeanScale(Vector3.zero, 0).setOnComplete(()=> transform.LeanScale(currentScale, .3f).setEaseOutExpo());
    //         }
    //     }
    //     temp = playerCurrentLevel;

    //     if (oldPrice > currentPrice)
    //     {
    //         popUpText.gameObject.SetActive(true);
    //         popUpText.text = "-" + value.ToString();
    //         popUpText.color = priceTagPopupRed;
    //         popUpText.transform.LeanMoveLocal(new Vector3(-0.0979999974f, 0.386999995f, 0.0659999996f), .3f).setOnComplete(() =>
    //         {
    //             popUpText.gameObject.SetActive(false);
    //             popUpText.transform.LeanMoveLocal(new Vector3(-0.0979999974f, 0.0140000004f, 0.0659999996f), 0);
    //         });

    //         priceTagColor.color = priceTagRed;
    //         LeanTween.delayedCall(.5f, () => priceTagColor.color = priceTagGreen);
    //     }
    //     else if (oldPrice < currentPrice)
    //     {
    //         popUpText.gameObject.SetActive(true);
    //         popUpText.text = "+" + value.ToString();
    //         popUpText.color = priceTagBlue;
    //         popUpText.transform.LeanMoveLocal(new Vector3(-0.0979999974f, 0.386999995f, 0.0659999996f), .3f).setOnComplete(() =>
    //         {
    //             popUpText.gameObject.SetActive(false);
    //             popUpText.transform.LeanMoveLocal(new Vector3(-0.0979999974f, 0.0140000004f, 0.0659999996f), 0);
    //         });

    //         priceTagColor.color = priceTagBlue;
    //         LeanTween.delayedCall(.5f, () => priceTagColor.color = priceTagGreen);
    //     }
    // }

    // public void FinalLevelChange()
    // {
    //     if (multipliersCount >= 8)
    //     {
    //         multipliersCount = 8;
    //         if (transform.position.y >= MovementController.Instance.multipliers[multipliersCount].transform.position.y && transform.position.y <= MovementController.Instance.multipliers[9].transform.position.y)
    //         {
    //             multipliersCount++;
    //             if (temp == 0)
    //             {
    //                 return;
    //             }
    //             levels[temp].SetActive(false);
    //             levels[--temp].SetActive(true);
    //             timer = .01f;
    //             isTimerActive = true;
    //         }
    //     }
    //     if (transform.position.y >= MovementController.Instance.multipliers[multipliersCount].transform.position.y && transform.position.y <= MovementController.Instance.multipliers[multipliersCount+1].transform.position.y)
    //     {
    //         multipliersCount++;
    //         if (temp == 0)
    //         {
    //             return;
    //         }
    //         levels[temp].SetActive(false);
    //         levels[--temp].SetActive(true);
    //         timer = .05f;
    //         isTimerActive = true;
    //     }
    // }

    private void OnAfterStateChanged(GameState newState)
    {
        switch (newState)
        {
            case GameState.Start:
                // sperms[0].SetActive(true);
                // SpermController.Instance.CurrentSpermCount = 1;
                playerCurrentLevel = 0;
                timer = 0;
                break;
            case GameState.Final:
                break;

        }
    }

}

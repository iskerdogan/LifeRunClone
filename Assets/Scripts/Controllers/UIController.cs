using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Utilities;

public class UIController : Singleton<UIController>
{

    [SerializeField]
    private GameObject failPanel;

    [SerializeField]
    private GameObject LevelComplatedPanel;


    [SerializeField]
    private TextMeshProUGUI spermCountText;

    [SerializeField]
    private TextMeshProUGUI popUpText;


    void Start()
    {
        // InputSystem.Instance.TouchPositionChanged += OnTouchPositionChanged;
        // GameManager.OnAfterStateChanged += OnAfterStateChanged;
        // PlayerController.Instance.ChangePrice += OnChangePrice;
        // MovementController.Instance.MultiplicationIsComplete += OnMultiplicationIsComplete;
        SpermController.Instance.OnSpermCountChanged += OnSpermCountChanged;

    }

    private void OnSpermCountChanged()
    {
        spermCountText.text = SpermController.Instance.CurrentSpermCount.ToString();
    }


    // private void InitGame()
    // {
    //     InputSystem.Instance.TouchPositionChanged += OnTouchPositionChanged;
    //     GameManager.OnAfterStateChanged += OnAfterStateChanged;

    //     startPanel.SetActive(true);
    //     failPanel.SetActive(false);
    //     LevelComplatedPanel.SetActive(false);
    //     priceTagText.text = 0 + "$";
    //     MoneyText.text = PlayerPrefs.GetInt("Money").ToString();
    //     SwipeToMove();
    //     GetCurrentLevel();
    // }

    private void GetCurrentSpermCount()
    {
        spermCountText.text = "Level " + (SaveManager.Instance.CurrentLevel + 1).ToString();
    }

    private void SwipeToMove()
    {
        // swipeToMove.transform.LeanMoveLocalX(-270f, 0.5f).setOnComplete(() => swipeToMove.transform.LeanMoveLocalX(270f, 0.5f).setLoopPingPong());
    }


    // public void PopUp()
    // {
    //     if ((SaveManager.Instance.CurrentLevel + 1) == 1) popUpText.text = "+" + PlayerPrefs.GetInt("Money").ToString();
        
    //     popUpText.text = "+" + PlayerController.Instance.TempMoney.ToString();
    //     // LeanTween.moveLocalY(popUpText.gameObject, 855.5f, .5f).setOnComplete(() => LeanTween.delayedCall(.5f, () => LeanTween.moveLocalY(popUpText.gameObject, 929.599976f, 0)));
        
    // }

    // private void OnAfterStateChanged(GameState newState)
    // {
    //     switch (newState)
    //     {
    //         case GameState.Start:
    //             // LeanTween.cancelAll();
    //             InitGame();
    //             break;
    //         case GameState.Fail:
    //             failPanel.SetActive(true);
    //             break;
    //         case GameState.Success:
    //             LevelComplatedPanel.SetActive(true);
    //             break;
    //         case GameState.Final:
    //             break;

    //     }
    // }

}

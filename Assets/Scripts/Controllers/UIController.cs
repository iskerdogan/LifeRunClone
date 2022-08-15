using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class UIController : Singleton<UIController>
{

    [SerializeField]
    private GameObject failPanel;

    [SerializeField]
    private GameObject LevelComplatedPanel;

    [SerializeField]
    private GameObject inGamePanel;


    [SerializeField]
    private TextMeshProUGUI spermCountText;

    [SerializeField]
    private TextMeshProUGUI popUpText;

    [SerializeField]
    private Image uiFillImage;

    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private Transform endLineTransform;

    private Vector3 endLinePosition;
    private float fullDistance;
    private Vector3 playerPos;
    private float progressValue;

    void Start()
    {
        spermCountText.text = SpermController.Instance.CurrentSpermCount.ToString() + "/" + SpermController.Instance.FinalSpermCount.ToString();
        //endLinePosition = endLineTransform.position;
        fullDistance = GetDistance();

        GameManager.OnAfterStateChanged += OnAfterStateChanged;
        SpermController.Instance.OnSpermCountChanged += OnSpermCountChanged;

    }

    private void Update() 
    {
        if (GameManager.Instance.State != GameState.InGame) return;
        playerPos = playerTransform.position;
        float newDisctance = GetDistance();
        Debug.Log(fullDistance);
        Debug.Log(newDisctance);
        progressValue = Mathf.InverseLerp(fullDistance,0f,newDisctance);
        Debug.Log(progressValue);
        uiFillImage.fillAmount = progressValue;
        //UpdateProgressFill(progressValue);

    }

    private void OnSpermCountChanged()
    {
        spermCountText.text = SpermController.Instance.CurrentSpermCount.ToString() + "/" + SpermController.Instance.FinalSpermCount.ToString();
        if (GameManager.Instance.State == GameState.InGame && SpermController.Instance.CurrentSpermCount <= 0) GameManager.Instance.ChangeGameState(GameState.Fail);
    }


    private void InitGame()
    {
        inGamePanel.SetActive(true);
        failPanel.SetActive(false);
        LevelComplatedPanel.SetActive(false);
    }

    private void GetCurrentSpermCount() => spermCountText.text = "Level " + (SaveManager.Instance.CurrentLevel + 1).ToString();


    private float GetDistance()
    {
        return Vector3.Distance(MovementController.Instance.transform.position,endLineTransform.position);
    }
    // private void UpdateProgressFill(float value)
    // {
    //      value;
    // } 


    private void OnAfterStateChanged(GameState newState)
    {
        switch (newState)
        {
            case GameState.InGame:
                InitGame();
                fullDistance = GetDistance();
                break;
            case GameState.Fail:

                failPanel.SetActive(true);
                break;
            case GameState.Success:
                LevelComplatedPanel.SetActive(true);
                break;
            case GameState.Final:
                break;

        }
    }

}

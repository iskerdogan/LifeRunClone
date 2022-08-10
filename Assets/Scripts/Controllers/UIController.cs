// using System;
// using System.Collections;
// using System.Collections.Generic;
// using TMPro;
// using UnityEngine;
// using Utilities;

// public class UIController : Singleton<UIController>
// {
//     [SerializeField]
//     private GameObject swipeToMove;

//     [SerializeField]
//     private GameObject startPanel;

//     [SerializeField]
//     private GameObject failPanel;

//     [SerializeField]
//     private GameObject LevelComplatedPanel;

//     [SerializeField]
//     private TextMeshPro priceTagText;

//     [SerializeField]
//     private TextMeshProUGUI MoneyText;

//     [SerializeField]
//     private TextMeshProUGUI levelText;

//     [SerializeField]
//     private TextMeshProUGUI popUpText;


//     void Start()
//     {
//         InputSystem.Instance.TouchPositionChanged += OnTouchPositionChanged;
//         GameManager.OnAfterStateChanged += OnAfterStateChanged;
//         PlayerController.Instance.ChangePrice += OnChangePrice;
//         MovementController.Instance.MultiplicationIsComplete += OnMultiplicationIsComplete;

//     }


//     private void InitGame()
//     {
//         InputSystem.Instance.TouchPositionChanged += OnTouchPositionChanged;
//         GameManager.OnAfterStateChanged += OnAfterStateChanged;

//         startPanel.SetActive(true);
//         failPanel.SetActive(false);
//         LevelComplatedPanel.SetActive(false);
//         priceTagText.text = 0 + "$";
//         MoneyText.text = PlayerPrefs.GetInt("Money").ToString();
//         SwipeToMove();
//         GetCurrentLevel();
//     }

//     private void GetCurrentLevel()
//     {
//         levelText.text = "Level " + (SaveManager.Instance.CurrentLevel + 1).ToString();
//     }

//     private void SwipeToMove()
//     {
//         // swipeToMove.transform.LeanMoveLocalX(-270f, 0.5f).setOnComplete(() => swipeToMove.transform.LeanMoveLocalX(270f, 0.5f).setLoopPingPong());
//     }
//     private void OnTouchPositionChanged(Touch touch)
//     {
//         if (touch.phase != TouchPhase.Began) return;
//         startPanel.SetActive(false);
//         InputSystem.Instance.TouchPositionChanged -= OnTouchPositionChanged;
//         // LeanTween.delayedCall(.5f, () => GameManager.Instance.ChangeGameState(GameState.InGame));
//         GameManager.Instance.ChangeGameState(GameState.InGame);

//     }
//     private void OnChangePrice()
//     {
//         if (PlayerController.Instance.CurrentPrice < 0)
//         {
//             priceTagText.text = 0 + "$";
//         }
//         else
//         {
//             priceTagText.text = PlayerController.Instance.CurrentPrice.ToString() + "$";
//         }
//     }

//     private void OnChangeMoney()
//     {
//        MoneyText.text = PlayerPrefs.GetInt("Money").ToString();
//     }

//     public void PopUp()
//     {
//         if ((SaveManager.Instance.CurrentLevel + 1) == 1) popUpText.text = "+" + PlayerPrefs.GetInt("Money").ToString();
        
//         popUpText.text = "+" + PlayerController.Instance.TempMoney.ToString();
//         // LeanTween.moveLocalY(popUpText.gameObject, 855.5f, .5f).setOnComplete(() => LeanTween.delayedCall(.5f, () => LeanTween.moveLocalY(popUpText.gameObject, 929.599976f, 0)));
        
//     }

//     private void OnMultiplicationIsComplete()
//     {
//         OnChangeMoney();
//         PopUp();
//         // LeanTween.delayedCall(1f,()=>GameManager.Instance.ChangeGameState(GameState.Success));
//     }

//     private void OnAfterStateChanged(GameState newState)
//     {
//         switch (newState)
//         {
//             case GameState.Start:
//                 // LeanTween.cancelAll();
//                 InitGame();
//                 break;
//             case GameState.Fail:
//                 failPanel.SetActive(true);
//                 break;
//             case GameState.Success:
//                 LevelComplatedPanel.SetActive(true);
//                 break;
//             case GameState.Final:
//                 break;

//         }
//     }

// }

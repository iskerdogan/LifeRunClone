using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField]
    private Transform eggTransform;

    private int tempSpermCount;
    private float timeLeft = .4f;

    private void Start()
    {
        GameManager.OnAfterStateChanged += OnAfterStateChanged;
    }

    private void Update()
    {
        if (GameManager.Instance.State != GameState.Final) return;
        timeLeft-=Time.deltaTime;
        if (timeLeft <= 0.0f)
        {
            MoveFinal();
            timeLeft = .4f;
        }
    }

    private void MoveFinal()
    {
        var temp = SpermController.Instance.ActiveSperms[tempSpermCount-1].gameObject.transform.position;
        LeanTween.move(SpermController.Instance.ActiveSperms[tempSpermCount-1].gameObject, eggTransform.position, .3f).setOnComplete(() =>
        {
            SpermController.Instance.ActiveSperms[tempSpermCount-1].gameObject.SetActive(false);
            SpermController.Instance.ActiveSperms[tempSpermCount-1].gameObject.transform.position = temp;
            if (tempSpermCount!=0)
            {
                SpermController.Instance.Remove(SpermController.Instance.ActiveSperms[tempSpermCount-1]);
                tempSpermCount--;
            }
            if (tempSpermCount == 0 && SpermController.Instance.IsSuccess)
            {
                GameManager.Instance.ChangeGameState(GameState.Success);
            } 
            else if (tempSpermCount == 0 && !SpermController.Instance.IsSuccess)
            {
                GameManager.Instance.ChangeGameState(GameState.Fail);
            } 
        });
    }

    private void OnAfterStateChanged(GameState newState)
    {
        switch (newState)
        {
            case GameState.Final:
                tempSpermCount = SpermController.Instance.CurrentSpermCount;
                break;
        }
    }
}

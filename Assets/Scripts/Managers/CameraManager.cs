using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using Utilities;

public class CameraManager : Singleton<CameraManager>
{
    // [SerializeField]
    // private CinemachineVirtualCamera startCam;

    [SerializeField]
    private CinemachineVirtualCamera FinishCam;

    public CinemachineVirtualCamera inGameCam;


    void Start()
    {
        GameManager.OnAfterStateChanged += OnAfterStateChanged;
    }

    private void OnAfterStateChanged(GameState newState)
    {
        switch (newState)
        {
            case GameState.Start:
                inGameCam.Priority = 9;
                FinishCam.Priority =7;
                break;
            case GameState.Final:
                FinishCam.Priority =11;
                inGameCam.Priority = 7;
                break;
        }
    }
}

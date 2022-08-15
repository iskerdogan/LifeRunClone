using System;
using System.Collections;
using System.Collections.Generic;
using PathCreation;
using PathCreation.Examples;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utilities;

public class MovementController : Singleton<MovementController>
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float sideSpeed;

    private float currentSpeed;
    private float currentSideSpeed;

    private void Awake() 
    {
        currentSpeed = speed;
        currentSideSpeed = sideSpeed;
    }

    private void Start()
    {
        InputSystem.Instance.TouchPositionChanged += OnTouchPositionChanged;
        GameManager.OnAfterStateChanged += OnAfterStateChanged;

        // finalPlatform.SetActive(false);
        // showroom = finalPlatform.transform.GetChild(0).gameObject;
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(0, 0, currentSpeed * Time.deltaTime);
    }
    //Path Creator Movement
    // private void FixedUpdate()
    // {
    //     float sideInput = InputSystem.Instance.SideInput;
    //     sideMove = Mathf.Clamp(sideMove + sideInput * Time.deltaTime * sideSpeed, -(Road.roadWidth - .3f), (Road.roadWidth - .3f));
    //     DistanceTravelled += Time.deltaTime * speed;
    //     transform.position = Path.path.GetPointAtDistance(DistanceTravelled) + transform.right * sideMove + (Vector3.up / 2);
    //     transform.rotation = Path.path.GetRotationAtDistance(DistanceTravelled);
    //     transform.eulerAngles = new Vector3
    //     (
    //         transform.eulerAngles.x,
    //         transform.eulerAngles.y,
    //         transform.eulerAngles.z + 90
    //     );
    // }


    // private void MoveFinalPlatform()
    // {
    //     LeanTween.move(gameObject, new Vector3(0, 0, showroom.transform.position.z), .5f).setOnComplete(() => CameraManager.Instance.inGameCam.Priority = 13);
    //     LeanTween.delayedCall(1f, () => PositionByMultiplier());
    // }

    // private void PositionByMultiplier()
    // {
    //     showroom.transform.parent = transform;
    //     showroom.transform.position = transform.position;
    //     LeanTween.moveY(gameObject, multipliers[PlayerController.Instance.PlayerCurrentLevel].transform.position.y, (PlayerController.Instance.PlayerCurrentLevel + 1) / 2).setOnComplete
    //     (
    //         () =>
    //         {
    //             LeanTween.delayedCall(.1f, () => LeanTween.moveLocalZ(multipliers[PlayerController.Instance.PlayerCurrentLevel].transform.GetChild(0).gameObject, -6, .5f).setOnComplete
    //             (
    //                 () => LeanTween.moveLocalZ(multipliers[PlayerController.Instance.PlayerCurrentLevel].transform.GetChild(0).gameObject, -0.05000305f, .5f).setOnComplete
    //                 (
    //                     () =>
    //                     {
    //                         MultiplicationIsComplete?.Invoke();
    //                     }
    //                 )
    //             ));

    //         }
    //     );
    // }

    private void OnTouchPositionChanged(Touch touch)
    {
        if (GameManager.Instance.State != GameState.InGame) return;
        var target = new Vector3
        (
            Mathf.Clamp(transform.position.x + currentSideSpeed * Time.deltaTime * touch.deltaPosition.x, -2.361f, 2.361f), transform.position.y, transform.position.z
        );
        transform.position = Vector3.Lerp(transform.position, target, 0.125f);


    }

    private void OnAfterStateChanged(GameState newState)
    {
        switch (newState)
        {
            case GameState.InGame:
                transform.position = Vector3.zero;
                currentSpeed = speed;
                currentSideSpeed = sideSpeed;
                break;
            case GameState.Success:
                currentSpeed = 0;
                currentSideSpeed = 0;
                break;
            case GameState.Final:
                currentSpeed = 0;
                currentSideSpeed = 0;
                break;
            case GameState.Fail:
                currentSpeed = 0;
                currentSideSpeed = 0;
                break;
        }
    }

}

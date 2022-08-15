using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{  
    private Vector3 offset;
    private Vector3 finalOffset;

    private Transform player;

    void Start()
    {
        player = MovementController.Instance.transform;
        offset = transform.position-player.position;    
    }


    private void LateUpdate() 
    {
        // if (GameManager.Instance.State == GameState.Final)
        // {
        //     transform.position = new Vector3(0, player.position.y + offset.y, player.position.z + offset.z);
        // }
        transform.position = new Vector3(0, player.position.y + offset.y, player.position.z + offset.z);
    } 
    // private void LateUpdate() 
    // {
        
    //     transform.LookAt(MovementController.Instance.Path.path.GetPointAtDistance(MovementController.Instance.DistanceTravelled + 2) + Vector3.up *1.5f);
    // }
    

}

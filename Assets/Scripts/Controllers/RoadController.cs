using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class RoadController : Singleton<RoadController>
{
    [SerializeField]
    public GameObject FinisPlatform;

    public void FinishPlatformPosition(float zPosition)
    {
        FinisPlatform.SetActive(true);
        FinisPlatform.transform.position = new Vector3(0, 0, zPosition - 4);
    }
}

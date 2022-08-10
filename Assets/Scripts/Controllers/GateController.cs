using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    [SerializeField]
    private Material red;
    
    [SerializeField]
    private Material blue;

    [SerializeField]
    private Gate gate1;

    [SerializeField]
    private Gate gate2;

    public Material Red => red;

    public Material Blue => blue;

    public void CloseGates()
    {
        gate1.gameObject.GetComponent<BoxCollider>().enabled = false; 
        gate2.gameObject.GetComponent<BoxCollider>().enabled = false; 
    }
}

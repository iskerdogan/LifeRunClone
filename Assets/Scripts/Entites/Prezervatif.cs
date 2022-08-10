using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prezervatif : MonoBehaviour, ICollectable
{
    [SerializeField]
    private GameObject prezervatifSmall;
    [SerializeField]
    private GameObject prezervatifBig;

    private void Start() 
    {
        prezervatifSmall.gameObject.SetActive(true);
        prezervatifBig.gameObject.SetActive(false);
    }
    public void Collect()
    {
        prezervatifSmall.gameObject.SetActive(false);
        prezervatifBig.gameObject.SetActive(true);
    }
}

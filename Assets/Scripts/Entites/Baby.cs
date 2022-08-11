using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baby : MonoBehaviour,ICollectable
{
    [SerializeField]
    private GameObject embryoBaby;

    [SerializeField]
    private GameObject baby;

    private void Start() 
    {
        embryoBaby.gameObject.SetActive(true);
        baby.gameObject.SetActive(false);
    }
    public void Collect()
    {
        embryoBaby.gameObject.SetActive(false);
        baby.gameObject.SetActive(true);
    }
}

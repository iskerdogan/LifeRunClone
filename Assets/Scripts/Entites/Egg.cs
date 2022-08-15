using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    private int counter;
    private float timer = 0f;
    private SkinnedMeshRenderer egg;
    private void Update() 
    {
        if (GameManager.Instance.State != GameState.Final) return;
        timer+=Time.deltaTime;
        if (timer<=100f)
        {
            timer = 0f;
        }    
    }

    private void Start() 
    {
        egg = gameObject.GetComponent<SkinnedMeshRenderer>();
        GameManager.OnAfterStateChanged += OnAfterStateChanged;
    }

    private void OnTriggerEnter(Collider other) 
    {
        var sperm = other.GetComponent<Sperm>();
        if (sperm != null)
        {
            counter++;
            if (counter == 2)
            {
                egg.SetBlendShapeWeight(0,100);
            }
            else if (counter == 4)
            {
                egg.SetBlendShapeWeight(1,100);
            }
            else if (counter == 8)
            {
                egg.SetBlendShapeWeight(2,100);
            }
            else if (counter == 12)
            {
                egg.SetBlendShapeWeight(3,100);
            }
            else if (counter == 16)
            {
                egg.SetBlendShapeWeight(4,100);
            }
            else if (counter == 20)
            {
                egg.SetBlendShapeWeight(5,Mathf.Lerp(0,100,1f));
            }
        }

    }

    private void OnAfterStateChanged(GameState newState)
    {
        switch (newState)
        {
            case GameState.InGame:
                egg.SetBlendShapeWeight(0,0);
                egg.SetBlendShapeWeight(1,0);
                egg.SetBlendShapeWeight(2,0);
                egg.SetBlendShapeWeight(3,0);
                egg.SetBlendShapeWeight(4,0);
                egg.SetBlendShapeWeight(5,0);
                counter = 0;
            break;
        }
    }
}

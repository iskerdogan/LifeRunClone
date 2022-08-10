using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeObstacle : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private float turnSpeed;

    private Vector3 posA;
    private Vector3 posB;
    private Vector3 nextPos;

    [SerializeField]
    private Transform childTransform;

    [SerializeField]
    private Transform transformB;

    private void Start() 
    {
        posA = childTransform.localPosition;
        posB = transformB.localPosition;
        nextPos = posB;
    }
    private void Update() 
    {
        childTransform.Rotate(-Vector3.forward * turnSpeed * Time.deltaTime);
        Move();
    }

    private void Move()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.transform.localPosition,nextPos,speed*Time.deltaTime);
        if (Vector3.Distance(childTransform.localPosition,nextPos)<= 0.1)
        {
            ChangeDestionation();
        }
    }
    private void ChangeDestionation()
    {
        nextPos = nextPos != posA ? posA : posB;
    }
}

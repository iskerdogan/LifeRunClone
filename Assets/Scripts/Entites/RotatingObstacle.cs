using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObstacle : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private void FixedUpdate() 
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }

}

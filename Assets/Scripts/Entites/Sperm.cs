using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sperm : MonoBehaviour
{
    private Transform target;
    private void OnTriggerEnter(Collider other) 
    {
        var obstacle = other.GetComponent<Obstacle>();
        if (obstacle != null)
        {
            // gameObject.SetActive(false);
            // LeanTween.delayedCall(.3f,()=>);
            SpermController.Instance.Remove(this);
        }
        var prezervatif = other.GetComponent<Prezervatif>();
        if (prezervatif != null)
        {
            // gameObject.SetActive(false);
            // LeanTween.delayedCall(.3f,()=>);
            SpermController.Instance.Remove(this);
            prezervatif.Collect();
        }
        var rotatingObstacle = other.GetComponent<RotatingObstacle>();
        if (rotatingObstacle != null)
        {
            // gameObject.SetActive(false);
            // LeanTween.delayedCall(.3f,()=>);
            SpermController.Instance.Remove(this);
        }
        var knifeObstacle = other.GetComponent<KnifeObstacle>();
        if (knifeObstacle != null)
        {
            // gameObject.SetActive(false);
            // LeanTween.delayedCall(.3f,()=>);
            SpermController.Instance.Remove(this);
        }
            
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
        transform.SetParent(target);
        LeanTween.cancel(gameObject);
        LeanTween.moveLocal(gameObject,Vector3.zero,.3f);
    }

}

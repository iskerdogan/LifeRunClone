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
            SpermController.Instance.Remove(this);
            prezervatif.Collect();
        }
        var rotatingObstacle = other.GetComponent<RotatingObstacle>();
        if (rotatingObstacle != null)
        {
            SpermController.Instance.Remove(this);
        }
        var knifeObstacle = other.GetComponent<KnifeObstacle>();
        if (knifeObstacle != null)
        {
            SpermController.Instance.Remove(this);
        }
        var baby = other.GetComponent<Baby>();
        if (baby != null)
        {
            baby.Collect();
            var temp = gameObject.transform.position;
            baby.GetComponent<BoxCollider>().enabled = false;
            LeanTween.move(this.gameObject,baby.transform.position,.3f).setOnComplete(()=>{gameObject.SetActive(false); transform.position = temp;SpermController.Instance.Remove(this);});
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

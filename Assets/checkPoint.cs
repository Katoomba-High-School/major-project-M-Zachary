using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour
{

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Controller.gameNumber < 4)
        {
            if (way.Que[0] == this.name)
            {
                Vector3 directionToTarget = transform.position - target.position;


                float angle = Vector3.Angle(target.forward, directionToTarget);
                float dotProduct = Vector3.Dot(target.right, directionToTarget);

                if (dotProduct > 0)
                {
                    angle = -angle;
                }

                Arrow.angle = angle;

            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player")
        {
           if (way.Que[0] == this.name)
            {
                Debug.Log("hit");
               

                way.Que.RemoveAt(0);
                Destroy(this.gameObject);
            }
            
        }
    }
}

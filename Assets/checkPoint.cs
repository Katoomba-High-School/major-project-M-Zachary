using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

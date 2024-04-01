using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTL : MonoBehaviour
{
    // Start is called before the first frame update\

    float tickTimer = 0f;
    public float time;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tickTimer += Time.deltaTime;
     
        if (tickTimer >= time && gameObject.name != "DriftEffect")
        {
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{

    public GameObject finish;
    // Start is called before the first frame update
    void Start()
    {
        finish.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (way.Que.Count == 1)
        {
            finish.SetActive(true);
        }
        else
        {
            finish.SetActive(false);
        }

    }
}

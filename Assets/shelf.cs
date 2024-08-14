using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class shelf : MonoBehaviour
{
    public GameObject item;
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (Random.Range(0f, 100.0f) > 50f)
            {
                Transform Go = transform.GetChild(i);


                GameObject Object = Instantiate(item, Go.position, Quaternion.identity);
                Object.transform.rotation = Quaternion.Euler(-90, 0, 0);

                Object.transform.localScale *= Random.Range(0.5f, 1.2f);
                Object.transform.position = Go.position;

                var cubeRenderer = Object.GetComponent<Renderer>();
                cubeRenderer.material.SetColor("_Color", Random.ColorHSV());
            }
            
            
            
        }
    }


}
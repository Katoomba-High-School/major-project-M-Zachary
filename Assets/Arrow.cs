using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class Arrow : MonoBehaviour
{

    public static float angle = 0f;



    // Update is called once per frame
    void Update()
    {

        transform.localRotation = Quaternion.Euler(0f, 0f, angle + 90f);
    }
}

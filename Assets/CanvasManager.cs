using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerObject;
    [SerializeField] TextMeshProUGUI timerObject2;
    public static int driftTime = 0;
    public static bool drifting = false;
    public static float speed = 0f;

    public static int checkPoints = 0;

    private float timer = 0f;

    [SerializeField] Image arrowObject;
    public float maxSpeed;

    // Update is called once per frame
    void Update()
    {
        float speedConverted = (float)(Math.Abs(speed * 3.6));
        float angle = (speedConverted* (180 / maxSpeed));
        
        angle = 90 - angle;

        timer += Time.deltaTime;


        // Debug.Log(checkPoints);

        arrowObject.rectTransform.localEulerAngles = new Vector3(0, 0, angle);

        timerObject.text = driftTime.ToString() + " S";
        timerObject2.text = driftTime.ToString() + " S";
        if (timer >= 1f && drifting == true)
        {
            CanvasManager.driftTime += 1;
            CanvasManager.drifting = false;
            timer = 0f;
        }
    }
}

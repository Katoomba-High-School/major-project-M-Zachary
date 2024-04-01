using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerObject;
    public static int driftTime = 0;
    public static bool drifting = false;
    public static float speed = 0f;
    private float timer = 0f;
    [SerializeField] TextMeshProUGUI speedObject;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        speedObject.text = Math.Round(Math.Abs(speed * 3.6)).ToString() + " km/h";
        timerObject.text = driftTime.ToString() + " Seconds";
        if (timer >= 1f && drifting == true)
        {
            CanvasManager.driftTime += 1;
            CanvasManager.drifting = false;
            timer = 0f;
        }
    }
}

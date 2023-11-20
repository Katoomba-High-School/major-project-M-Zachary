using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerObject;
    public static int driftTime = 0;
    public static bool drifting = false;
    private float timer = 0f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        timerObject.text = driftTime.ToString();
        if (timer >= 1f && drifting == true)
        {
            CanvasManager.driftTime += 1;
            CanvasManager.drifting = false;
            timer = 0f;
        }
    }
}

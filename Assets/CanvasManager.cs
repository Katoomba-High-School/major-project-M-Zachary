using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerObject;
    [SerializeField] TextMeshProUGUI timerObject2;
 
    public static double driftTime = 0;
    public static double driftTime2 = 0;
    public static int score = 0;
    public static bool drifting = false;
    public static float speed = 0f;

    public static int checkPoints = 0;

    private float timer = 0f;
    private float timer2 = 0f;

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

        if (driftTime2 == 0 || driftTime == 0)
        {
            score = 0;
        }
        else
        {
            score = (int)Math.Round(((driftTime2 / driftTime) * 100));
        }
        

        timerObject.text = "Score " + score.ToString();
       
        timerObject2.text = "Score " + score.ToString();
      
        


        if (drifting)
        {
            timer2 += Time.deltaTime;
            drifting = false;
        }
        else
        {
            driftTime2 += Math.Round(timer2, 2);
            timer2 = 0;
        }
        

        if (Controller.gameNumber < 3)
        {
            timer = 0f;
        }

        if (CanvasManager.driftTime != Math.Round(timer, 2) && Controller.gameNumber == 3)
        {
            CanvasManager.driftTime = Math.Round(timer, 2);
        }
            
    }
}

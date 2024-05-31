using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class car : MonoBehaviour
{
    public float strength;
    public float damping;
    public float length;
    public float Frontgrip;
    public float Backgrip;
    public bool FrontWheelDrive;
    public float turnAngle;
    public Transform self;
    public static float HorizontalV = 0;

    public void Awake()
    {
        Application.targetFrameRate = 60;
    }

    public void Update()
    {

        Vector3 localVelocity = transform.InverseTransformDirection(self.GetComponent<Rigidbody>().velocity);
        car.HorizontalV = Math.Clamp(localVelocity.x * 4, -45, 45);

        //Debug.Log(HorizontalV);
        CanvasManager.speed = self.GetComponent<Rigidbody>().velocity.magnitude;


        if (self.position.y < -5)
        {
            self.position = new Vector3(0, 3, 0);
        }
    }

}

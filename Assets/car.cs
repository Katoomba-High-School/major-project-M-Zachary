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


    public void Update()
    {
    
        CanvasManager.speed = self.GetComponent<Rigidbody>().velocity.magnitude;


        if (self.position.y < -5)
        {
            self.position = new Vector3(0, 3, 0);
        }
    }

}

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
    private AudioSource sourceCar;
    [SerializeField] private AudioClip clipCar;
    private bool drift = false;
    private float timer;

    private AudioSource sourceWheel;
    [SerializeField] private AudioClip clipWheel;

    private void Start()
    {
        sourceCar = gameObject.AddComponent<AudioSource>();

        sourceCar.clip = clipCar;

        sourceWheel = gameObject.AddComponent<AudioSource>();

        sourceWheel.clip = clipWheel;
    }

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
        float speedConverted = (float)(Math.Abs(CanvasManager.speed * 3.6));
        float vol = speedConverted / 60;
        
        if (CanvasManager.drifting)
        {
            drift = true;
            timer = 0f;
        }
        else
        {
            timer += Time.deltaTime;
        }

        if (timer > 0.1f)
        {
            drift = false;
        }
        
        if (Input.GetKey("w") || Input.GetAxis("Fire1") == 1)
        {
            sourceCar.volume = vol/2;
            
        }
        else
        {
            sourceCar.volume = vol/3;
            
        }
        if (sourceCar.volume < 0.1f)
        {
            sourceCar.volume = 0.1f;
        }

        if (!sourceCar.isPlaying)
        {

            sourceCar.PlayScheduled(1f);
        }

        sourceWheel.volume = 0;
        if (drift == true)
        {
            sourceWheel.volume = 0.5f;



        } else
        {
            if (sourceWheel.volume > 0)
            {
                sourceWheel.volume -= 0.01f;
            }
            else
            {
                sourceWheel.volume = 0;
            }
        }

        if (!sourceWheel.isPlaying)
        {

            sourceWheel.PlayScheduled(1f);
        }


        if (self.position.y < -5)
        {
            self.position = new Vector3(0, 3, 0);
        }
    }

}

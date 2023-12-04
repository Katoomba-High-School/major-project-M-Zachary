using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.InputSystem;
public class wheels : MonoBehaviour
{
    GameObject parentGameObject;
    Rigidbody parentRigidbody;

    GameObject childGameObject;

    [SerializeField] private AnimationCurve curve;
    float strength;
    float damping;
    float length;
    float grip;
    float accInput = 0f;
    string driveType;
    float turnAngle;


    void Start()
    {
        parentGameObject = transform.parent.gameObject;
        childGameObject = transform.GetChild(0).gameObject;

        car parentScript = parentGameObject.GetComponent<car>();

        strength = parentScript.strength;
        damping = parentScript.damping;
        length = parentScript.length;
        turnAngle = parentScript.turnAngle;
        if (gameObject.tag == "FrontWheel")
        {
            grip = parentScript.Frontgrip;
        }
        else
        {
            grip = parentScript.Backgrip;
        }
        parentRigidbody = parentGameObject.GetComponent<Rigidbody>();

        if (parentScript.FrontWheelDrive == true)
        {
            driveType = "FrontWheel";
        }
        else
        {
            driveType = "BackWheel";
        }

    }

    void drift(float a, Ray ray, RaycastHit h)
    {
        if (Math.Abs(a) > 50)
        {
            childGameObject.GetComponent<TrailRenderer>().emitting = true;
            CanvasManager.drifting = true;
          
        }
        else
        {
            childGameObject.GetComponent<TrailRenderer>().emitting = false;
        }
    }



    void springForce(RaycastHit h)
    {
        childGameObject.transform.position = h.point + new Vector3(0, 0.25f, 0);

        Vector3 springDir = transform.up;
        Vector3 wheelVel = parentRigidbody.GetPointVelocity(transform.position);
        float offset = length - h.distance;
        float vel = Vector3.Dot(springDir, wheelVel);
        float force = (offset * strength) - (vel * damping);

        parentRigidbody.AddForceAtPosition(springDir * force, transform.position);
    }



    void sideForce(Ray ray, RaycastHit h)
    {
        Vector3 steeringDir = transform.right;
        Vector3 wheelVel = parentRigidbody.GetPointVelocity(transform.position);
        float steeringVel = Vector3.Dot(steeringDir, wheelVel);

        float velChange = -steeringVel * grip;

        float acceleration = velChange / Time.deltaTime;

        parentRigidbody.AddForceAtPosition(steeringDir * 25 * acceleration, transform.position);

        if (gameObject.tag == "BackWheel")
        {
            drift(acceleration, ray, h);
        }

        if (gameObject.tag == "FrontWheel")
        {

            var input = Input.GetAxis("Horizontal");

            transform.localEulerAngles = new Vector3(0, turnAngle * input, 0);

        }
    }



    void forwardForce()
    {
       
        if (Input.GetKey("w")  || Input.GetAxis("Fire1") == 1)
        {
            accInput = 1f;
        }
        else if (Input.GetKey("s") || Input.GetAxis("Fire2") == 1)
        {
            accInput = -1f;
        }
        else
        {
            accInput = 0f;
        }

        Vector3 accDir = transform.forward;
        Vector3 wheelVel = parentRigidbody.GetPointVelocity(transform.position);
        float forwardsVel = Vector3.Dot(accDir, wheelVel);
        float forwardsVelChange = -forwardsVel * grip;
        float accChange = forwardsVelChange / Time.deltaTime;

        parentRigidbody.AddForceAtPosition(accDir * accChange, transform.position);

        if (gameObject.tag == driveType)
        {
            if (accInput > 0f)
            {
                float carSpeed = Vector3.Dot(parentGameObject.transform.forward, parentRigidbody.velocity);
                // top speed
                float normalisedSpeed = Mathf.Clamp01(Mathf.Abs(carSpeed) / 10);

                float avaTor = (curve.Evaluate(normalisedSpeed) * accInput) * 50;

                parentRigidbody.AddForceAtPosition(accDir * 50 * avaTor, transform.position);

            }

            if (accInput < 0f)
            {
                float carSpeed = Vector3.Dot(parentGameObject.transform.forward, parentRigidbody.velocity);
                // top speed
                float normalisedSpeed = Mathf.Clamp01(Mathf.Abs(carSpeed) / -10);

                float avaTor = (curve.Evaluate(normalisedSpeed) * accInput) * 50;

                parentRigidbody.AddForceAtPosition(accDir * 50 * avaTor, transform.position);

            }

        }
    }



    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, length))
        {
            Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.down));
            springForce(hit);
            
            sideForce(ray, hit);

            forwardForce();

        }
        else
        {
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * length, Color.white);
            Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.down));
            childGameObject.transform.position = ray.GetPoint(length);
            childGameObject.GetComponent<TrailRenderer>().emitting = false;

        }

        

        
   
    }
}

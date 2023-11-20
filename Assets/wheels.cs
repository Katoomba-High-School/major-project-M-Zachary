using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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

    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, length))
        {
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.red);
            childGameObject.transform.position = hit.point + new Vector3(0, 0.25f, 0);

            Vector3 springDir = transform.up;
            Vector3 wheelVel = parentRigidbody.GetPointVelocity(transform.position);
            float offset = length - hit.distance;
            float vel = Vector3.Dot(springDir, wheelVel);
            float force = (offset * strength) - (vel * damping);

            parentRigidbody.AddForceAtPosition(springDir * force, transform.position);

            // side ways force

            Vector3 steeringDir = transform.right;
            float steeringVel = Vector3.Dot(steeringDir, wheelVel);

            float velChange = -steeringVel * grip;

            float acceleration = velChange / Time.deltaTime;

            //Debug.DrawRay(transform.position, steeringDir * (acceleration/50), Color.red);
            parentRigidbody.AddForceAtPosition(steeringDir * 25 * acceleration, transform.position);


            if (Math.Abs(acceleration) > 60)
            {
                childGameObject.GetComponent<TrailRenderer>().emitting = true;
                CanvasManager.drifting = true;
            }
            else
            {
                childGameObject.GetComponent<TrailRenderer>().emitting = false;
            }

            if (gameObject.tag == "FrontWheel")
            {
                
                if (Input.GetKey("a"))
                {
                    transform.localEulerAngles = new Vector3(0,-turnAngle, 0);
                }
                else if (Input.GetKey("d"))
                {
                    transform.localEulerAngles = new Vector3(0, turnAngle, 0);
                }
                else
                {
                    transform.localEulerAngles = new Vector3(0, 0, 0);
                }
            }

            //forwards force



            if (Input.GetKey("w"))
            {
                accInput = 1f;
            }
            else if (Input.GetKey("s"))
            {
                accInput = -1f;
            }
            else 
            {
                accInput = 0f;
            }

            Vector3 accDir = transform.forward;

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
        else
        {
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * length, Color.white);
            Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.down));
            childGameObject.transform.position = ray.GetPoint(length);
            childGameObject.GetComponent<TrailRenderer>().emitting = false;

        }

        

        
   
    }
}

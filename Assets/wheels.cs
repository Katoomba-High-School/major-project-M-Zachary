using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;


using UnityEngine.Animations;

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
    float TurningHelper;
    public GameObject driftSprite;

    public DecalsList DecalsList;

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

    void drift(float a, RaycastHit h)
    {
        if (Math.Abs(a) > 40)
        {

            CanvasManager.drifting = true;

            GameObject decalObject = Instantiate(driftSprite, h.point + (h.normal * 0.025f), Quaternion.identity) as GameObject;
            decalObject.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, (Math.Abs(a) * 2) / 255);
            decalObject.transform.rotation = Quaternion.FromToRotation(Vector3.up, h.normal);
            decalObject.transform.rotation = Quaternion.EulerAngles(new Vector3(1.5708f, 0, 0));
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



    void sideForce(RaycastHit h)
    {
        Vector3 steeringDir = transform.right;
        Vector3 wheelVel = parentRigidbody.GetPointVelocity(transform.position);
        float steeringVel = Vector3.Dot(steeringDir, wheelVel);

        float velChange = -steeringVel * grip;

        float acceleration = velChange / Time.deltaTime;

        parentRigidbody.AddForceAtPosition(steeringDir * 25 * acceleration, transform.position);

        if (gameObject.tag == "BackWheel")
        {
            drift(acceleration, h);
        }

        if (gameObject.tag == "FrontWheel")
        {
           

            var input = Input.GetAxis("Horizontal") * 0;
            if (Controller.gameNumber == 3)
            {
                input = Input.GetAxis("Horizontal");
            }


            drift(acceleration - (turnAngle * input), h);

            transform.localEulerAngles = new Vector3(0, (turnAngle * input) + car.HorizontalV, 0);

        }
    }



    void forwardForce()
    {
       
        if (Input.GetKey("w") || Input.GetAxis("Fire1") == 1)
        {
            if (Controller.gameNumber == 3)
            {
                accInput = 1f;
            }
        }
        else if (Input.GetKey("s") || Input.GetAxis("Fire2") == 1)
        {
                if (Controller.gameNumber == 3)
                {
                    accInput = -1f;
                }
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
           
            springForce(hit);
            
            sideForce(hit);

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheels : MonoBehaviour
{
    GameObject parentGameObject;
    Rigidbody parentRigidbody;

    GameObject childGameObject;

    float strength;
    float damping;
    float length;


    // Start is called before the first frame update
    void Start()
    {
        parentGameObject = transform.parent.gameObject;
        childGameObject = transform.GetChild(0).gameObject;

        car parentScript = parentGameObject.GetComponent<car>();

        strength = parentScript.strength;
        damping = parentScript.damping;
        length = parentScript.length;
        parentRigidbody = parentGameObject.GetComponent<Rigidbody>();
      
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, length))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.red);
            childGameObject.transform.position = hit.point + new Vector3(0, 0.25f, 0);

            Vector3 springDir = transform.up;
            Vector3 wheelVel = parentRigidbody.GetPointVelocity(transform.position);
            float offset = length - hit.distance;
            float vel = Vector3.Dot(springDir, wheelVel);
            float force = (offset * strength) - (vel * damping);

            parentRigidbody.AddForceAtPosition(springDir * force, transform.position);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * length, Color.white);
            Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.down));
            childGameObject.transform.position = ray.GetPoint(length);
        }

        
   
    }
}

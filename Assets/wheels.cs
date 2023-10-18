using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wheels : MonoBehaviour
{
    public GameObject body;
    Rigidbody car;
    int strength = 100;
    int damping = 15;

    // Start is called before the first frame update
    void Start()
    {
        car = body.GetComponent<Rigidbody>();
      
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 1))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.red);

            Vector3 springDir = transform.up;
            Vector3 wheelVel = car.GetPointVelocity(transform.position);
            float offset = 1 - hit.distance;
            float vel = Vector3.Dot(springDir, wheelVel);
            float force = (offset * strength) - (vel * damping);

            car.AddForceAtPosition(springDir * force, transform.position);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down), Color.white);
        }

    }
}

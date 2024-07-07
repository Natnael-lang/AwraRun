using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowController : MonoBehaviour
{
    private Rigidbody cowRigidbody; // Rigidbody component for the cow
    public float forwardSpeed; // speed of the cow

    void Start()
    {

        forwardSpeed = 17;
        // Get the Rigidbody component attached to the cow GameObject
        cowRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Calculate the forward movement vector based on the forward speed
        Vector3 movement = Vector3.forward * forwardSpeed * Time.deltaTime;

        // Apply the movement to the cow's position using Rigidbody's velocity
        cowRigidbody.MovePosition(transform.position + movement);
    }
}

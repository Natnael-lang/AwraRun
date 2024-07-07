using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target; // declaring a target for the main camera
    private Vector3 offset; // declaring the distance and angle difference between the camera and the target
    void Start()
    {
        offset = transform.position - target.position; // getting the value for the offset
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // declaring the new position for the main camera
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, offset.z + target.position.z); 
        transform.position = newPosition; // changing the position of the main camera to the new position
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{

    private CharacterController dogController;
    private Vector3 direction;
    public float dogSpeed;

    // Start is called before the first frame update
    void Start()
    {
        dogController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        dogController.Move(direction * Time.fixedDeltaTime);
        direction.z = dogSpeed;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class milk : MonoBehaviour
{
    // Start is called before the first frame update
    private int rotateSpeed = 2 ;
    public AudioSource milkSound;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,rotateSpeed,0,Space.World);
    }
    
     
    private void OnTriggerEnter(Collider other){

        milkSound.Play();
        Destroy(gameObject);
    }
}

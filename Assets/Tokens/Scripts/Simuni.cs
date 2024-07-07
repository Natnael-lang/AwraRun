using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simuni : MonoBehaviour
{
    // Start is called before the first frame update
    private int rotateSpeed = 2;
    public AudioSource coinSound;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,rotateSpeed,0,Space.World);
        
    }
    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player"))  // check if the player is the one who is collecting
        {
            PlayerController.numberOfCoins += 1;
            Debug.Log(PlayerController.numberOfCoins);
            coinSound.Play();
            Destroy(gameObject);
        }
    }
}

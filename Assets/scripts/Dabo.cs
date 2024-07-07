using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Food : MonoBehaviour
{

    public AudioSource foodAudio;
    public GameObject food;
    private int rotateSpeed = 90;


    private void OnTriggerEnter(Collider other)
    { 

        if (other.gameObject.CompareTag("Player"))
        {
            
            foodAudio.Play();
            Destroy(food);

            StartCoroutine(BoostPlayer());
            
        }
    }


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0, Space.World);
    }
    private IEnumerator BoostPlayer()
    {

        Player.playerSpeed *= 1.3f;
        yield return new WaitForSeconds(1.5f);
        Player.playerSpeed /= 1.3f;

    }


}

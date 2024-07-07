using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daborotate : MonoBehaviour
{
    // Start is called before the first frame update
    private int rotateSpeed = 2;
    public AudioSource daboSound;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,rotateSpeed,0,Space.World);
    }
    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player"))
        {
            PlayerController.numberOfDabo += 1;
            Debug.Log(PlayerController.numberOfDabo);
            StartCoroutine(DaboEffect());
            daboSound.Play();
            Destroy(gameObject);
        } 
    }

    public IEnumerator DaboEffect()
    {
        PlayerController.forwardSpeed += 0.4f;
        yield return new WaitForSeconds(0.1f);
        while (PlayerController.forwardSpeed > 10)
        {
            PlayerController.forwardSpeed -= 0.4f;
        }
    }
}

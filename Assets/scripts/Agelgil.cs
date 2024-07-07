using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Rotates the GameObject and decreases the countdown timer when the player collides with it.
/// </summary>
public class Agelgil : MonoBehaviour
{
    /// <summary>
    /// Rotation speed of the GameObject.
    /// </summary>
    private int rotateSpeed = 90;

    /// <summary>
    /// The audio source for the sound effect.
    /// </summary>
    public AudioSource agelgilSound;

    /// <summary>
    /// Update is called once per frame. Rotates the GameObject.
    /// </summary>
    void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0, Space.World);
    }

    /// <summary>
    /// Called when another Collider enters this GameObject's trigger collider.
    /// </summary>
    /// <param name="other">The Collider of the other GameObject.</param>
    private void OnTriggerEnter(Collider other)
    {
        // Check if the other GameObject is tagged as "Player"
        if (other.gameObject.CompareTag("Player"))
        {
            // Decrease the countdown timer by 5 seconds
            Timer.countDown -= 5;

            // Play the sound effect
            
            agelgilSound.Play();

            // Destroy this GameObject
            Destroy(gameObject);
        }


    }
}

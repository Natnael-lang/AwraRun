using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a collectible object in the game world, providing a penalty when collected.
/// </summary>
public class Enqfat : MonoBehaviour
{
/// <summary>
    /// The speed at which the Enqfat rotates (degrees per second).
    /// </summary>
    private int rotateSpeed = 90;
    /// <summary>
    /// The audio source that plays the sound effect when the Enqfat is collected.
    /// </summary>
    public AudioSource rockSound;
    


    // Update is called once per frame
    void Update()
    {
        /// <summary>
        /// Rotates the Enqfat around the Y-axis at the specified speed.
        /// </summary>
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            /// <summary>
            /// Increments the player's penalty by 15 seconds and destroys the Enqfat game object.
            /// Optionally, displays a penalty message on the UI if the penaltyText field is assigned.
            /// </summary>
            Timer.countDown += 15;
           // Play the sound effect if available
            rockSound.Play();

            // Destroy this GameObject
            Destroy(gameObject);
        }


    }
}

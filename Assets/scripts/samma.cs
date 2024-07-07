using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This class controls the behavior of a game object named "Samma".
/// </summary>
public class Samma : MonoBehaviour
{
    /// <summary>
    /// The speed (in degrees per second) at which the Samma object rotates around the Y-axis.
    /// </summary>
    private int rotateSpeed = 90 ;
    /// <summary>
    /// An audio source component that plays a sound effect when the Samma interacts with the player.
    /// </summary>
    public AudioSource sammaSound;
    /// <summary>
    /// A reference to the game object itself (used for potential destruction upon collision).
    /// </summary>
    public GameObject sama;
/// <summary>
    /// This method is called for every frame update.
    /// </summary>
    void Update()
    {
        /// <summary>
        /// Rotates the Samma object around the Y-axis at the specified rotateSpeed.
        /// </summary>
        transform.Rotate(0,rotateSpeed,0,Space.World);
    }
    /// <summary>
    /// This method is called when the Samma object collides with another object.
    /// </summary>
    /// <param name="other">The Collider component of the object the Samma collided with.</param>
    private void OnTriggerEnter(Collider other){
        /// <summary>
        /// Checks if the colliding object has the Player tag.
        /// </summary>
        if (other.gameObject.CompareTag("Player"))
        {
            /// <summary>
            /// Plays the sound effect associated with the Samma (uncommented if desired).
            /// </summary>
            sammaSound.Play();

            /// <summary>
            /// Destroys the Samma game object upon collision with the player.
            /// </summary>
            Destroy(sama);
            /// <summary>
            /// Starts a coroutine named SlowPlayer to temporarily slow down the player's movement.
            /// </summary>
            StartCoroutine(SlowPlayer());
        }
           
        
    }
    /// <summary>
    /// This coroutine temporarily slows down the player's movement speed.
    /// </summary>
    /// <returns>An IEnumerator object to allow for coroutine execution.</returns>
    private IEnumerator SlowPlayer()
    {
/// <summary>
        /// Reduces the player's speed by 40% (assuming Player.playerSpeed stores the movement speed).
        /// </summary>
        Player.playerSpeed *= 0.6f;
        /// <summary>
        /// Waits for 1.3 seconds before continuing.
        /// </summary>
        yield return new WaitForSeconds(1.3f);
        /// <summary>
        /// Resets the player's speed to its original value.
        /// </summary>
        Player.playerSpeed /= 0.6f;

    }
}

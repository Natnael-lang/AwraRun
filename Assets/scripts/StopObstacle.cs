using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

/// <summary>
/// This class represents an obstacle in the game that stops the player's movement upon collision.
/// </summary>
public class StopObstacle : MonoBehaviour
{
    /// <summary>
    /// A reference to the player's Animator component (cached in Start).
    /// </summary>
    private Animator playerAnimator;
    private void Start()
    {
        ///Find the player game object by tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            /// actual game character (with Animator) is a child of the player game object

            Transform character = player.transform.Find("boy eregna.fbx");
            /// Get the Animator component from the child object
            playerAnimator = character.GetComponent<Animator>();
        }
    }
/// <summary>
    /// This method is called when the StopObstacle collides with another object.
    /// </summary>
    /// <param name="other">The Collider component of the object the StopObstacle collided with.</param>
    private void OnTriggerEnter(Collider other)
    {
        /// <summary>
        /// Checks if the colliding object has the Player tag.
        /// </summary>
        if (other.gameObject.CompareTag("Player"))
        {
            /// Trigger stumble animation
            playerAnimator.Play("death");
            /// stop forward movement of player after collision
            Player.playerSpeed = 0;
        }

    }
}

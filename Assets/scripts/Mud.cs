using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class represents mud in the game world. When the player collides with mud,
/// their movement speed is temporarily reduced.
/// </summary>
public class Mud : MonoBehaviour
{

    /// <summary>
    /// Slowdown factor applied to the player's speed upon collision.
    /// </summary>
    [SerializeField] private float slowdownFactor = 0.5f;  // Editable from Inspector

    /// <summary>
    /// Duration (in seconds) for which the player's speed is slowed down.
    /// </summary>
    [SerializeField] private float slowdownDuration = 1.0f;  // Editable from Inspector
    private void OnTriggerEnter(Collider other)
    {
     
        if (other.gameObject.CompareTag("Player"))
        {
      
            StartCoroutine(HandleCollision());
        }
    }


    /// <summary>
    /// Handles player collision with the mud.
    /// </summary>
    /// <param name="player">The Player component of the colliding object.</param>
    private IEnumerator HandleCollision()
    {
       // Apply slowdown factor to player speed
        Player.playerSpeed *= slowdownFactor;

        // Wait for the slowdown duration
        yield return new WaitForSeconds(slowdownDuration);
        // Restore original player speed
        Player.playerSpeed /= slowdownFactor;
    }

}


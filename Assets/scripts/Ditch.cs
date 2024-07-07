using System.Collections;
using UnityEngine;

/// <summary>
/// Represents a ditch obstacle in the game world.
/// When the player collides with the ditch trigger collider,
/// the player stumbles over it, is briefly slowed down,
/// and then continues their movement.
/// </summary>
public class Ditch : MonoBehaviour
{
    /// <summary>
    /// Reference to the player's Animator component.
    /// This is used to play the stumbling animation when the player
    /// collides with the ditch.
    /// </summary>
    private Animator playerAnimator;

    private void Start()
    {
        /// Find the player game object by tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        /// actual game character (with Animator) is a child of the player game object
        Transform character = player.transform.Find("boy eregna.fbx");
        
        // Get the Animator component from the child object
        playerAnimator = character.GetComponent<Animator>();
    }
/// <summary>
    /// Called when a Collider enters the trigger collider attached to this GameObject.
    /// </summary>
    /// <param name="other">The Collider that entered the trigger.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            /// <summary>
            /// Moves the player over the ditch.
            /// </summary>
            Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
            other.gameObject.transform.position = targetPosition + Vector3.up * 2.6f;
            other.gameObject.transform.position += Vector3.forward * 1.5f;

            /// Reduce player speed 
            StartCoroutine(HandleCollision());
        }
    }
    /// <summary>
    /// Coroutine that handles the temporary player speed reduction after colliding with the ditch.
    /// </summary>
    private IEnumerator HandleCollision()
    {
       
        playerAnimator.Play("stumble");
        // Reduce the player speed
        Player.playerSpeed /= 5;
        yield return new WaitForSeconds(0.8f);
        // bring speed to normal value
        Player.playerSpeed *= 5;
    }
}

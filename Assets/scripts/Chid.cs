using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;


/// <summary>
/// Script for a child object that slows down the enemy (Chaser) upon collision with the player.
/// </summary>
public class Chid : MonoBehaviour
{
    /// <summary>
    /// Referance to an audio that will play on collision.
    /// </summary>
    public AudioSource chidAudio;
    /// <summary>
    /// Reference to the chid GameObject itself.
    /// </summary>
    public GameObject chid;

/// <summary>
  /// Speed at which the child object rotates (degrees per second).
  /// </summary>
    private int rotateSpeed = 90;

/// <summary>
  /// Called when another Collider enters this GameObject's trigger collider.
  /// Handles collision with the Player and slows down the Chaser enemy.
  /// </summary>
  /// <param name="other">The Collider of the other GameObject.</param>
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            //enables the AudioSource component.
            chidAudio.Play();
            //destroys the game object chid
            Destroy(chid);

            StartCoroutine(SlowChaser());

        }
    }


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0, Space.World);
    }

/// <summary>
  /// Coroutine that temporarily slows down the Chaser enemy upon collision with the child.
  /// </summary>
  /// <returns>Yields control after slowing down and then speeding up the Chaser.</returns>

    private IEnumerator SlowChaser()
    {

        Chaser1.chaserInitialSpeed *= 0.8f;
        yield return new WaitForSeconds(1.2f);
        Chaser1.chaserInitialSpeed /= 0.8f;

    }


}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;
//using UnityEngine.WSA;

/// <summary>
/// Script for a chasing enemy called "Chaser".
/// </summary>
public class Chaser1 : MonoBehaviour
{
    /// <summary>
    /// The initial speed of the Chaser.
    /// </summary>
    public static float chaserInitialSpeed;

    /// <summary>
    /// Reference to the GameObject of the Rancher character.
    /// </summary>
    public GameObject rancher;
    
    /// <summary>
    /// Animator component of the Player character.
    /// </summary>
    private Animator playerAnimator;
    
    /// <summary>
    /// The initial position of the Player character.
    /// </summary>
    private Vector3 playerTransform;
    
    /// <summary>
    /// CharacterController component of the Chaser.
    /// </summary>
    private CharacterController controler;
    
    /// <summary>
    /// The distance between lanes on the running path.
    /// </summary>
    public float laneDistance = 3;
    
    /// <summary>
    /// The Chaser's desired lane (0: Left, 1: Center, 2: Right).
    /// </summary>
    private int desiredLane = 1;
    
    /// <summary>
    /// CharacterController component of the Chaser.
    /// </summary>
    private CharacterController chaserControler;
    
    /// <summary>
    /// The current speed of the Chaser.
    /// </summary>
    public float chaserSpeed;
    
    /// <summary>
    /// Reference to the Player GameObject.
    /// </summary>
    public GameObject player;
    
    /// <summary>
    /// The distance between the Chaser and the Player.
    /// </summary>
    public float distance;

    public float chaserBaseSpeed;

    public AudioSource fail;

    /// <summary>
    /// Called when another Collider enters this GameObject's trigger collider.
    /// Stops the player and chaser movement and starts the finisher coroutine upon collision with the Player.
    /// </summary>
    /// <param name="other">The Collider of the other GameObject.</param>
    private void OnTriggerEnter(Collider other)
    {
    
        if (other.gameObject.CompareTag("Player"))
        {
            Player.playerSpeed = 0;
            chaserInitialSpeed = 0;
            
            PlayerManager1.gameStarted = false;

            StartCoroutine(finisher());
        }
    }

  /// <summary>
  /// Called on the first frame the script is active.
  /// Initializes references, animator, and starting speed.
  /// </summary>
    private void Start()
    {
        controler = GetComponent<CharacterController>();
        /// Find the player game object by tag
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        ///actual game character (with Animator) is a child of the player game object
        Transform character = player.transform.Find("boy eregna.fbx");

        /// Get the Animator component from the child object
        playerAnimator = character.GetComponent<Animator>();
        playerTransform = character.transform.position;

        chaserControler = GetComponent<CharacterController>();

        chaserInitialSpeed = 15;
        
    }
   
    // Update is called once per frame
    void Update()
    {
        if (PlayerManager1.gameOver || PlayerManager1.levelPassed || !PlayerManager1.gameStarted)
        {
            return;
        }

        /// Move the Chaser forward based on its speed
        transform.Translate(Vector3.forward * Time.deltaTime * chaserSpeed, Space.World);
/// Calculate the distance between the Rancher and the Player
        distance = Vector3.Distance(rancher.transform.position, player.transform.position);
 /// Adjust Chaser speed based on distance to Player
       if (distance > 13)
        {
            chaserSpeed = chaserBaseSpeed * 2 ;
        }
        else 
        {
            chaserSpeed = chaserBaseSpeed;
        }
        

    /// <summary>
    /// Handles side-to-side movement between lanes based on player input.
    /// </summary>
        if (SwipeManager.swipeRight)
        {
            desiredLane++;
            if (desiredLane == 3)
            {
                desiredLane = 2;
            }
        }
        if (SwipeManager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
            {
                desiredLane = 0;
            }
        }

/// Calculate target position based on desired lane
        Vector3 targetPostion = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desiredLane == 0)
        {
            targetPostion += Vector3.left * laneDistance;

        }
        else if (desiredLane == 2)
        {
            targetPostion += Vector3.right * laneDistance;
        }

/// Smoothly lerp the Chaser's position towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPostion, 30 * Time.fixedDeltaTime);
        /// Reset CharacterController center to maintain smooth movement
        controler.center = controler.center;

        if (Timer.countDown < 90 && Timer.countDown > 45)
        {
            chaserBaseSpeed = chaserInitialSpeed * 1.3f;
        }

        else if (Timer.countDown < 45)
        {
            chaserBaseSpeed = chaserInitialSpeed * 1.6f;
        }

        else
        {
            chaserBaseSpeed = chaserInitialSpeed;
        }

    }

/// <summary>
/// Coroutine that plays the finisher animation upon catching the Player.
/// </summary>
/// <returns>Yields control after the finisher animation sequence is complete.</returns>
    private IEnumerator finisher()
    {
        fail.Play();
        /// Play the "punch" animation on the Rancher
        rancher.GetComponent<Animator>().Play("punch");
/// Wait for 0.8 seconds after the punch animation
        yield return new WaitForSeconds(0.8f);
/// Play the "death" animation on the Player
        playerAnimator.Play("death");
/// Wait for 2 seconds after the death animation starts
        yield return new WaitForSeconds(2f);
/// Set the game over flag in PlayerManager
        PlayerManager1.gameOver = true;
       

    }

}

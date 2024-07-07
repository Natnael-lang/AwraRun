using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
/// <summary>
/// Controls the behavior of the player character.
/// </summary>
public class Player : MonoBehaviour
{
/// <summary>
    /// The CharacterController attached to the player.
    /// </summary>
    private CharacterController controler;
/// <summary>
    /// The running speed of the player.
    /// </summary>
    public static float playerSpeed;

  /// <summary>
    /// The current speed of the player.
    /// </summary>


    public float runSpeed;
/// <summary>
    /// The running direction of the player.
    /// </summary>
    public static Vector3 direction;
    
    /// <summary>
    /// :left 1:middle 2:right
    /// </summary>
   
    public int desiredLane = 1;

    ///width of each lane
    public float laneDistance = 3;

    /// Jumping force

    public float jumpForce = 10;
   
    ///Gravity force
    public float gravity = -20;

   /// The CapsuleCollider attached to the player.
    public CapsuleCollider colliderBox;
    /// Flag indicating if the player is currently sliding.
    private bool isSliding;
   /// Flag indicating if the player is on the ground.
    private bool onGround;
   /// Reference to the GameObject responsible for player animation.
    public GameObject gmo;


    public void Start()
    {
       
        ///set the player initial speed
        playerSpeed = 15;

        runSpeed = playerSpeed;

        controler = GetComponent<CharacterController>();
       
        colliderBox = GetComponent<CapsuleCollider>();

        isSliding = false;

    }


    public void Update()

    {

       if (PlayerManager1.gameOver || PlayerManager1.levelPassed || !PlayerManager1.gameStarted)
        {
            return;
        }


        direction.z = runSpeed;

        
        onGround = controler.isGrounded;

        ///Gravity pull
        direction.y += gravity * Time.deltaTime;

        ///Jump if uparrow is pressed and animate jump
        if (controler.isGrounded)
        {
           
            if (SwipeManager.swipeUp)
            {
             
                gmo.GetComponent<Animator>().Play("jump");
             
                Jump();
            }


        }
        
        ///slide if down arrow is pressed   and animate slide  
        
        if (SwipeManager.swipeDown)
        {
           
            isSliding = true;
            gmo.GetComponent<Animator>().Play("slide");
            StartCoroutine(Slide());
       
        }


       
       
        if (SwipeManager.swipeRight)
        {
            desiredLane++;
          
            if (desiredLane == 3)
            {
                desiredLane = 2;
            }
        }
        
            /// Handles side-to-side movement between lanes based on player input.
        if (SwipeManager.swipeLeft)
        {
            desiredLane--;

            if (desiredLane == -1)
            {
                desiredLane = 0;
            }
        }

        /// Handles side-to-side movement between lanes based on player input.
        Vector3 targetPostion = transform.position.z * transform.forward + transform.position.y * transform.up;
        
        if (desiredLane == 0)
        {
           
            targetPostion += Vector3.left * laneDistance;

        }
       
        else if (desiredLane == 2)
        {
            
            targetPostion += Vector3.right * laneDistance;
        }
        ///transformation to the target lane smoothly using Lerp function
        transform.position = Vector3.Lerp(transform.position, targetPostion, 30 * Time.deltaTime);
        ///stabilize the transition
        controler.center = controler.center;

        if (Timer.countDown < 90 && Timer.countDown > 45)
        {
            runSpeed = playerSpeed * 1.3f;
        }
    
        else if (Timer.countDown < 45)
        {
            runSpeed = playerSpeed * 1.6f;
        }
        else
        {
            runSpeed = playerSpeed;
        }
    }


    public void FixedUpdate()
    {
        if (PlayerManager1.gameOver || PlayerManager1.levelPassed || !PlayerManager1.gameStarted)
        {
            return;

        }

        controler.Move(direction * Time.deltaTime);

    }
    /// <summary>
    /// implement the jump method
    /// </summary>
    public void Jump()
    {
        direction.y = jumpForce;

    }
    /// <summary>
    /// make the gamee controller height smaller for the player to slide,after 0.8f bring it to normal
    /// </summary>
    /// <returns></returns>
    public IEnumerator Slide()
    {
       
        
        controler.center = new Vector3(0, -0.5f, 0);
        controler.height = 0.75f;
        /// Wait for a delay
        yield return new WaitForSeconds(0.8f); // Adjust the delay time as needed
        /// return the controler back to its original orientation
        controler.center = new Vector3(0, 0, 0);
        controler.height = 2;
        isSliding = false;

    }


}
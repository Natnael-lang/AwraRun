using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private CharacterController controller; // playercontroller
    private Vector3 direction; // direction of the player
    public static float forwardSpeed; // speed of the player
    public float Speed;

    private int desiredLane = 1; // 0 = left lane, 1 = middle lane, 2 = right lane
    public float laneDistance = 2.5f; // distance between two lanes

    public float jumpForce; // declaring the jumping power
    public float GRAVITY = -10; // declaring value for gravity
    public GameObject myPlayer;

    // yishak
    public static int numberOfCoins;
    public static int numberOfDabo;
    public static int timeChange;

    // ....... nati
    private Vector3 lastPosition;
    private bool isRunning = false;
    private Chaser chaser;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        forwardSpeed = 8;

        // yishak
        numberOfCoins = 0;
        numberOfDabo = 0;
        timeChange = 0;

        // .... nati
        // Get reference to the Chaser script attached to the chaser object
        chaser = GameObject.FindObjectOfType<Chaser>();

        // Record the initial position of the player
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        Speed = forwardSpeed;

        controller.Move(direction * Time.deltaTime); // moving the player in the specified direction
        direction.z = forwardSpeed; // to move the player in the forward direction with speed of forward speed
        Jump();
        ChangeLane();

        // ....
        // Detect if the position of the player has changed
        if (transform.position != lastPosition && !isRunning)
        {
            StartRunning();
        }

        // Update the last position with the current position
        lastPosition = transform.position;

        // Other player input or actions
        // ...


    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "Obstacle")
        {
            myPlayer.GetComponent<Animator>().Play("stumble1");
            PlayerManager.gameOver = true; 
        }

        if (hit.transform.tag == "Trap")
        {
            PlayerManager.audioReady = true;
        }

        if (hit.transform.tag == "Slow")
        {
            StartCoroutine(SlowPlayer());
        }
    }

    public IEnumerator SlowPlayer()
    {
        forwardSpeed -= 0.2f;
        yield return new WaitForSeconds(0.1f);
        forwardSpeed += 0.2f;
        yield return new WaitForSeconds(0.1f);
    }

    // ....
    private void StartRunning()
    {
        isRunning = true;
        chaser.StartRunning();
        // Perform any additional actions when the player starts running
    }

    private void Jump()
    {
        if (controller.isGrounded) // if the player is on the ground
        {
            if (SwipeManager.swipeUp) // and if the up arrow is pressed
            {
                myPlayer.GetComponent<Animator>().Play("jump"); // make the transition from run to jump
                direction.y = jumpForce; // making the player to jump 
            }
            myPlayer.GetComponent<Animator>().Play("run"); // make the transition from jump to run
        }
        else  // if he is not on the ground
        {
            direction.y += GRAVITY * Time.deltaTime; // apply the gravity effect to pull the player to the ground
        }
    }

    private void ChangeLane()
    {
        if (SwipeManager.swipeRight) // if right arrow is pressed
        {
            desiredLane++; // increase the desired lane by one
            if (desiredLane == 3) // if the desired lane is three
            {
                desiredLane = 2; // set the desired lane back to two
            }
        }

        if (SwipeManager.swipeLeft) // if left arrow is pressed
        {
            desiredLane--; // decrease the desired lane by one
            if (desiredLane == -1) // if the desired lane is -1
            {
                desiredLane = 0; // set the desired lane back to one
            }
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up; // getting the current position of the player

        if (desiredLane == 0) // if the desired lane is 0
        {
            targetPosition += Vector3.left * laneDistance; // move the player to the left
        }
        else if (desiredLane == 2) // if the desired lane is 2
        {
            targetPosition += Vector3.right * laneDistance; // move the player to the right
        }

        transform.position = transform.position = Vector3.Lerp(transform.position, targetPosition, 30 * Time.deltaTime); // moving the player to the target Position
    }

}

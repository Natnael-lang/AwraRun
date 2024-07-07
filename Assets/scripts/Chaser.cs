using UnityEngine;

public class Chaser : MonoBehaviour
{
    public GameObject player;
    public float chaserSpeed;
    public float originalChaserSpeed;

    private bool isChasing = false;
    private bool isPlayerRunning = false;

    private void Update()
    {
        if (isPlayerRunning && !isChasing)
        {
            StartChase();
        }

        if (isChasing)
        {
            ChasePlayer();
        }
    }

    private void ChasePlayer()
    {
        // Calculate the direction from the chaser to the player
        Vector3 directionToPlayer = player.transform.position - transform.position;
        directionToPlayer.y = 0f; // Ignore any vertical difference
        directionToPlayer.Normalize();

        // Move the chaser towards the player's direction
        transform.position += directionToPlayer * chaserSpeed * Time.deltaTime;
    }

    // Called when the chaser collides with another object
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Player caught! Implement your game over logic here
            Debug.Log("Player caught!");
        }
    }

    // Call this method to start the chase
    public void StartChase()
    {
        isChasing = true;
    }

    // Call this method when the player starts running
    public void StartRunning()
    {
        isPlayerRunning = true;
    }

    // Call this method when the player stops running
    public void StopRunning()
    {
        isPlayerRunning = false;
    }
}
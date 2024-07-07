using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents a collectible coin in the game world.
/// </summary>
public class Coin : MonoBehaviour
{
/// <summary>
    /// The speed at which the coin rotates (degrees per second).
    /// </summary>
    private int rotateSpeed = 90 ;
    /// <summary>
    /// The audio source that plays the coin sound effect when collected.
    /// </summary>
    public AudioSource coinSound;
    /// <summary>
    /// Called for initialization at the beginning of the game.
    /// 
    /// In this class, there is currently no specific initialization required
    /// for the coin's behavior. It can be left empty.
    /// </summary>
    void Start()
    {
        
    }

    /// <summary>
    /// Called once per frame.
    /// 
    /// This function rotates the coin around the Y-axis at the specified speed.
    /// </summary>
    void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime ,0,Space.World);
        
    }
    /// <summary>
    /// Called when this Collider (the coin) enters a trigger collider.
    /// 
    /// If the colliding object has the "Player" tag, increments the player's
    /// coin count, plays the coin sound effect, and destroys the coin game object.
    /// </summary>
    /// <param name="other">The Collider that entered the trigger.</param>
    private void OnTriggerEnter(Collider other){

        
        if (other.gameObject.CompareTag("Player"))
        {
            
            PlayerManager1.numberOfCoins += 1;
            
            coinSound.Play();
            
            Destroy(gameObject);
        }
        
    }
}

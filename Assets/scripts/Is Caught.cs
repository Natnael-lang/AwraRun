using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsCaught : MonoBehaviour
{

    public GameObject thePlayer;  // game object for the player
    private CharacterController playerController; // Character Controller component
    public GameObject theCow;       // game object for the cow
    public GameObject playerCharacter;  // game object for the player character

    public static float distance;
    public static int convertedDistance;

    // Update is called once per frame
    void Update()
    {
        // calculates the distanc between the player and the cow
        distance = Vector3.Distance(thePlayer.transform.position, theCow.transform.position); 
        convertedDistance = Mathf.RoundToInt(distance);
        if (distance < 3f)      // if distance is less than 3 units
        {
            PlayerManager.nextLevel = true;
        } else if(distance > 600f)
        {
            PlayerManager.gameOver = true;      // game over panel pops up
        }
    }
}

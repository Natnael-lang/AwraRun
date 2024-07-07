using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;

/// This class manages the player's state and updates the UI in the game.
public class PlayerManager1 : MonoBehaviour
{
/// <summary>
/// Indicates if the game is over.
/// </summary>
    public static bool gameOver;
/// <summary>
/// Indicates if the current level has been passed.    
/// </summary>
    public static bool levelPassed;
 /// <summary>
 /// The game object reference for the game over panel.   
 /// </summary>
    public GameObject gameOverPanel;
    /// <summary>
    /// The game object reference for the level passed panel.
    /// </summary>
    public GameObject levelPassedPanel;
 /// <summary>
 /// Tracks the number of coins collected by the player.
 /// </summary>
    public static int numberOfCoins;

    public static AudioSource failAudio;

    public static bool gameStarted;

    public GameObject startingText;

    public GameObject soundTrack;


    public Text coinsText;
/// <summary>
    /// This method is called at the start of the game.
    /// </summary>
    void Start()
    {
        
        levelPassed = false;
        
        gameOver = false;

        gameStarted = false;
        
        Time.timeScale = 0;
        
        numberOfCoins = 0;


    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        
        coinsText.text = "Coins: " + numberOfCoins;

        if (gameOver)
        {            
            
            Time.timeScale = 0;
            
            gameOverPanel.SetActive(true);

        }

        if (levelPassed)
        {
            
            Time.timeScale = 0;
            
            levelPassedPanel.SetActive(true);

        }

        if (SwipeManager.tap)
        {
            gameStarted = true;

            Time.timeScale = 1;

            Destroy(startingText);

        }

        if (gameStarted && !gameOver && !levelPassed)
        {
            soundTrack.SetActive(true);
        }
        else
        {
            soundTrack.SetActive(false);
        }
       
    }
}

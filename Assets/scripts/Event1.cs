using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// This class handles various event functionalities within the game.
/// </summary>
public class Event1 : MonoBehaviour
{
    /// <summary>
    /// Restarts the current game level by reloading the "Level 1" scene.
    /// </summary>
    public void replayGame()
    {
       
        SceneManager.LoadScene("Level 1");

    }

    /// <summary>
    /// Terminates the game application.
    /// </summary>
    public void quitGame()
    {
        
        Application.Quit();
    }

    /// <summary>
    /// Loads the next level in the game sequence, assuming "Level 2" exists.
    /// It's recommended to implement level progression logic to ensure valid level loading.
    /// </summary>
    public void nextLevel()
    {
        
        SceneManager.LoadScene("Level1 End");
    }
}

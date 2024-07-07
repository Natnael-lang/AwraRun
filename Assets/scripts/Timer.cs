using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// This class manages a timer that counts down in minutes and seconds, updating a UI text element.
/// </summary>
public class Timer : MonoBehaviour
{
/// <summary>
    /// A reference to the TextMeshProUGUI component that displays the timer countdown.
    /// This field is serialized in the inspector.
    /// </summary>
    public Text timerText;
    /// <summary>
    /// The current timer countdown value in seconds (static for accessibility throughout the scene).
    /// </summary>
    public static float countDown;
/// <summary>
    /// The extracted seconds value from the countdown (static for UI update).
    /// </summary>
    public static int seconds;
    /// <summary>
    /// The extracted minutes value from the countdown (static for UI update).
    /// </summary>
    public static int minutes;
    

    private void Start()
    {
       /// <summary>
        /// Initializes the countdown value to 180 seconds (3 minutes).
        /// </summary>
        countDown = 180;
    }
    
    // Update is called once per frame
    
    void Update()
    {
       
        if (countDown > 0)
        {
          /// <summary>
        /// Decrements the countdown timer by the elapsed time (deltaTime) each frame if the countdown is positive.
        /// </summary>
            countDown -= Time.deltaTime;
        }
       
        else
        {
            /// <summary>
            /// If the countdown reaches zero:
            /// - Sets the countdown to zero to prevent negative values.
            /// - Changes the timer text color to green (potentially signifying completion).
            /// - If the game is not over (based on PlayerManager.gameOver), sets the levelPassed flag in PlayerManager to true (assuming this indicates a level completion).
            /// </summary>
            countDown = 0;
            
            timerText.color = Color.green;
            
            if (!PlayerManager1.gameOver)
            {
            
                PlayerManager1.levelPassed = true;
            }
        }

        /// <summary>
        /// Calculates the minutes and seconds from the remaining countdown value for UI display.
        /// - Mathf.FloorToInt rounds down the division result to get whole numbers for minutes.
        /// - The modulo operator (%) gives the remainder after division, used to get seconds.
        /// </summary>
        minutes = Mathf.FloorToInt(countDown / 60);
        
        seconds = Mathf.FloorToInt(countDown % 60);
/// <summary>
        /// Updates the timer text UI element with the formatted time string (00:00).
        /// - "{0:00}" and "{1:00}" are placeholders for minutes and seconds formatted with two digits (leading zeros for single digits).
        /// </summary>
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        
    }

    

    
}

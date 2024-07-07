using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{

    [SerializeField] Text timerText; // declaring a field for displaying a text
    [SerializeField] float remainingTime; // declaring a variable for the remaining time

    // Update is called once per frame
    void Update()
    {
        // checks if the remaining time if greater or less than zero
        if (remainingTime > 0)          // if greater than zero
        {
            remainingTime -= Time.deltaTime; // decrease the remaining time by the delta time
            if (remainingTime < 30)         // if greater than zero and less than 30
            {
                timerText.color = Color.red;  // change text color to red
            }
        } else          // if less than zero
        {
            remainingTime = 0;      // set the remaining time to zero
            timerText.color = Color.red;    // change the color of the text ot red
            PlayerManager.gameOver = true;  // to display the game over panel
        }
        int minutes = Mathf.FloorToInt(remainingTime / 60);     // to determine the minutes
        int seconds = Mathf.FloorToInt(remainingTime % 60);     // to determine the seconds
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);      // to display the time
    }
}

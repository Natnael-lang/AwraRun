using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;
    public static bool nextLevel;
    public GameObject nextLevelPanel;

    public AudioSource source;
    public AudioClip clip;
    public static bool audioReady;  

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        nextLevel = false;
        Time.timeScale = 1;

        audioReady = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            StartCoroutine(EndScreen());
        }

        if (nextLevel)
        {
            Time.timeScale = 0;
            StartCoroutine(NextLevelScreen());
        }
    }

    IEnumerator EndScreen()
    {
        yield return new WaitForSecondsRealtime(3);
        gameOverPanel.SetActive(true);
    }

    IEnumerator NextLevelScreen()
    {
        yield return new WaitForSecondsRealtime(3);
        nextLevelPanel.SetActive(true);
    }
}

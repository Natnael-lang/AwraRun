using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventTR1 : MonoBehaviour
{
    public void skipScene()
    {
        SceneManager.LoadScene("Level 2");
    }
}

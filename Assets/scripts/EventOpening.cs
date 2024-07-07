using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventOpening : MonoBehaviour
{
    
    public void skipScene()
    {
        SceneManager.LoadScene("Level 1");
    }

    
}

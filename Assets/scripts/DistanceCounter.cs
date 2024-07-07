using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceCounter : MonoBehaviour
{

    public GameObject distanceDisplay;    // Game Object for displaying the total coins collected

    // Update is called once per frame
    void Update()
    {
        distanceDisplay.GetComponent<Text>().text = "" + IsCaught.convertedDistance;  // updating the distance value
    }
}

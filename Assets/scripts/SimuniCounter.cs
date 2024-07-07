using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimuniCounter : MonoBehaviour
{

    public GameObject coinDisplay;    // Game Object for displaying the total coins collected

    // Update is called once per frame
    void Update()
    {
        coinDisplay.GetComponent<Text>().text = "" + PlayerController.numberOfCoins;  // updating the coin value
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Display the players final position 
public class FinishedPosition : MonoBehaviour
{
    private int _finishedPosition;

    // Use this for initialization
    void Start()
    {
        _finishedPosition = GameObject.Find("PositionStorage").GetComponent<WinLossDetection>().Position;

        if (_finishedPosition == 0)
            GetComponent<Text>().text = "Oh no! You ran out of time! DNF!!!! :(";
        else if (_finishedPosition == -1)
            GetComponent<Text>().text = "Oh no! You destroyed your car! DNF! :(";
        else
            GetComponent<Text>().text = "Well done! You finished in position " + _finishedPosition.ToString();

    }
}

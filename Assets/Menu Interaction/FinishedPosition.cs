using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedPosition : MonoBehaviour
{
    private int _finishedPosition;

    // Use this for initialization
    void Start()
    {
        _finishedPosition = GameObject.Find("PositionStorage").GetComponent<WinLossDetection>().Position;
        GetComponent<TextMesh>().text = "Well done! You finished in position " + _finishedPosition.ToString();
    }
}

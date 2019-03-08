using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Allows user to control their vehicle by using Unity Input Manager settings
public class PlayerMovement : MonoBehaviour
{
    private WinLossDetection _countdownObject;

    private void Start()
    {
        _countdownObject = GameObject.Find("PositionStorage").GetComponent<WinLossDetection>();
    }

    private void FixedUpdate()
    {
        if (_countdownObject.Countdown < 0)
        {
            gameObject.GetComponent<CarController>().MotorInput = Input.GetAxis("Vertical");
            gameObject.GetComponent<CarController>().SteeringInput = Input.GetAxis("Horizontal");
        }
    }
}

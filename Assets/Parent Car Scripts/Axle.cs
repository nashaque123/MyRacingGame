using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Allows car to move properly using the wheel colliders
public class Axle
{
    private WheelCollider _leftWheel;
    private WheelCollider _rightWheel;
    private bool _motor = false;
    private bool _steering = false;

    public WheelCollider LeftWheel
    {
        get
        {
            return _leftWheel;
        }

        set
        {
            _leftWheel = value;
        }
    }

    public WheelCollider RightWheel
    {
        get
        {
            return _rightWheel;
        }

        set
        {
            _rightWheel = value;
        }
    }

    public bool Motor
    {
        get
        {
            return _motor;
        }

        set
        {
            _motor = value;
        }
    }

    public bool Steering
    {
        get
        {
            return _steering;
        }

        set
        {
            _steering = value;
        }
    }
}

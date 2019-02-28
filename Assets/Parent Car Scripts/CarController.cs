using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private Axle[] _axles = new Axle[2];
    private readonly int _maxMotorTorque = 80, _maxSteeringAngle = 13;
    private float _motorInput, _steeringInput;

    public float MotorInput
    {
        get
        {
            return _motorInput * _maxMotorTorque;
        }

        set
        {
            _motorInput = value * _maxMotorTorque;
        }
    }

    public float SteeringInput
    {
        get
        {
            return _steeringInput * _maxSteeringAngle;
        }

        set
        {
            _steeringInput = value * _maxSteeringAngle;
        }
    }

    private void Start()
    {
        Transform wheelsList = gameObject.transform.Find("Wheels");

        _axles[0] = new Axle
        {
            LeftWheel = wheelsList.Find("Front Left").GetComponent<WheelCollider>(),
            RightWheel = wheelsList.Find("Front Right").GetComponent<WheelCollider>(),
            Motor = true,
            Steering = true
        };

        _axles[1] = new Axle
        {
            LeftWheel = wheelsList.Find("Back Left").GetComponent<WheelCollider>(),
            RightWheel = wheelsList.Find("Back Right").GetComponent<WheelCollider>()
        };
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < _axles.Length; i++)
        {
            if (_axles[i].Steering)
            {
                _axles[i].LeftWheel.steerAngle = _steeringInput;
                _axles[i].RightWheel.steerAngle = _steeringInput;
            }

            if (_axles[i].Motor)
            {
                _axles[i].LeftWheel.motorTorque = _motorInput;
                _axles[i].RightWheel.motorTorque = _motorInput;
            }
        }
    }
}
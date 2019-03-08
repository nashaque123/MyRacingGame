using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class to hold all the attributes of the car
public class CarController : MonoBehaviour
{
    private Axle[] _axles = new Axle[2];
    private int _maxMotorTorque = 80, _maxSteeringAngle = 13;
    private float _motorInput, _steeringInput;
    private Rigidbody _rb;
    private float _currentSpeed;
    private int _health = 100;
    private GUIStyle _style = new GUIStyle();

    public float MotorInput
    {
        get
        {
            return _motorInput * _maxMotorTorque * (_health / 100.0f);
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

    public int Health
    {
        get
        {
            return _health;
        }
    }

    private void Start()
    {
        _style.fontSize = 19;
        _style.normal.textColor = Color.magenta;

        //Use player prefs to setup car values according to their choice in the main menu
        _maxMotorTorque = Mathf.RoundToInt(_maxMotorTorque * PlayerPrefs.GetFloat("Torque setting"));
        _maxSteeringAngle = Mathf.RoundToInt(_maxSteeringAngle * PlayerPrefs.GetFloat("Angle setting"));

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

        _rb = GetComponent<Rigidbody>();
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

            //Motor input affected by the health of the car
            if (_axles[i].Motor)
            {
                _axles[i].LeftWheel.motorTorque = _motorInput * (_health / 100.0f);
                _axles[i].RightWheel.motorTorque = _motorInput * (_health / 100.0f);
            }
        }

        _currentSpeed = 3.0f * (_rb.velocity.magnitude * 3.6f * 2.237f); //Measure in MPH - multiplied by 3 to look better for the player
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Barrier" || collision.gameObject.tag == "Car")
            TakeDamage();
    }

    private void TakeDamage()
    {
        _health -= Mathf.RoundToInt(_currentSpeed / 15.0f);
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(20, (Screen.height - 60), 100, 20), "Health: " + _health.ToString(), _style);
        GUI.Label(new Rect((Screen.width - 150), (Screen.height - 60), 100, 20), "Speed: " + Mathf.RoundToInt(_currentSpeed).ToString(), _style);
    }
}
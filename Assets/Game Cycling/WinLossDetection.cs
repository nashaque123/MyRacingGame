using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Master script for each race
public class WinLossDetection : MonoBehaviour
{
    private GameObject _player; //Only find in necessary functions as does not exist in every scene
    private int _finalPosition;
    private int _noOfCars;
    private GUIStyle _style = new GUIStyle();
    private GUIStyle _countdownStyle = new GUIStyle();
    private float _startCountdown = 3.0f;
    private float _raceCountdown = 120.0f;
    private HashSet<string> _trackNames = new HashSet<string>();

    public float Countdown
    {
        get
        {
            return _startCountdown;
        }
    }

    public int Position
    {
        get
        {
            return _finalPosition;
        }
    }

    // Use this for initialization
    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        _style.fontSize = 19;
        _style.normal.textColor = Color.magenta;
        _countdownStyle.fontSize = 50;
        _countdownStyle.normal.textColor = Color.magenta;

        _trackNames.Add("RaceTrack1");
        _trackNames.Add("OvalRaceTrack");
        _trackNames.Add("FigureEightTrack");
    }

    private void FixedUpdate()
    {        
        //If player is in a race then start timers and check if race has finished
        if (_trackNames.Contains(SceneManager.GetActiveScene().name))
        {
            _startCountdown -= Time.deltaTime;

            if (_startCountdown <= 0)
                _raceCountdown -= Time.deltaTime;

            if (EndCondition())
            {
                ResetTimers();
                SceneManager.LoadScene("GameOverScene");
            }
        }
    }

    private bool EndCondition()
    {
        _player = GameObject.Find("Player");

        if (_player.GetComponent<LapCounter>().LapNumber == 4)
        {
            _finalPosition = _player.GetComponent<PositionCheck>().Position;
            return true;
        }

        if (_raceCountdown <= 0)
        {
            _finalPosition = 0;
            return true;
        }

        if (_player.GetComponent<CarController>().Health <= 0)
        {
            _finalPosition = -1;
            return true;
        }

        return false;
    }

    public void ResetTimers()
    {
        _raceCountdown = 120.0f;
        _startCountdown = 3.0f;
    }

    private void OnGUI()
    {
        if (_trackNames.Contains(SceneManager.GetActiveScene().name))
        {
            if (_startCountdown > 0)
                GUI.Label(new Rect((Screen.width / 2) - 25, (Screen.height / 2) - 25, 10, 10), Mathf.RoundToInt(_startCountdown).ToString(), _countdownStyle);
            else
                GUI.Label(new Rect((Screen.width / 2) - 10, 20, 20, 20), Mathf.RoundToInt(_raceCountdown).ToString(), _countdownStyle);

            _player = GameObject.Find("Player");
            _noOfCars = _player.GetComponent<PositionCheck>().NoOfCars;

            GUI.Label(new Rect((Screen.width - 150), 20, 100, 20), "Position: " + _player.GetComponent<PositionCheck>().Position.ToString() + " / " + _noOfCars.ToString(), _style);

            if (_player.GetComponent<LapCounter>().LapNumber <= 3)
                GUI.Label(new Rect(20, 20, 100, 20), "Lap number: " + _player.GetComponent<LapCounter>().LapNumber.ToString() + " / 3", _style);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLossDetection : MonoBehaviour
{
    private GameObject _player;
    private int _finalPosition;
    private int _noOfCars;
    private GUIStyle _style = new GUIStyle();

    // Use this for initialization
    private void Start()
    {
        _style.fontSize = 19;
        _style.normal.textColor = Color.magenta;

        DontDestroyOnLoad(gameObject);
    }

    public int Position
    {
        get
        {
            return _finalPosition;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (EndCondition())
            SceneManager.LoadScene("GameOverScene");
    }

    private void OnGUI()
    {
        if (SceneManager.GetActiveScene().name == "RaceTrack1")
        {
            _player = GameObject.Find("Player");
            _noOfCars = _player.GetComponent<PositionCheck>().NoOfCars;

            GUI.Label(new Rect((Screen.width - 150), 20, 100, 20), "Position: " + _player.GetComponent<PositionCheck>().Position.ToString() + " / " + _noOfCars.ToString(), _style);

            if (_player.GetComponent<LapCounter>().LapNumber <= 3)
                GUI.Label(new Rect(20, 20, 100, 20), "Lap number: " + _player.GetComponent<LapCounter>().LapNumber.ToString() + " / 3", _style);
        }
    }

    private bool EndCondition()
    {
        if (SceneManager.GetActiveScene().name == "RaceTrack1")
        {
            _player = GameObject.Find("Player");

            if (_player.GetComponent<LapCounter>().LapNumber == 4)
            {
                _finalPosition = _player.GetComponent<PositionCheck>().Position;
                return true;
            }
        }

        return false;
    }
}

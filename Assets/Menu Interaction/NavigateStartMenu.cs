using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NavigateStartMenu : MonoBehaviour
{
    private Image[] _buttons = new Image[5];
    private int _currentButton = 0, _firstButton = 0, _lastButton = 1;

    // Use this for initialization
    void Start()
    {
        _buttons[0] = GameObject.Find("Start").GetComponent<Image>();
        _buttons[0].color = Color.magenta;

        _buttons[1] = GameObject.Find("Quit").GetComponent<Image>();
        _buttons[1].color = Color.white;

        _buttons[2] = GameObject.Find("Oval").GetComponent<Image>();
        _buttons[2].color = Color.white;

        _buttons[3] = GameObject.Find("Figure8").GetComponent<Image>();
        _buttons[3].color = Color.white;

        _buttons[4] = GameObject.Find("Track1").GetComponent<Image>();
        _buttons[4].color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            if (i >= _firstButton && i <= _lastButton)
                _buttons[i].enabled = true;
            else
                _buttons[i].enabled = false;

            if (_buttons[i].enabled == false)
                _buttons[i].rectTransform.localScale = new Vector3(0, 0, 0);
            else
                _buttons[i].rectTransform.localScale = new Vector3(1, 1, 1);

            if (!_buttons[_currentButton].enabled)
                _currentButton = _firstButton;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.Joystick1Button4))
            MoveToPreviousButton();
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.Joystick1Button5))
            MoveToNextButton();
        else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            if (_buttons[_currentButton].name == "Start")
            {
                _firstButton = 2;
                _lastButton = _buttons.Length - 1;
                _buttons[2].color = Color.magenta;
            }
            else if (_buttons[_currentButton].name == "Quit")
                Application.Quit();
            else if (_buttons[_currentButton].name == "Oval")
                SceneManager.LoadScene("OvalRaceTrack");
            else if (_buttons[_currentButton].name == "Figure8")
                SceneManager.LoadScene("FigureEightTrack");
            else if (_buttons[_currentButton].name == "Track1")
                SceneManager.LoadScene("RaceTrack1");
        }
    }

    void MoveToNextButton()
    {
        _buttons[_currentButton].color = Color.white;
        _currentButton++;

        if (_currentButton > _lastButton)
            _currentButton = _firstButton;

        _buttons[_currentButton].color = Color.magenta;
    }

    void MoveToPreviousButton()
    {
        _buttons[_currentButton].color = Color.white;
        _currentButton--;

        if (_currentButton < _firstButton)
            _currentButton = _lastButton;

        _buttons[_currentButton].color = Color.magenta;
    }
}

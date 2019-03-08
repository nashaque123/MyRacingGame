using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Navigate through the start menu by displaying the correct buttons for the player to choose from
public class NavigateStartMenu : MonoBehaviour
{
    private Image[] _buttons = new Image[8];
    private int _currentButton = 0, _firstButton = 0, _lastButton = 1;

    // Use this for initialization
    void Start()
    {
        _buttons[0] = GameObject.Find("Start").GetComponent<Image>();
        _buttons[0].color = Color.magenta;

        _buttons[1] = GameObject.Find("Quit").GetComponent<Image>();
        _buttons[1].color = Color.white;

        _buttons[2] = GameObject.Find("Handling").GetComponent<Image>();
        _buttons[2].color = Color.white;

        _buttons[3] = GameObject.Find("Balanced").GetComponent<Image>();
        _buttons[3].color = Color.white;

        _buttons[4] = GameObject.Find("Speed").GetComponent<Image>();
        _buttons[4].color = Color.white;

        _buttons[5] = GameObject.Find("Oval").GetComponent<Image>();
        _buttons[5].color = Color.white;

        _buttons[6] = GameObject.Find("Figure8").GetComponent<Image>();
        _buttons[6].color = Color.white;

        _buttons[7] = GameObject.Find("Track1").GetComponent<Image>();
        _buttons[7].color = Color.white;
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
            if (_currentButton == 0)
                NextListOfOptions(2, 4);
            else if (_currentButton == 1)
                Application.Quit();
            else if (_currentButton == 2)
            {
                PlayerPrefs.SetFloat("Torque setting", 0.8f);
                PlayerPrefs.SetFloat("Angle setting", 1.2f);
                NextListOfOptions(5, 7);
            }
            else if (_currentButton == 3)
            {
                PlayerPrefs.SetFloat("Torque setting", 1.0f);
                PlayerPrefs.SetFloat("Angle setting", 1.0f);
                NextListOfOptions(5, 7);
            }
            else if (_currentButton == 4)
            {
                PlayerPrefs.SetFloat("Torque setting", 1.2f);
                PlayerPrefs.SetFloat("Angle setting", 0.8f);
                NextListOfOptions(5, 7);
            }
            else if (_currentButton == 5)
                SceneManager.LoadScene("OvalRaceTrack");
            else if (_currentButton == 6)
                SceneManager.LoadScene("FigureEightTrack");
            else if (_currentButton == 7)
                SceneManager.LoadScene("RaceTrack1");
        }
        else if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {          
            if (_currentButton == 2 || _currentButton == 3 || _currentButton == 4)
                NextListOfOptions(0, 1);
            else if (_currentButton == 5 || _currentButton == 6 || _currentButton == 7)
                NextListOfOptions(2, 4);
        }
    }

    private void MoveToNextButton()
    {
        _buttons[_currentButton].color = Color.white;
        _currentButton++;

        if (_currentButton > _lastButton)
            _currentButton = _firstButton;

        _buttons[_currentButton].color = Color.magenta;
    }

    private void MoveToPreviousButton()
    {
        _buttons[_currentButton].color = Color.white;
        _currentButton--;

        if (_currentButton < _firstButton)
            _currentButton = _lastButton;

        _buttons[_currentButton].color = Color.magenta;
    }

    private void NextListOfOptions(int firstButton, int lastButton)
    {
        _buttons[_currentButton].color = Color.white;
        _firstButton = firstButton;
        _lastButton = lastButton;
        _buttons[_firstButton].color = Color.magenta;
    }
}

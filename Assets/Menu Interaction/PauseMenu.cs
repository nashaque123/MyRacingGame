using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//Allows the user to pause the game during a race
public class PauseMenu : MonoBehaviour
{
    private bool _gamePaused = false;
    private GameObject _pauseMenu;
    private Image[] _buttons = new Image[2];
    private int _currentButton = 0;
    private WinLossDetection _resetTimers;

    private void Awake()
    {
        _pauseMenu = GameObject.Find("Pause Menu");
        _resetTimers = GameObject.Find("PositionStorage").GetComponent<WinLossDetection>();

        _buttons[0] = GameObject.Find("Resume").GetComponent<Image>();
        _buttons[0].color = Color.magenta;

        _buttons[1] = GameObject.Find("BackToMenu").GetComponent<Image>();
        _buttons[1].color = Color.white;
    }

    private void Start()
    {
        _pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            if (_gamePaused)
                Resume();
            else
                Pause();
        }

        if (_gamePaused)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Joystick1Button4))
                MoveToPreviousButton();
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.Joystick1Button5))
                MoveToNextButton();
            else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                if (_currentButton == 0)
                    Resume();
                else if (_currentButton == 1)
                {
                    _resetTimers.ResetTimers();
                    Resume();
                    SceneManager.LoadScene("StartMenu");
                }
            }
        }
    }

    void Resume()
    {
        _pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        _gamePaused = false;
    }

    void Pause()
    {
        _pauseMenu.SetActive(true);
        Time.timeScale = 0.0f;
        _gamePaused = true;
    }

    private void MoveToNextButton()
    {
        _buttons[_currentButton].color = Color.white;
        _currentButton++;

        if (_currentButton > 1)
            _currentButton = 0;

        _buttons[_currentButton].color = Color.magenta;
    }

    private void MoveToPreviousButton()
    {
        _buttons[_currentButton].color = Color.white;
        _currentButton--;

        if (_currentButton < 0)
            _currentButton = 1;

        _buttons[_currentButton].color = Color.magenta;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NavigateEndMenu : MonoBehaviour
{
    private Image[] _buttons = new Image[2];
    private int _currentButton = 0;

    // Use this for initialization
    void Start()
    {
        _buttons[0] = GameObject.Find("Restart").GetComponent<Image>();
        _buttons[0].color = Color.magenta;

        _buttons[1] = GameObject.Find("Quit").GetComponent<Image>();
        _buttons[1].color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.Joystick1Button4))
            MoveToPreviousButton();
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.Joystick1Button5))
            MoveToNextButton();
        else if (Input.GetAxis("Submit") == 1)
        {
            if (_buttons[_currentButton].name == "Restart")
                SceneManager.LoadScene("StartMenu");
            else if (_buttons[_currentButton].name == "Quit")
                Application.Quit();
        }
    }

    void MoveToNextButton()
    {
        _buttons[_currentButton].color = Color.white;
        _currentButton++;

        if (_currentButton >= _buttons.Length)
            _currentButton = 0;

        _buttons[_currentButton].color = Color.magenta;
    }

    void MoveToPreviousButton()
    {
        _buttons[_currentButton].color = Color.white;
        _currentButton--;

        if (_currentButton < 0)
            _currentButton = (_buttons.Length - 1);

        _buttons[_currentButton].color = Color.magenta;
    }
}

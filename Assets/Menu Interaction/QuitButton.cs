using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Quit application if button pressed
public class QuitButton : MonoBehaviour
{
    private bool pressingButton = false;

    // Update is called once per frame
    void Update()
    {

        if (pressingButton)
        {
            if (Input.GetMouseButtonDown(0))
                Application.Quit();
        }
    }

    private void OnMouseEnter()
    {
        pressingButton = true;
    }

    private void OnMouseExit()
    {
        pressingButton = false;
    }
}
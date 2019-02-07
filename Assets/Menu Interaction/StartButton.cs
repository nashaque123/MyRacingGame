using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Start game by loading first scene
public class StartButton : MonoBehaviour
{
    private bool pressingButton = false;

    // Update is called once per frame
    void Update()
    {

        if (pressingButton)
        {
            if (Input.GetMouseButtonDown(0))
                SceneManager.LoadScene("RaceTrack1");
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
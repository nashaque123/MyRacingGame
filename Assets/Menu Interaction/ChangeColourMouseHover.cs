﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Change colour of button when mouse is hovering over it
public class ChangeColourMouseHover : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.black;
    }

    private void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = Color.magenta;
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = Color.black;
    }
}
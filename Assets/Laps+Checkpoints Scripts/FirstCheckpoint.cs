﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//States the car has hit the first checkpoint
public class FirstCheckpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<LapCounter>())
            other.GetComponent<LapCounter>().PassedPoint1 = true;
    }
}
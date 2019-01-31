using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Returns to state the car has hit the first checkpoint
public class SecondCheckpoint : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<LapCounter>())
            other.GetComponent<LapCounter>().PassedPoint2 = true;
    }
}
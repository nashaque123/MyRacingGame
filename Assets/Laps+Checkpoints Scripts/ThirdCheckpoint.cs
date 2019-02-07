using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Returns to state the car has hit the first checkpoint
public class ThirdCheckpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<LapCounter>())
            other.GetComponent<LapCounter>().PassedPoint3 = true;
    }
}
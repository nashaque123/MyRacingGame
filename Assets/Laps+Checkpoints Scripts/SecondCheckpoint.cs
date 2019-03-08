using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//States the car has hit the second checkpoint
public class SecondCheckpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<LapCounter>())
            other.GetComponent<LapCounter>().PassedPoint2 = true;
    }
}
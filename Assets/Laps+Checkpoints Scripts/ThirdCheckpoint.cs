using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//States the car has hit the third checkpoint
public class ThirdCheckpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<LapCounter>())
            other.GetComponent<LapCounter>().PassedPoint3 = true;
    }
}
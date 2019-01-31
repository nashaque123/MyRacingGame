using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapNumberIncrease : MonoBehaviour {

    //Increases the lap number of the car if they have passed all checkpoints and pass through the start/finish line
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<LapCounter>().PassedAllPoints())
            other.GetComponent<LapCounter>().LapNumber++;
    }
}
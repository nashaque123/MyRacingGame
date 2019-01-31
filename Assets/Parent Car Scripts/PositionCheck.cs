using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Compare players' position in race by checking how many cars are ahead
//Check lap number, checkpoint, then distance to next checkpoint
public class PositionCheck : MonoBehaviour {
    private GameObject[] _cars;
    private GameObject _player;
    [SerializeField]private int _position = 1;
    private GameObject[] _checkpoints = new GameObject[4];

    // Use this for initialization
    void Start () {
        _cars = GameObject.FindGameObjectsWithTag("Car");
        _player = GameObject.Find("Player");

        _checkpoints[0] = GameObject.Find("Checkpoint");
        _checkpoints[1] = GameObject.Find("Checkpoint (1)");
        _checkpoints[2] = GameObject.Find("Checkpoint (2)");
        _checkpoints[3] = GameObject.Find("Start/Finish");
    }
	
	// Update is called once per frame
	void Update () {
        _position = 1;

        for (int i = 0; i < _cars.Length; i++)
        {
            if (PlayerLapBehind(_cars[i]))
                _position++;
            else if (PlayerCheckpointBehind(_cars[i]))
                _position++;
            else if (PlayerFurtherAwayToCheckpoint(_cars[i]))
                _position++;
        }
	}

    //Function to compare lap numbers
    private bool PlayerLapBehind(GameObject car)
    {
        if (car.GetComponent<LapCounter>().LapNumber > _player.GetComponent<LapCounter>().LapNumber)
            return true;
        else
            return false;
    }

    //Compares which checkpoints they are targetting
    private bool PlayerCheckpointBehind(GameObject car)
    {
        if (car.GetComponent<LapCounter>().LapNumber == _player.GetComponent<LapCounter>().LapNumber)
        {
            if (car.GetComponent<LapCounter>().PassedPoint1 && !_player.GetComponent<LapCounter>().PassedPoint1)
                return true;
            else if (car.GetComponent<LapCounter>().PassedPoint2 && !_player.GetComponent<LapCounter>().PassedPoint2)
                return true;
            else if (car.GetComponent<LapCounter>().PassedPoint3 && !_player.GetComponent<LapCounter>().PassedPoint3)
                return true;
            else
                return false;
        }
        else
            return false;
    }

    //First checks which checkpoint the player and car are targetting. Only one car needs to be checked as they are going to the same point
    //Compares distances to the next checkpoint
    private bool PlayerFurtherAwayToCheckpoint(GameObject car)
    {
        if (!car.GetComponent<LapCounter>().PassedPoint1)
        {
            if (CalculateDistanceToCheckpoint(_checkpoints[0], car) < CalculateDistanceToCheckpoint(_checkpoints[0], _player))
                return true;
            else
                return false;
        }
        else if (!car.GetComponent<LapCounter>().PassedPoint2)
        {
            if (CalculateDistanceToCheckpoint(_checkpoints[1], car) < CalculateDistanceToCheckpoint(_checkpoints[1], _player))
                return true;
            else
                return false;
        }
        else if (!car.GetComponent<LapCounter>().PassedPoint3)
        {
            if (CalculateDistanceToCheckpoint(_checkpoints[2], car) < CalculateDistanceToCheckpoint(_checkpoints[2], _player))
                return true;
            else
                return false;
        }
        else if (car.GetComponent<LapCounter>().PassedPoint3)
        {
            if (CalculateDistanceToCheckpoint(_checkpoints[3], car) < CalculateDistanceToCheckpoint(_checkpoints[3], _player))
                return true;
            else
                return false;
        }
        else
            return false;        
    }

    public float CalculateDistanceToCheckpoint(GameObject checkpoint, GameObject car)
    {
        return Vector3.Distance(checkpoint.transform.position, car.transform.position);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class to hold all the attributes of the car
public class LapCounter : MonoBehaviour
{
    private bool _passedPoint1 = false, _passedPoint2 = false, _passedPoint3 = false;

    public bool PassedPoint1
    {
        get
        {
            return _passedPoint1;
        }

        set
        {
            _passedPoint1 = value;
        }
    }

    public bool PassedPoint2
    {
        get
        {
            return _passedPoint2;
        }

        set
        {
            _passedPoint2 = value;
        }
    }

    public bool PassedPoint3
    {
        get
        {
            return _passedPoint3;
        }

        set
        {
            _passedPoint3 = value;
        }
    }

    private int _lapNumber = 1;

    public bool PassedAllPoints()
    {
        if (_passedPoint1 && _passedPoint2 && _passedPoint3)
            return true;
        else
            return false;
    }

    public int LapNumber
    {
        get
        {
            return _lapNumber;
        }

        set
        {
            _lapNumber = value;
            _passedPoint1 = false;
            _passedPoint2 = false;
            _passedPoint3 = false;
        }
    }
}
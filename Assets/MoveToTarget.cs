using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToTarget : MonoBehaviour {

    Vector3[] _target = new[] { new Vector3(3.2f, 0.0f, 6.1f), new Vector3(5.0f, 0.0f, -4.7f), new Vector3(-6.0f, 0.0f, -4.0f) };
    int _destPoint = 0;
    NavMeshAgent _agent;

    // Use this for initialization
    void Start () {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update () {
        if (!_agent.pathPending && _agent.remainingDistance < 0.5f)
            GoToNextPoint();
	}

    void GoToNextPoint()
    {
        _agent.destination = _target[_destPoint];
        _destPoint = (_destPoint + 1) % _target.Length;
    }
}
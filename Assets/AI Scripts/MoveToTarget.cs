using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Allows AI cars to move around the track by hitting the checkpoints
public class MoveToTarget : MonoBehaviour
{
    private GameObject[] _targets = new GameObject[3];
    private int _destPoint = 0;
    private NavMeshAgent _agent;

    // Use this for initialization
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        _targets[0] = GameObject.Find("Checkpoint");
        _targets[1] = GameObject.Find("Checkpoint (1)");
        _targets[2] = GameObject.Find("Checkpoint (2)");
    }

    // Update is called once per frame
    void Update()
    {
        if (!_agent.pathPending && _agent.remainingDistance < 0.5f)
            GoToNextPoint();
    }

    private void GoToNextPoint()
    {
        _agent.destination = _targets[_destPoint].transform.position;
        _destPoint = (_destPoint + 1) % _targets.Length;
    }
}
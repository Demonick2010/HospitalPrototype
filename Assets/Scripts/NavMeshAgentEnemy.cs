using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentEnemy : MonoBehaviour
{
    Camera _target; // <-- Player position
    NavMeshAgent _agent; // <-- Get nawMesh Agent component

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _target = Camera.main;

        // TODO: Remove before release
        if (_agent != null)
            print($"{_agent}");

        if (_target != null)
            print($"Target position {_target.transform.position} finded!");
        else
            print($"Target position not found! Please, set tag MainCamera to Player camera.");
        // ---------------------------
    }

    void Update()
    {
        _agent.SetDestination(_target.transform.position);
    }
}

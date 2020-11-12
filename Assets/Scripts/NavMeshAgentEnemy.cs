using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentEnemy : MonoBehaviour
{
    Camera _target; // <-- Player position
    NavMeshAgent _agent; // <-- Get nawMesh Agent component

    [SerializeField]
    float HP = 100; // <-- Enemy HP (100 by default)

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
        _agent.SetDestination(_target.transform.position); // <-- Assigning a destination point

        // Check distance between player and enemy
        if (Vector3.Distance(_agent.transform.position, _target.transform.position) < 0.5f)
        {
            
            // TODO: Fight logic
        }
    }

    // Create take damage method
    void TakeDamage(float _damage)
    {
        HP -= _damage;

        print($"Zombie {gameObject.name} take {_damage}. Current lives is {HP}");

        // TODO: Die enemy logic
        if (HP <= 0)
        {
            // Start DIE Courutine
        }
    }

    // TODO: DIE Courutine
}

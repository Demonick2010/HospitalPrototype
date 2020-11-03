using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // init the state variable
    // By default animator start state = close
    bool _isOpen = false;
    Animator _animator;

    // Get animator component
    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check, if other.GameObject compare tag Player
        if (other.CompareTag("Player"))
        {
            // If state is open == false
            if (!_isOpen)
            {
                // Play open door animation
                _animator.SetTrigger("OpenDoor");

                // Set status in true
                _isOpen = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check, if other.GameObject compare tag Player
        if (other.CompareTag("Player"))
        {
            // If state is open == false
            if (_isOpen)
            {
                // Play open door animation
                _animator.SetTrigger("CloseDoor");

                // Set status in true
                _isOpen = false;
            }
        }
    }
}


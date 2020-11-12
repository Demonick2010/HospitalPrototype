using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiseTrigger : MonoBehaviour
{
    // Needed variables
    GameManager _manager;
    EnemySpawner _spawner;

    private void Start()
    {
        // Init the game manager
        _manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        // Init the spawner class
        _spawner = GameObject.Find("SpawnPoints").GetComponent<EnemySpawner>();
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the player has entered the collider and spawn not started
        if (other.gameObject.CompareTag("Player") && !_manager.SpawnStarted)
        {
            // Call the start courutine method
            _spawner.StartSpawnZombie();

            // Set true value to SpawnStarted
            _manager.SpawnStarted = true;
        }
    }
}

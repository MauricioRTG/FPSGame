using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [SerializeField] GameObject[] spawnerObjects;
    // Start is called before the first frame update
    void Start()
    {
        spawnerObjects = GameObject.FindGameObjectsWithTag("EnemySpawner");
        StartRound();
    }

    private void StartRound()
    {
        foreach (GameObject spawnerObject in spawnerObjects)
        {
            if(spawnerObject.TryGetComponent<EnemySpawner>(out var spawner))
            {
                spawner.ToggleSpawning();
            }
        }
    }
}

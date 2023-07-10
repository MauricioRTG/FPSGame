using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] GameObject[] spawnerObjects;
    [SerializeField] int destroyedEnemiesCount;
    [SerializeField] int enemiesDestroyedLimit;

    // Start is called before the first frame update
    void Start()
    {
        spawnerObjects = GameObject.FindGameObjectsWithTag("EnemySpawner");
        enemiesDestroyedLimit = spawnerObjects.Length * EnemySpawner.enemiesSpawnLimit;
    }

    void Update()
    {
        if(destroyedEnemiesCount == enemiesDestroyedLimit)
        {
            EndWave();
        }
    }

    public void StartWave()
    {
        foreach (GameObject spawnerObject in spawnerObjects)
        {
            if(spawnerObject.TryGetComponent<EnemySpawner>(out var spawner))
            {
                spawner.ToggleSpawning();
            }
        }
    }

    public void EndWave()
    {
        foreach (GameObject spawnerObject in spawnerObjects)
        {
            if (spawnerObject.TryGetComponent<EnemySpawner>(out var spawner))
            {
                spawner.ToggleSpawning();
            }
        }
        ResetDestroyedEnemiesCount();
    }

    public void IncreaseDestroyedEnemiesCount()
    {
        destroyedEnemiesCount++;
    }

    public void ResetDestroyedEnemiesCount()
    {
        destroyedEnemiesCount = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float spawnInterval = 10f;
    [SerializeField] Transform spawnPoint; 
    [SerializeField] bool isSpawning = false;
    private Coroutine spawnCoroutine;

    [SerializeField] public static readonly int enemiesSpawnLimit = 3;
    [SerializeField] int enemiesSpawned;

    private const int Zero = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            ToggleSpawning();
        }
    }

    private IEnumerator SpawnEnemyRoutine()
    {
        while (isSpawning && enemiesSpawned < enemiesSpawnLimit)
        {
            Instantiate(enemy, transform.position, transform.rotation);
            enemiesSpawned++;
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void ToggleSpawning()
    {
        isSpawning = !isSpawning;

        if (isSpawning && spawnCoroutine == null)
        {
            spawnCoroutine = StartCoroutine(SpawnEnemyRoutine());
        }
        else if(!isSpawning && spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
            enemiesSpawned = Zero;
        }
    }
}

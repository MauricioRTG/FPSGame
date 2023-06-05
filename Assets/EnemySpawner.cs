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
        while (isSpawning)
        {
            Instantiate(enemy, transform.position, transform.rotation);
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
        }
    }
}

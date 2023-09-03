using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] GameObject[] spawnerObjects;
    [SerializeField] RoundManager roundManager;
    [SerializeField] int destroyedEnemiesCount;
    [SerializeField] int enemiesDestroyedLimit;
    [SerializeField] int enemiesRemaining;
    [SerializeField] bool waveEnded = false;

    //UI
    [SerializeField] TextMeshProUGUI enemiesRemainingText;

    // Start is called before the first frame update
    void Start()
    {
        spawnerObjects = GameObject.FindGameObjectsWithTag("EnemySpawner");
        roundManager = FindObjectOfType<RoundManager>();
        enemiesDestroyedLimit = spawnerObjects.Length * EnemySpawner.enemiesSpawnLimit;
    }

    void Update()
    {

        UpdateEnemiesRemainingUI();
        
        if(destroyedEnemiesCount == enemiesDestroyedLimit && !waveEnded)
        {
            EndWave();
        }
    }

    public void StartWave()
    {
        waveEnded = false;

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
        waveEnded = true;

        foreach (GameObject spawnerObject in spawnerObjects)
        {
            if (spawnerObject.TryGetComponent<EnemySpawner>(out var spawner))
            {
                spawner.ToggleSpawning();
            }
        }

        StopCoroutine(roundManager.StartNextWave());

        StartCoroutine(roundManager.StartNextWave());
    }

    public void IncreaseDestroyedEnemiesCount()
    {
        destroyedEnemiesCount++;
    }

    public void ResetDestroyedEnemiesCount()
    {
        destroyedEnemiesCount = 0;
    }

    private void UpdateEnemiesRemainingUI()
    {
        //Update enemies remaining UI
        enemiesRemaining = enemiesDestroyedLimit - destroyedEnemiesCount;
        enemiesRemainingText.text = "Enemies Remaining: " + enemiesRemaining.ToString() + "/" + enemiesDestroyedLimit.ToString();
    }
}

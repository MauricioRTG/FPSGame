using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour
{
    [SerializeField] WaveManager waveManager;
    [SerializeField] int maxWavesAmount = 3;
    [SerializeField] int waveCount;
    [SerializeField] float waveInterval = 10f;
    [SerializeField] public int currentRound;
    // Start is called before the first frame update
    void Start()
    {
        waveManager = FindObjectOfType<WaveManager>();
        if(waveManager != null)
        {
            StartRound();
        }
    }

    private void StartRound()
    {
        currentRound++;
        StartCoroutine(StartNextWave());
    }

    public IEnumerator StartNextWave()
    {
        yield return new WaitForSeconds(waveInterval);
        if (waveCount < maxWavesAmount)
        {
            waveCount++;
            waveManager.StartWave();
        }
        else
        {
            //TODO: Finish round (opens portal)
        }
    }

    public static void RestartRound()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}

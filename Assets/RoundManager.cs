using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    [SerializeField] WaveManager waveManager;
    [SerializeField] int maxWavesAmount = 3;
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
        waveManager.StartWave();
    }
}

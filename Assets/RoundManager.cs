using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
    [SerializeField] WaveManager waveManager;
    [SerializeField] private int maxWavesAmount = 3;
    [SerializeField] private int waveCount;
    public int MaxWavesAmount => maxWavesAmount;
    public int WaveCount => waveCount;
    [SerializeField] float waveInterval = 10f;
    [SerializeField] public int currentRound;

    //UI
    [SerializeField] TextMeshProUGUI roundNumberText;
    [SerializeField] GameObject[] waveIconGameObjects;

    //Portal
    [SerializeField] Portal portal;

    // Start is called before the first frame update
    void Start()
    {
        waveManager = FindObjectOfType<WaveManager>();
        if(waveManager != null)
        {
            StartRound();
        }

        portal = FindObjectOfType<Portal>();

        //UI 
        //waveIconGameObjects = GameObject.FindGameObjectsWithTag("WaveIcon");
    }

    private void Update()
    {
        //Update current round UI
        roundNumberText.text = currentRound.ToString();

        //Update current wave UI
        for(int i = 0; i < waveCount; i++)
        {
            Image waveIconImage = waveIconGameObjects[i].GetComponent<Image>();
            waveIconImage.color = Color.blue;
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
            waveManager.ResetDestroyedEnemiesCount();
            waveCount++;
            waveManager.StartWave();
        }
        else
        {
            //Waves ended
            portal.ActivatePortal();
        }
    }

    public static void RestartRound()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}

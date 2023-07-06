using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplayTMP : MonoBehaviour
{
    [SerializeField] ScoreManager score;
    [SerializeField] TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<ScoreManager>();
        scoreText = GetComponent<TextMeshProUGUI>();
        if (scoreText == null)
        {
            Debug.LogError("ScoreDisplayTMP : TextMeshProUGUI component not found");
        }
        if (score == null )
        {
            Debug.LogError("ScoreDisplayTMP : ScoreManager component not found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ScoreValue.ToString();
    }
}

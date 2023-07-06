using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int scoreValue;

    public int ScoreValue
    {
        get { return scoreValue; }
        set { scoreValue = value; }
    }

    public void AddPoints(int points)
    {
        scoreValue += points;
    }

    public void ResetScore()
    {
        scoreValue = 0;
    }
}

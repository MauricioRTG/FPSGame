using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] ScoreManager score;
    [SerializeField] int enemyPoints = 50;
    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<ScoreManager>();
        if (score == null)
        {
            Debug.LogError("Enemy : ScoreManager component not found");
        }

        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        score.AddPoints(enemyPoints);
        Destroy(gameObject);
    }
}

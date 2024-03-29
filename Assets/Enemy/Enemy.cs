using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] ScoreManager score;
    [SerializeField] int enemyPoints = 50;
    [SerializeField] WaveManager waveManager;
    [SerializeField] DropItem dropItem;
    [SerializeField] bool enemyDied = false; //Helps avoiding calling the function die multiple times, and that enemy dies only once

    // Start is called before the first frame update
    void Start()
    {

        waveManager = FindObjectOfType<WaveManager>();
        if (waveManager == null)
        {
            Debug.LogError("Enemy : WaveManager component not found");
        }

        score = FindObjectOfType<ScoreManager>();
        if (score == null)
        {
            Debug.LogError("Enemy : ScoreManager component not found");
        }

        dropItem = GetComponent<DropItem>();
        if(dropItem == null)
        {
            Debug.LogError("Enemy : DropItem component not found");
        }

        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if(currentHealth <= 0 && !enemyDied)
        {
            enemyDied = true;
            //Drop a random item or none
            dropItem.DropPickupItem(transform.position);
            Die();
        }
    }

    public void Die()
    {
        score.AddPoints(enemyPoints);
        waveManager.IncreaseDestroyedEnemiesCount();
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] int minHealth = 0;
    [SerializeField] int health;
    [SerializeField] Image healthImage;
    private RectTransform healthImageRectTransform;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthImageRectTransform = healthImage.GetComponent<RectTransform>();
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        DecreaseUIHealth(damageAmount);
        if (health <= minHealth)
        {
            Die();
        }
    }

    private void Die()
    {
        RoundManager.RestartRound();
    }

    private void DecreaseUIHealth(int damageAmount)
    {
        float newHeight = healthImageRectTransform.sizeDelta.y - damageAmount;
        if(healthImageRectTransform != null)
        {
            healthImageRectTransform.sizeDelta = new Vector2(healthImageRectTransform.sizeDelta.x, newHeight);
        }
    }
}

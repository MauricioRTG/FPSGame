using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] int minHealth = 0;
    [SerializeField] int health;
    //UI
    [SerializeField] Image healthImage;
    private RectTransform healthImageRectTransform;

    [SerializeField] int maxStamina = 100;
    [SerializeField] int minStamina = 0;
    [SerializeField] int stamina;
    public int Stamina
    {
        get { return stamina; }
    }
    //UI
    [SerializeField] Image staminaImage;
    private RectTransform staminaImageRectTransform;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthImageRectTransform = healthImage.GetComponent<RectTransform>();

        stamina = maxStamina;
        staminaImageRectTransform = staminaImage.GetComponent<RectTransform>();
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

    public void IncreaseHealth(int amount)
    {
        //Increase stamina but if it increases more that maxhealth, set health to maxhealth
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        IncreaseUIHealth(amount);
    }

    private void IncreaseUIHealth(int amount)
    {
        float newHeight = healthImageRectTransform.sizeDelta.y + amount;
        if (newHeight > maxHealth)
        {
            newHeight = maxHealth;
        }

        if (healthImageRectTransform != null)
        {
           healthImageRectTransform.sizeDelta = new Vector2(healthImageRectTransform.sizeDelta.x, newHeight);
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

    public void DecreseStamina(int amount)
    {
        stamina -= amount;
        if (stamina < minStamina)
        {
            stamina = minStamina;
        }
        DecreceUIStamina(amount);
    }

    private void DecreceUIStamina(int amount)
    {
        float newHeight = staminaImageRectTransform.sizeDelta.y - amount;
        if(staminaImageRectTransform != null)
        {
            staminaImageRectTransform.sizeDelta = new Vector2(staminaImageRectTransform.sizeDelta.x, newHeight);
        }
    }

    public void IncreaseStamina(int amount)
    {
        //Increase stamina but if it increases more that maxStamina, set stamina to max stamina anf not increase the UI Stamina bar.
        stamina += amount;
        if (stamina > maxStamina)
        {
            stamina = maxStamina;
        }
        IncreaseUIStamina(amount);
    }

    private void IncreaseUIStamina(int amount)
    {
        float newHeight = staminaImageRectTransform.sizeDelta.y + amount;
        if (newHeight > maxStamina)
        {
            newHeight = maxStamina;
        }

        if (staminaImageRectTransform != null)
        {
            staminaImageRectTransform.sizeDelta = new Vector2(staminaImageRectTransform.sizeDelta.x, newHeight);
        }
    }
}

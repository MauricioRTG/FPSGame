using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //Health
    [SerializeField] int maxHealth = 100;
    [SerializeField] int minHealth = 0;
    [SerializeField] int health;
    //Health UI
    [SerializeField] Image healthImage;
    private RectTransform healthImageRectTransform;

    //Stamina
    [SerializeField] int maxStamina = 100;
    [SerializeField] int minStamina = 0;
    [SerializeField] int stamina;
    public int Stamina
    {
        get { return stamina; }
    }
    //Stamina UI
    [SerializeField] Image staminaImage;
    private RectTransform staminaImageRectTransform;

    //Ammunition
    [SerializeField] public int projectileAmount;
    [SerializeField] int remainingProjectileAmountInMagazine;
    [SerializeField] ActiveProjectile activeProjectile;
    [SerializeField] WeaponAmmunition weaponAmmunition;
    //Ammunition UI
    [SerializeField] TextMeshProUGUI projectileUIText;

    //Weapon
    //[SerializeField] SwitchWeapon switchWeapon;


    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthImageRectTransform = healthImage.GetComponent<RectTransform>();

        stamina = maxStamina;
        staminaImageRectTransform = staminaImage.GetComponent<RectTransform>();

        //switchWeapon = FindObjectOfType<SwitchWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get current weapon ammunition script
        if (weaponAmmunition == null)
        {
            weaponAmmunition = FindObjectOfType<WeaponAmmunition>(); //TODO: Based in the current weapon that the player has
        }

        //Get the ammunition and remaining ammunition amount in magazine from the current weapon
        projectileAmount = weaponAmmunition.ammunitionAmount;
        remainingProjectileAmountInMagazine = weaponAmmunition.remainingAmmunitionAmountInMagazine;
        //Update ammunition UI with the current weapon ammunition
        UpdateProjectileUIAmount();

        //Get bullet or projectile instantiation script component from the current weapon GameObject
        if (activeProjectile == null)
        {
            activeProjectile = FindObjectOfType<ActiveProjectile>(); //TODO: Based in the current weapon that the player has
        }
        
        //Instantiate bullets when firing weapon
        if (Input.GetButtonDown("Fire1"))
        {
            if (projectileAmount > 0)
            {
                activeProjectile.InstantiateProjectile();
                UpdateProjectileUIAmount();
            }
        }

        //Reload
        if (Input.GetKeyDown(KeyCode.R))
        {
            weaponAmmunition.Reload();
            UpdateProjectileUIAmount();
        }
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
        //Caps stamina value so it doesn't decreases more than the minStamina value
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

    /*private void Reload()
    {
        projectileAmount = remainingProjectileAmountInMagazine;
        remainingProjectileAmountInMagazine = 0;
    }*/

    private void UpdateProjectileUIAmount()
    {
        /*String currentWeaponTag = switchWeapon.CurrentWeapon.tag;

        if(currentWeaponTag != null)
        {
            switch (currentWeaponTag)
            {
                case "Pistol":
                    projectileUIText.text = projectileAmount.ToString() + "/" + remainingProjectileAmountInMagazine.ToString();
                    break;
                case "Shotgun":
                    projectileUIText.text = projectileAmount.ToString() + "/" + remainingProjectileAmountInMagazine.ToString();
                    break;
            }
        }*/
        projectileUIText.text = projectileAmount.ToString() + "/" + remainingProjectileAmountInMagazine.ToString();
    }

    /*private void GetCurrentWeaponInScene()
    {
        String currentWeaponTag = switchWeapon.CurrentWeapon.tag;

        if(currentWeaponTag != null)
        {
            switch (currentWeaponTag)
            {
                case "Pistol":
                    projectileUIText.text = projectileAmount.ToString() + "/" + remainingProjectileAmountInMagazine.ToString();
                    break;
                case "Shotgun":
                    projectileUIText.text = projectileAmount.ToString() + "/" + remainingProjectileAmountInMagazine.ToString();
                    break;
            }
        }
    }*/

}

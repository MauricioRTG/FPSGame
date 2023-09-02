using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class PlayerPickupItem : MonoBehaviour
{

    [SerializeField] Player player;
    [SerializeField] Shotgun shotgun;
    [SerializeField] Pistol pistol;
    [SerializeField] LayerMask defaultLayerMask;
    public PickupItemEventManager pickupItemEventManager;

    private void Start()
    {
        player = GetComponent<Player>();
        pickupItemEventManager = FindObjectOfType<PickupItemEventManager>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        //Checks if the player collided with a gameobject that has a ShotgunAmmunitionItem, PistolAmmunitionItem or HealhtItem script
        if (collision.gameObject.TryGetComponent(out ShotgunAmmunitionItem shotgunAmmunitionItem))
        {
            //Add ammunition to player's shotgun
            int ammunitionToAdd = shotgunAmmunitionItem.ammunitionAmount;
            
            AddAmmunitionToShotgun(ammunitionToAdd);

            //Destroy and unsubscribe item after is collected
            pickupItemEventManager.Unsubscribe(collision.gameObject);
            Destroy(collision.gameObject);
            
        }
        else if (collision.gameObject.TryGetComponent(out PistolAmmunitionItem pistolAmmunitionItem))
        {
            //Add ammunition to player's pistol
            int ammunitionToAdd = pistolAmmunitionItem.ammunitionAmount;
            
            AddAmmunitionToPistol(ammunitionToAdd);
            //Destroy and unsubscribe item after is collected
            pickupItemEventManager.Unsubscribe(collision.gameObject);
            Destroy(collision.gameObject);
            //collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.TryGetComponent(out HealthItem healthItem))
        {
            //Add health to player
            int healthToAdd = healthItem.healthValue;
            AddHealthToPlayer(healthToAdd);

            //Destroy and unsubscribe item after is collected
            pickupItemEventManager.Unsubscribe(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }

    private void AddAmmunitionToShotgun(int amount)
    {
        shotgun.AddAmmunition(amount);
    }

    private void AddAmmunitionToPistol(int amount)
    {
        pistol.AddAmmunition(amount);
    }

    private void AddHealthToPlayer(int amount)
    {
        player.IncreaseHealth(amount);
    }

    private bool ThereIsSpaceForAmmunitionToBeStoredInShotgun(int ammunitionToAdd)
    {
        int newRemainingAmmunitionStoredAmount = shotgun.weaponAmmunition.remainingAmmunitionStored + ammunitionToAdd;

        if(newRemainingAmmunitionStoredAmount < shotgun.weaponAmmunition.MaxAmmunitionAmountStored)
        {
            return true;
        }
        
        return false;
    }

    private bool ThereIsSpaceForAmmunitionToBeStoredInPistol(int ammunitionToAdd)
    {
        int newRemainingAmmunitionStoredAmount = pistol.weaponAmmunition.remainingAmmunitionStored + ammunitionToAdd;

        if(newRemainingAmmunitionStoredAmount < pistol.weaponAmmunition.MaxAmmunitionAmountStored)
        {
            return true;
        }

        return false;
    }
}

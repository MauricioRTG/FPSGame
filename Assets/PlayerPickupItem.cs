using System.Collections;
using System.Collections.Generic;
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
        //Checks if the player collided with a gameobject that has a ShotgunAmmunitionItem or HealhtItem script
        if (collision.gameObject.TryGetComponent(out ShotgunAmmunitionItem shotgunAmmunitionItem))
        {
            //Add ammunition to player
            int ammunitionToAdd = shotgunAmmunitionItem.ammunitionAmount;
            if (ThereIsSpaceForAmmunitionToBeStored(ammunitionToAdd))
            {
                AddAmmunitionToShotgun(ammunitionToAdd);

                //Destroy and unsubscribe item after is collected
                pickupItemEventManager.Unsubscribe(shotgunAmmunitionItem);
                Destroy(collision.gameObject);
            }
        }
        else if (collision.gameObject.TryGetComponent(out HealthItem healthItem))
        {
            //Add health to player
            int healthToAdd = healthItem.healthValue;
            AddHealthToPlayer(healthToAdd);

            //Destroy and unsubscribe item after is collected
            pickupItemEventManager.Unsubscribe(healthItem);
            Destroy(collision.gameObject);
        }
    }

    private void AddAmmunitionToShotgun(int amount)
    {
        shotgun.AddAmmunition(amount);
    }

    private void AddAmmunitionToPistol(int amount)
    {
        
    }

    private void AddHealthToPlayer(int amount)
    {
        player.IncreaseHealth(amount);
    }

    private bool ThereIsSpaceForAmmunitionToBeStored(int ammunitionToAdd)
    {
        int newRemainingAmmunitionStoredAmount = shotgun.weaponAmmunition.remainingAmmunitionStored + ammunitionToAdd;

        if(newRemainingAmmunitionStoredAmount < shotgun.weaponAmmunition.MaxAmmunitionAmountStored)
        {
            return true;
        }
        
        return false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickupItem : MonoBehaviour
{

    [SerializeField] Player player;
    [SerializeField] Shotgun shotgun;
    [SerializeField] Pistol pistol;
    [SerializeField] LayerMask defaultLayerMask;

    private void Start()
    {
        player = GetComponent<Player>();

    }

    public void Update()
    {
        //TODO: Make the Item not collide when the health or ammunition storage are full
        //(Maybe i have to do a virtual function for each item to make sure the item can be picked up, satifying especific conditions about that item
        //If item can be picked up
        //enable collider with player
        //if not, diable collider with player
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Checks if the player collided with a gameobject that has a ShotgunAmmunitionItem or HealhtItem script
        if (collision.gameObject.TryGetComponent(out ShotgunAmmunitionItem shotgunAmmunitionItem))
        {
            //Get boxCollider Inside ShotgunAmmunitionItem
            //CapsuleCollider playerCapsuleCollider = player.gameObject.GetComponent<CapsuleCollider>();
            
            //Add ammunition to player
            int ammunitionToAdd = shotgunAmmunitionItem.ammunitionAmount;
            if (ThereIsSpaceForAmmunitionToBeStored(ammunitionToAdd))
            {

                //playerCapsuleCollider.excludeLayers = defaultLayerMask;

                AddAmmunitionToShotgun(ammunitionToAdd);
                //Destroy item after is collected
                Destroy(collision.gameObject);
            }
            else
            {
                //playerCapsuleCollider.excludeLayers = collision.gameObject.layer;
            }
        }
        else if (collision.gameObject.TryGetComponent(out HealthItem healthItem))
        {
            //Add health to player
            int healthToAdd = healthItem.healthValue;
            AddHealthToPlayer(healthToAdd);

            //Destroy item after is collected
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

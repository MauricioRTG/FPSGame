using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolAmmunitionItem : PickupItem
{
    public int ammunitionAmount;
    BoxCollider boxCollider;
    int remainingPistolAmmunitionStored;
    int maxPistolAmmunitionStored;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.enabled = false;
        pickupItemEventManager = FindObjectOfType<PickupItemEventManager>();
        pickupItemEventManager.NotifySubscribers(pickupItemType.PistolAmmunition);
    }
    public override void UseItem()
    {
        base.UseItem();
    }

    public override void UpdateFromSubject(ISubject subject)
    {
        Debug.Log("PistolAmmunitionItem collider updated");
        pickupItemEventManager = (PickupItemEventManager)subject;

        if(pickupItemEventManager.pistol != null && pickupItemEventManager.pistol.weaponAmmunition != null)
        {
            remainingPistolAmmunitionStored = pickupItemEventManager.pistol.weaponAmmunition.remainingAmmunitionStored;
            maxPistolAmmunitionStored = pickupItemEventManager.pistol.weaponAmmunition.MaxAmmunitionAmountStored;

            if (boxCollider != null)
            {
                if (remainingPistolAmmunitionStored >= maxPistolAmmunitionStored)
                {
                    boxCollider.enabled = false;
                }
                else
                {
                    boxCollider.enabled = true;
                }
            }
        }
        else
        {
            //If there is no pistol active then don't allow the player to collide with the item
            boxCollider.enabled = false;
        }
    }
}

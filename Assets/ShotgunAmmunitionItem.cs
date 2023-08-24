using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunAmmunitionItem : PickupItem
{
    public int ammunitionAmount;
    [SerializeField] PickupItemEventManager pickupItemEventManager;
    [SerializeField] BoxCollider boxCollider;
    [SerializeField] int remainingShotgunAmmunitionStored;
    [SerializeField] int maxShotgunAmmunition;
    public override void UseItem()
    {
        base.UseItem();
    }

    public override void UpdateFromSubject(ISubject subject)
    {
        Debug.Log("ShotgunAmmunitionItem collider updated");
        pickupItemEventManager = (PickupItemEventManager)subject;
        boxCollider = GetComponent<BoxCollider>();

        remainingShotgunAmmunitionStored = pickupItemEventManager.shotgun.weaponAmmunition.RemainingAmmunitionStored;
        maxShotgunAmmunition = pickupItemEventManager.shotgun.weaponAmmunition.MaxAmmunitionAmountStored;

        if(boxCollider != null)
        {
            if (remainingShotgunAmmunitionStored >= maxShotgunAmmunition)
            {
                boxCollider.enabled = false;
            }
            else
            {
                boxCollider.enabled = true;
            }
        }
    }
}

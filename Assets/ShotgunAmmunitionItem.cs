using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunAmmunitionItem : PickupItem
{
    public int ammunitionAmount;
    [SerializeField] BoxCollider boxCollider;
    [SerializeField] int remainingShotgunAmmunitionStored;
    [SerializeField] int maxShotgunAmmunition;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.enabled = false;
        pickupItemEventManager = FindObjectOfType<PickupItemEventManager>();
        pickupItemEventManager.NotifySubscribers(pickupItemType.ShotgunAmmunition);
    }
    public override void UseItem()
    {
        base.UseItem();
    }

    public override void UpdateFromSubject(ISubject subject)
    {
        Debug.Log("ShotgunAmmunitionItem collider updated");
        pickupItemEventManager = (PickupItemEventManager)subject;
        boxCollider = GetComponent<BoxCollider>();

        if (pickupItemEventManager.shotgun != null && pickupItemEventManager.shotgun.weaponAmmunition != null)
        {
            remainingShotgunAmmunitionStored = pickupItemEventManager.shotgun.weaponAmmunition.RemainingAmmunitionStored;
            maxShotgunAmmunition = pickupItemEventManager.shotgun.weaponAmmunition.MaxAmmunitionAmountStored;

            if (boxCollider != null)
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
        else
        {
            //If there is no shotgun active then don't allow the player to collide with the item
            boxCollider.enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolAmmunitionItem : PickupItem
{
    public int ammunitionAmount;
    PickupItemEventManager pickupItemEventManager;
    BoxCollider boxCollider;
    int remainingPistolAmmunitionStored;
    int maxPistolAmmunitionStored;

    public override void UseItem()
    {
        base.UseItem();
    }

    /*public override void UpdateFromSubject(ISubject subject)
    {
        Debug.Log("PistolAmmunitionItem collider updated");
        pickupItemEventManager = (PickupItemEventManager)subject;
        boxCollider = GetComponent<BoxCollider>();

        remainingPistolAmmunitionStored = pickupItemEventManager

    }*/

}

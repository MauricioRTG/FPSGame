using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunAmmunitionItem : PickupItem
{
    public int ammunitionAmount;

    public override void UseItem()
    {
        base.UseItem();
    }

    public override void UpdateFromSubject(ISubject subject)
    {

    }
}

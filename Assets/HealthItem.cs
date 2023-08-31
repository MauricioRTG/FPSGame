using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : PickupItem
{
    public int healthValue;
    [SerializeField] BoxCollider boxCollider;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.enabled = false;
    }

    public override void UseItem()
    {
        base.UseItem();
    }

    public override void UpdateFromSubject(ISubject subject) 
    {
        Debug.Log("HealthItem Collider updated");
        PickupItemEventManager pickupItemEventManager = (PickupItemEventManager)subject;

        if(boxCollider != null)
        {
            if (pickupItemEventManager.player.Health >= pickupItemEventManager.player.MaxHealth)
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

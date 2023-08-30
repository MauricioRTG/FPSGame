using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupItem : MonoBehaviour, IObserver
{
    public string itemName;
    public int itemValue;
    
    protected PickupItemEventManager pickupItemEventManager;

    void Start()
    {
        pickupItemEventManager = FindObjectOfType<PickupItemEventManager>();
    }
    public virtual void UpdateFromSubject(ISubject subject) { }
    public virtual void UseItem() { }

    public virtual IEnumerator DestroyPickupItem(GameObject pickupItem, float pickupItemDuration)
    {
        yield return new WaitForSeconds(pickupItemDuration);
        Destroy(pickupItem);
        Debug.Log("Object destroyed: " + pickupItem.name);
    }
}

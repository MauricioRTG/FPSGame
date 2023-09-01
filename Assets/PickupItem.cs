using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupItem : MonoBehaviour, IObserver
{
    public string itemName;
    public int itemValue;
    [SerializeField] public float itemDuration = 5.0f;
    [SerializeField] public bool destroyAfterSpecifiedDuration = true;

    protected PickupItemEventManager pickupItemEventManager;

    void Start()
    {
        pickupItemEventManager = FindObjectOfType<PickupItemEventManager>();
    }
    public virtual void UpdateFromSubject(ISubject subject) { }
    public virtual void UseItem() { }
}

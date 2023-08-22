using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour, IObserver
{
    public string itemName;
    public int itemValue;

    public virtual void UpdateFromSubject(ISubject subject) { }
    public virtual void UseItem() { }
}

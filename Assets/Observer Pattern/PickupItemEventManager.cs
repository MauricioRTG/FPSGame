using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItemEventManager : MonoBehaviour, ISubject
{
    [SerializeField] private List<PickupItem> _items;

    public void NotifySubscribers()
    {
        foreach(PickupItem item in _items)
        {
            item.UpdateFromSubject(this);
        }
    }

    public void Subscribe(IObserver observer)
    {
        _items.Add((PickupItem)observer);
    }

    public void Unsubscribe(IObserver observer)
    {
        _items.Remove((PickupItem)observer);
    }
}

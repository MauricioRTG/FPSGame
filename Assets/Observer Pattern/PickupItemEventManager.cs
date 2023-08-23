using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum pickupItemType { Health, ShotgunAmmunition};

public class PickupItemEventManager : MonoBehaviour, ISubject
{
    [SerializeField] private List<PickupItem> _items;
    public Player player;

    void Start()
    {
        //Finds all PickupItem in scene an subscribe them to PickupItemEventManager subject
        PickupItem[] itemsInScenes = FindObjectsOfType<PickupItem>();
        foreach (var item in itemsInScenes) 
        { 
            Subscribe(item);
        };

        player = FindObjectOfType<Player>();
    }

    public void NotifySubscribers(pickupItemType pickupItemType)
    {
        foreach(PickupItem item in _items)
        {
            if( item is HealthItem && pickupItemType == pickupItemType.Health)
            {
                item.UpdateFromSubject(this);
            }
            else if(item is ShotgunAmmunitionItem && pickupItemType == pickupItemType.ShotgunAmmunition)
            {
                item.UpdateFromSubject(this);
            }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum pickupItemType { Health, ShotgunAmmunition, PistolAmmunition};

public class PickupItemEventManager : MonoBehaviour, ISubject
{
    [SerializeField] public List<GameObject> _items;
    public Player player;
    [SerializeField] public Shotgun shotgun;
    [SerializeField] public Pistol pistol;

    void Start()
    {
        //Finds all PickupItem in scene an subscribe them to PickupItemEventManager subject
        PickupItem[] itemsInScenes = FindObjectsOfType<PickupItem>();
        foreach (var item in itemsInScenes) 
        { 
            Subscribe(item.gameObject);
        };

        player = FindObjectOfType<Player>();
    }

    public void NotifySubscribers(pickupItemType pickupItemType)
    {
        foreach(GameObject item in _items)
        {
            //Makes sure that only the wanted items are called inside the item array
            if (item.TryGetComponent<HealthItem>(out HealthItem healthItem) && pickupItemType == pickupItemType.Health)
            {
                healthItem.UpdateFromSubject(this);
            }
            else if (item.TryGetComponent<ShotgunAmmunitionItem>(out ShotgunAmmunitionItem shotgunAmmunitionItem) && pickupItemType == pickupItemType.ShotgunAmmunition)
            {
                shotgunAmmunitionItem.UpdateFromSubject(this);
            }
            else if (item.TryGetComponent<PistolAmmunitionItem>(out PistolAmmunitionItem pistolAmmunitionItem) && pickupItemType == pickupItemType.PistolAmmunition)
            {
                pistolAmmunitionItem.UpdateFromSubject(this);
            }
        }
    }

    public void Subscribe(GameObject observer)
    {
        _items.Add(observer);

        PickupItem pickupItemType = ObtainPickupItemType(observer);
        if (pickupItemType.destroyAfterSpecifiedDuration)
        {
            //Start coroutine that destroys item after a specified duration
            StartCoroutine(DestroyPickupItem(observer, pickupItemType.itemDuration));
        }
    }

    public void Unsubscribe(GameObject observer)
    {
        _items.Remove(observer);    
    }

    public IEnumerator DestroyPickupItem(GameObject observer, float pickupItemDuration)
    {
        yield return new WaitForSeconds(pickupItemDuration);
        Unsubscribe(observer);
        Debug.Log("Item unsubscribed");
        //yield return new WaitForSeconds(pickupItemDuration);
        Destroy(observer);
        Debug.Log("Item Destroyed");
    }

    public PickupItem ObtainPickupItemType(GameObject pickupItem)
    {
        if(pickupItem.TryGetComponent<ShotgunAmmunitionItem>(out ShotgunAmmunitionItem shotgunAmmunitionItem))
        {
            return shotgunAmmunitionItem;
        }
        else if (pickupItem.TryGetComponent<PistolAmmunitionItem>(out PistolAmmunitionItem pistolAmmunitionItem))
        {
            return pistolAmmunitionItem;
        }
        else if (pickupItem.TryGetComponent<HealthItem>(out HealthItem healthItem))
        {
            return healthItem;
        }
        else
        {
            return null;
        }
    }
}

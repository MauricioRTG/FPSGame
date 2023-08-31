using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField] GameObject healthItemPrefab;
    [SerializeField] GameObject pistolAmmunitionItemPrefab;
    [SerializeField] GameObject shotgunAmmunitionItemPrefab;
    PickupItemEventManager pickupItemEventManager;
    [SerializeField] GameObject newHealthItem;
    [SerializeField] GameObject newPistolAmmunitionItem;
    [SerializeField] GameObject newShotgunAmmunitionItem;

    void Start()
    {
       pickupItemEventManager = FindObjectOfType<PickupItemEventManager>();
    }

    public void DropPickupItem(Vector3 dropPosition)
    {
        int randomValue = Random.Range(0, 11); //11 will not appear

        if(randomValue < 5) //50% possibility 5/10
        {
            //Don't drop item
            Debug.Log("No item droped");
            return;
        }
        else if(randomValue < 7) //20%
        {
            newHealthItem = Instantiate(healthItemPrefab, dropPosition, Quaternion.identity);
            pickupItemEventManager.Subscribe(newHealthItem);
            pickupItemEventManager.NotifySubscribers(pickupItemType.Health);

        }
        else if (randomValue < 9) //20%
        {
            newPistolAmmunitionItem = Instantiate(pistolAmmunitionItemPrefab, dropPosition, Quaternion.identity);
            pickupItemEventManager.Subscribe(newPistolAmmunitionItem);
            pickupItemEventManager.NotifySubscribers(pickupItemType.PistolAmmunition);
        }
        else if (randomValue < 11) //20%
        {
            newShotgunAmmunitionItem = Instantiate(shotgunAmmunitionItemPrefab, dropPosition, Quaternion.identity);
            pickupItemEventManager.Subscribe(newShotgunAmmunitionItem);
            pickupItemEventManager.NotifySubscribers(pickupItemType.ShotgunAmmunition);
        }
    }

    /*private void InstantiatePickupItem(Vector3 dropPosition, GameObject itemPrefab)
    {
        //Drop healthItem
        GameObject newItem = Instantiate(itemPrefab, dropPosition, Quaternion.identity);
        pickupItemEventManager.Subscribe(newItem.GetComponent<HealthItem>());
    }*/

}

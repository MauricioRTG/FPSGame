using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAmmunition : MonoBehaviour
{

    [SerializeField] int maxAmmunitionAmount = 30;
    [SerializeField] int minAmmunitionAmount;
    [SerializeField] int maxAmmunitionAmountStored = 50;
    [SerializeField] public int ammunitionAmount;
    [SerializeField] public int remainingAmmunitionStored;
    private PickupItemEventManager pickupItemEventManager;

    public int MaxAmmunitionAmount { get => maxAmmunitionAmount; }
    public int MaxAmmunitionAmountStored { get => maxAmmunitionAmountStored; }

    public int RemainingAmmunitionStored { get => remainingAmmunitionStored; }
    public int AmmunitionAmount { get => ammunitionAmount; }

    // Start is called before the first frame update
    void Start()
    {
        ammunitionAmount = maxAmmunitionAmount;
        remainingAmmunitionStored = maxAmmunitionAmountStored;
        pickupItemEventManager = FindObjectOfType<PickupItemEventManager>();
    }

    public void Reload()
    {
        //Do not reload when the the remainingAmmunitionStored is empty (equal to 0)
        if(remainingAmmunitionStored <= 0)
        {
            return;
        }

        //If the ammunition in magazine is full, do not reload
        if(ammunitionAmount < MaxAmmunitionAmount)
        {
            //Ammunition Amount 2, RemainingAmmunitonStored 10, MaxAmmunition 10
            //Expected result: Ammunition Amount 10, RemainingAmmunitonStored 2, MaxAmmunition 10
            int valueToAddToWeaponMagazine = remainingAmmunitionStored - ammunitionAmount; //10-2=8
            if (valueToAddToWeaponMagazine != remainingAmmunitionStored)
            {
                int sum = valueToAddToWeaponMagazine + ammunitionAmount;
                /*If the sum is greater than the MaxAmmunition calculate the difference again but between
                 * MaxAmmunitionAmount and ammunitionAmount (this happens when MaxAmmunitionAmountStored is greater than the MaxAmmunitonAmount)*/
                if (sum > MaxAmmunitionAmount)
                {
                    int valueToAddWhenSumIsGreaterThanMaxAmmunitionAmount = MaxAmmunitionAmount - ammunitionAmount;
                    ammunitionAmount += valueToAddWhenSumIsGreaterThanMaxAmmunitionAmount;
                    remainingAmmunitionStored = remainingAmmunitionStored - valueToAddWhenSumIsGreaterThanMaxAmmunitionAmount; //
                }
                else
                {
                    ammunitionAmount += valueToAddToWeaponMagazine;
                    remainingAmmunitionStored = remainingAmmunitionStored - valueToAddToWeaponMagazine; //10-8=2
                }  
            }
            else
            {
                //This happends when the ammunition in the magazine is empty (is equal to 0)
                ammunitionAmount += remainingAmmunitionStored;
                remainingAmmunitionStored = 0;
            }

            //Update ShotgunAmmunitionItems' or PistolAmmunirionItems' Collider
            if (TryGetComponent<Pistol>(out Pistol pistol))
            {
                pickupItemEventManager.NotifySubscribers(pickupItemType.PistolAmmunition);
            }
            else if (TryGetComponent<Shotgun>(out Shotgun shotgun))
            {
                pickupItemEventManager.NotifySubscribers(pickupItemType.ShotgunAmmunition);
            }
        }
    }

    void Update()
    {
        /* This make sure that the ammunition left in the chamber is not less than 0
         * In this way the player can shoot the especified bullets, for example 8 pellets of a shotgun, despite not having 8 bullets only 6 in the chamber
        (this is a desired gameplay behavior to make the combat more fluid)*/
        if(ammunitionAmount < 0)
        {
            ammunitionAmount = 0;
        }
    }

    public void AddAmmunition(int ammunitionToAdd)
    {
        remainingAmmunitionStored += ammunitionToAdd;

        if(remainingAmmunitionStored > maxAmmunitionAmountStored)
        {
            remainingAmmunitionStored = maxAmmunitionAmountStored;
        }
    }
}

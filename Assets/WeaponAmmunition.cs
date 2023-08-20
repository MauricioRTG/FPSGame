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

    public int MaxAmmunitionAmount { get => maxAmmunitionAmount; }
    public int MaxAmmunitionAmountStored { get => maxAmmunitionAmountStored; }

    public int AmmunitionAmount { get => ammunitionAmount; }

    // Start is called before the first frame update
    void Start()
    {
        ammunitionAmount = maxAmmunitionAmount;
        remainingAmmunitionStored = maxAmmunitionAmountStored;
    }

    public void Reload()
    {
        ammunitionAmount = remainingAmmunitionStored; //TODO: Add or complete ammunition not reasign
        remainingAmmunitionStored = 0;
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
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAmmunition : MonoBehaviour
{

    [SerializeField] int maxAmmunitionAmount = 30;
    [SerializeField] int minAmmunitionAmount;
    [SerializeField] public int ammunitionAmount;
    [SerializeField] public int remainingAmmunitionAmountInMagazine;

    public int MaxAmmunitionAmount { get => maxAmmunitionAmount; }

    // Start is called before the first frame update
    void Start()
    {
        ammunitionAmount = maxAmmunitionAmount;
        remainingAmmunitionAmountInMagazine = maxAmmunitionAmount;
    }

    public void Reload()
    {
        ammunitionAmount = remainingAmmunitionAmountInMagazine; //TODO: Add or complete ammunition not reasign
        remainingAmmunitionAmountInMagazine = 0;
    }
}

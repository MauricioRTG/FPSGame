using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActiveProjectile : MonoBehaviour
{
    public GameObject projectile;
    [SerializeField] WeaponAmmunition weaponAmmunition;
    
    void Start()
    {
        weaponAmmunition = FindObjectOfType<WeaponAmmunition>();
    }

    public void InstantiateProjectile()
    {
        var clone = Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);
        weaponAmmunition.ammunitionAmount--;
        //Destroy after 2 seconds to stop clutter.
        Destroy(clone, 5.0f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    public GameObject projectile;
    [SerializeField] WeaponAmmunition weaponAmmunition;

    void Start()
    {
        weaponAmmunition = FindObjectOfType<WeaponAmmunition>();
    }

    public override void InstantiateBullets()
    {
        var clone = Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);
        weaponAmmunition.ammunitionAmount--;
        //Destroy after 2 seconds to stop clutter.
        Destroy(clone, 5.0f);
    }
}

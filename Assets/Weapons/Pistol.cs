using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public GameObject projectile;
    [SerializeField] public WeaponAmmunition weaponAmmunition;

    void Start()
    {
        weaponAmmunition = GetComponent<WeaponAmmunition>();
    }

    public override void InstantiateBullets()
    {
        var clone = Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);
        weaponAmmunition.ammunitionAmount--;
        //Destroy after 2 seconds to stop clutter.
        Destroy(clone, 5.0f);
    }

    public void AddAmmunition(int ammunitionToAdd)
    {
        weaponAmmunition.AddAmmunition(ammunitionToAdd);
    }
}

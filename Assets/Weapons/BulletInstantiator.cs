using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInstantiator : MonoBehaviour
{
    public Weapon currentWeapon;

    public void ShootBullets()
    {
        currentWeapon.InstantiateBullets();
    }
}

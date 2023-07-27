using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] weapons;
    [SerializeField] int nextWeaponIndex;
    [SerializeField] int currentWeaponIndex;
    [SerializeField] GameObject currentWeapon;
    [SerializeField] GameObject newWeapon;
    [SerializeField] GameObject mainCamara;

    void Start()
    {
        currentWeapon = weapons[currentWeaponIndex];
        InstantiateWeapon(currentWeapon);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            SwitchToNextWeapon();
        }
    }

    private void SwitchToNextWeapon()
    {
        Destroy(newWeapon);
        //Go to the next index relative to the current index, while staying in the weapons array bounds
        nextWeaponIndex = (currentWeaponIndex + 1) % weapons.Length;
        currentWeapon = weapons[nextWeaponIndex];
        currentWeaponIndex = nextWeaponIndex;
        InstantiateWeapon(currentWeapon);
    }

    private void InstantiateWeapon(GameObject weapon)
    {
        newWeapon = Instantiate(weapon, transform.position, transform.rotation, transform);
        //Position relative to the parent transform, moving the gameOject by an offset that it is provided in the weapon prefab transform position.
        newWeapon.transform.localPosition = weapon.transform.position;
    }
}

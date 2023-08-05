using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] weapons;
    [SerializeField] int nextWeaponIndex;
    [SerializeField] int currentWeaponIndex;
    [SerializeField] GameObject currentWeapon;
    [SerializeField] List<GameObject> weaponsInScene;

    public GameObject CurrentWeapon { get => currentWeapon; }

    void Start()
    {
        //Instantiate first weapon that will appear in scene
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
        //Go to the next index relative to the current weapon index, while staying in the weapons roster array bounds
        nextWeaponIndex = (currentWeaponIndex + 1) % weapons.Length;

        //Change to the current weapon that is going to be instantiated to the next weapon in the weapon roster
        currentWeapon = weapons[nextWeaponIndex];

        /*
         * Checks if the weapons in scene have the same size as the weapons roster:
         * If that is no true then instantiate the weapon and add it to the weapons in scene list
         * If the size is the same, then only hide previous weapon and active the next weapon
        */

        if (weaponsInScene.Count == weapons.Length)
        {
            //Hide previous weapon
            weaponsInScene[currentWeaponIndex].SetActive(false);
            //Active next weapon
            weaponsInScene[nextWeaponIndex].SetActive(true);
        }
        else
        {
            //Hide previous weapon
            weaponsInScene[currentWeaponIndex].SetActive(false);
            //Instantiate the current weapon into the scene
            InstantiateWeapon(currentWeapon);
        }

        //Update the current weapon index
        currentWeaponIndex = nextWeaponIndex;
    }

    private void InstantiateWeapon(GameObject weapon)
    {
        //Instantiate the weapon
        GameObject newGameObject = Instantiate(weapon, transform.position, transform.rotation, transform);
        //Position relative to the parent transform, moving the gameOject by an offset that it is provided in the weapon prefab transform position.
        newGameObject.transform.localPosition = weapon.transform.position;
        //Add game object to weaponsInScene list 
        weaponsInScene.Add(newGameObject);
    }
}

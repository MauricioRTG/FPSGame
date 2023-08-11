using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    [SerializeField] int nextWeaponIndex;
    [SerializeField] int currentWeaponIndex;
    [SerializeField] GameObject currentWeapon;
    [SerializeField] List<GameObject> weaponsInScene;

    public GameObject CurrentWeapon { get => currentWeapon; }

    void Start()
    {
        currentWeapon = weaponsInScene[currentWeaponIndex];
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
        nextWeaponIndex = (currentWeaponIndex + 1) % weaponsInScene.Count;

        //Update current weapon
        currentWeapon = weaponsInScene[nextWeaponIndex];

        //Hide current weapon
        weaponsInScene[currentWeaponIndex].SetActive(false);
        //Active next weapon
        weaponsInScene[nextWeaponIndex].SetActive(true);
  
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

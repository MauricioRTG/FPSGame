using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActiveProjectile : MonoBehaviour
{
    public GameObject projectile;
    [SerializeField] int maxprojectileAmount = 30;
    [SerializeField] int minProjectileAmount;
    [SerializeField] int projectileAmount;
    [SerializeField] int remainingProjectileAmountInMagazine;

    //UI
    [SerializeField] TextMeshProUGUI projectileUIText;

    private void Start()
    {
        projectileAmount = maxprojectileAmount;
        remainingProjectileAmountInMagazine = maxprojectileAmount;
        UpdateProjectileUIAmount();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (projectileAmount > 0)
            {
                InstantiateProjectile();
                UpdateProjectileUIAmount();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
            UpdateProjectileUIAmount();
        }
    }

    private void InstantiateProjectile()
    {
        var clone = Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);
        projectileAmount--;
        //Destroy after 2 seconds to stop clutter.
        Destroy(clone, 5.0f);
    }

    private void Reload()
    {
        projectileAmount = remainingProjectileAmountInMagazine;
        remainingProjectileAmountInMagazine = 0;
    }

    private void UpdateProjectileUIAmount()
    {
        projectileUIText.text = projectileAmount.ToString() + "/" + remainingProjectileAmountInMagazine.ToString();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActiveProjectile : MonoBehaviour
{
    public GameObject projectile;
    [SerializeField] Player player;
    
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public void InstantiateProjectile()
    {
        var clone = Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);
        player.projectileAmount--;
        //Destroy after 2 seconds to stop clutter.
        Destroy(clone, 5.0f);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickupItem : MonoBehaviour
{

    [SerializeField] Player player;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Checks if the player collided with a gameobject that has a ProjectileAmmunitionItem or HealhtItem script
        if(collision.gameObject.TryGetComponent(out ProjectileAmmunitionItem projectileAmmunitionItem))
        {
            //Add ammunition to player
            int ammunitionToAdd = projectileAmmunitionItem.ammunitionCount;
            AddAmmunitionToPlayer(ammunitionToAdd);

            //Destroy item after is collected
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.TryGetComponent(out HealthItem healthItem))
        {
            //Add health to player
            int healthToAdd = healthItem.healthValue;
            AddHealthToPlayer(healthToAdd);

            //Destroy item after is collected
            Destroy(collision.gameObject);
        }
    }

    private void AddAmmunitionToPlayer(int amount)
    {
        //TODO:Move the ammunition management from the ActiveProjectile to Player or create a new script
    }

    private void AddHealthToPlayer(int amount)
    {
        player.IncreaseHealth(amount);
    }
}

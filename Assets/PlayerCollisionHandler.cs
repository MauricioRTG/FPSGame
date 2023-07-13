using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] string targetLayerMask = "Enemy";
    [SerializeField] int damageAmount = 25;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer(targetLayerMask))
        {
            Player player = GetComponent<Player>();

            if(player != null )
            {
                player.TakeDamage(damageAmount);
            }
        }
    }
}

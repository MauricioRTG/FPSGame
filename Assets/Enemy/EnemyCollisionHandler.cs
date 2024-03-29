using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionHandler : MonoBehaviour
{
    [SerializeField] string targetLayerMask = "Projectile";
    [SerializeField] int damageAmount = 50;
    [SerializeField] int pointsAmount = 1;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(targetLayerMask))
        {
            // Get a reference to the Enemy component on the same GameObject
            Enemy enemy = GetComponent<Enemy>();
            // Get a reference to the ScoreManager component on the game scene
            ScoreManager score = FindObjectOfType<ScoreManager>();

            if (enemy != null)
            {
                enemy.TakeDamage(damageAmount);
            }

            if(score != null)
            {
                score.AddPoints(pointsAmount);
            }
        }
    }
}

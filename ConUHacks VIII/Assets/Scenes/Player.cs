using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float damagePerSecond = 40f;      // Damage dealt per second

    void OnTriggerStay2D(Collider2D other)
    {
        // Check if the other collider belongs to an enemy
        if (other.CompareTag("Enemy"))
        {
            // Deal damage while the player's collider stays in contact with the enemy's collider
            EnemyMovement enemyMovement = other.GetComponent<EnemyMovement>();
            if (enemyMovement != null)
            {
                enemyMovement.TakeDamage(damagePerSecond * Time.deltaTime);
            }
        }
    }
}

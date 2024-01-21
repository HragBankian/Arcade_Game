using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float damagePerSecond = 40f;  // Damage dealt per second

    void Update()
    {
        // Check for user input or other conditions to initiate attacking

        // Example: Player attacks when pressing the spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Attack()
    {
        // Find all enemies in the specified Y position range
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, 1f, LayerMask.GetMask("enemy"));

        // Check each enemy in the range
        foreach (Collider2D enemyCollider in enemies)
        {
            // Get the EnemyMovement script of the enemy
            EnemyMovement enemyMovement = enemyCollider.GetComponent<EnemyMovement>();

            // If the enemy is within the Y position range, deal damage
            if (enemyMovement != null && Mathf.Abs(transform.position.y - enemyCollider.transform.position.y) <= 0.4f)
            {
                enemyMovement.TakeDamage(damagePerSecond * Time.deltaTime);
            }
        }
    }
}

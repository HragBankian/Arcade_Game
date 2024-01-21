using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class Player : MonoBehaviour
    {
        public float damagePerSecond = 40f;      // Damage dealt per second
        public float attackInterval = 1f;        // Time interval between automatic attacks

        private float timeSinceLastAttack;

        void Update()
        {
            // Automatically attack enemies at a regular interval
            AutoAttack();

            // Manual attack with the space bar
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ManualAttack();
            }
        }

        void AutoAttack()
        {
            // Increment the time since the last attack
            timeSinceLastAttack += Time.deltaTime;

            // Check if enough time has passed to perform another attack
            if (timeSinceLastAttack >= attackInterval)
            {
                // Reset the timer
                timeSinceLastAttack = 0f;
            }
        }

        void OnTriggerStay2D(Collider2D other)
        {
            // Check if the other collider belongs to an enemy
            if (other.CompareTag("enemy"))
            {
                // Automatically attack enemies within the player's collider area
                other.GetComponent<EnemyMovement>().TakeDamage(damagePerSecond * Time.deltaTime);
            }
        }

        void ManualAttack()
        {
            // Find all enemies in the specified Y position range
            Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, 1f, LayerMask.GetMask("Enemy"));

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;  // Adjust the speed as needed
    public float resetXPosition = -15f;  // X position at which the enemy resets to the initial position
    public float initialYPosition;  // Initial Y position of the enemy
    public float spawnZPosition = -1f;  // Z position at which the enemy spawns
    public float maxHealth = 100f;  // Maximum health of the enemy
    private float currentHealth;  // Current health of the enemy
    private Color originalColor;  // Original color of the enemy
    private SpriteRenderer spriteRenderer;  // Reference to the SpriteRenderer component

    void Start()
    {
        // Store the initial Y position of the enemy
        initialYPosition = transform.position.y;

        // Set the initial position of the enemy
        transform.position = new Vector3(resetXPosition, initialYPosition, spawnZPosition);

        // Set the initial health of the enemy
        currentHealth = maxHealth;

        // Get the SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            // Store the original color of the enemy
            originalColor = spriteRenderer.color;
        }
    }

    void Update()
    {
        // Calculate the new position based on the constant speed
        float newPositionX = transform.position.x - speed * Time.deltaTime;

        // Update the position of the enemy
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);

        // Check if the enemy has reached the resetXPosition
        if (transform.position.x <= resetXPosition)
        {
            // Reset the enemy to the initial position and restore the original color
            ResetToInitialPosition();
        }
    }

    void ResetToInitialPosition()
    {
        // Move the enemy back to the initial position
        transform.position = new Vector3(10f, initialYPosition, spawnZPosition);

        // Reset the health of the enemy
        currentHealth = maxHealth;

        // Restore the original color
        if (spriteRenderer != null)
        {
            spriteRenderer.color = originalColor;
        }
    }

    public void TakeDamage(float damage)
    {
        // Reduce the current health of the enemy
        currentHealth -= damage;

        // Check if the enemy's health has dropped to zero or below
        if (currentHealth <= 0)
        {
            // Perform actions when the enemy is defeated
            // Change the color to black
            if (spriteRenderer != null)
            {
                Color newColor = spriteRenderer.color;
                newColor.a = 0f; // Set alpha to 0 (fully transparent)
                spriteRenderer.color = newColor;
            }
        }
    }
}
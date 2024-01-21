using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;
    public float resetXPosition = -15f;
    public float initialYPosition;
    public float spawnZPosition = -1f;
    public float maxHealth = 100f;
    private float currentHealth;
    private Color originalColor;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        initialYPosition = transform.position.y;
        transform.position = new Vector3(resetXPosition, initialYPosition, spawnZPosition);
        currentHealth = maxHealth;

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        }

        originalColor = spriteRenderer.color;
    }

    void Update()
    {
        float newPositionX = transform.position.x - speed * Time.deltaTime;
        transform.position = new Vector3(newPositionX, transform.position.y, transform.position.z);

        if (transform.position.x <= resetXPosition)
        {
            ResetToInitialPosition();
        }
    }

    void ResetToInitialPosition()
    {
        transform.position = new Vector3(10f, initialYPosition, spawnZPosition);
        currentHealth = maxHealth;
        Color newColor = originalColor;
        newColor.a = 1f;
        spriteRenderer.color = newColor;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            // Teleport the enemy to x = -15
            transform.position = new Vector3(-15f, initialYPosition, spawnZPosition);

            // Perform any additional actions when the enemy is defeated
            // For example: you can reset health, change color, or destroy the enemy
            currentHealth = maxHealth;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
    public Transform player; // Reference to the player
    public float detectionRadius = 5.0f; // Detection radius
    public float speed = 2.0f; // Speed of movement
    private Vector3 originalPosition; // Original position of the enemy
    private bool returningToOrigin = false; // Track if the enemy is returning to origin

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position; // Store the original position
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        Vector3 movementDirection;

        if (distanceToPlayer < detectionRadius)
        {
            // Player detected: Move towards the player
            movementDirection = (player.position - transform.position).normalized;
            transform.position += movementDirection * speed * Time.deltaTime;
            returningToOrigin = false; // Stop returning to origin if chasing player
        }
        else if (!returningToOrigin)
        {
            // If not already returning, move back to the original position
            float distanceToOrigin = Vector3.Distance(transform.position, originalPosition);

            if (distanceToOrigin > 0.1f) // Tolerance for reaching the origin
            {
                movementDirection = (originalPosition - transform.position).normalized;
                transform.position += movementDirection * speed * Time.deltaTime;
            }
            else
            {
                // Once at the original position, start walking back and forth
                returningToOrigin = true;
                movementDirection = Vector3.zero;
            }
        }
        else
        {
            // Walk back and forth at the original position
            movementDirection = Vector3.right * Mathf.Sign(speed);

            transform.position += movementDirection * Mathf.Abs(speed) * Time.deltaTime;

            if (transform.position.x > originalPosition.x + 5)
            {
                transform.position = new Vector3(originalPosition.x + 5, transform.position.y, transform.position.z);
                speed = -Mathf.Abs(speed); // Change direction to left
            }
            if (transform.position.x < originalPosition.x - 5)
            {
                transform.position = new Vector3(originalPosition.x - 5, transform.position.y, transform.position.z);
                speed = Mathf.Abs(speed); // Change direction to right
            }
        }

        // Rotate to face the movement direction
        if (movementDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10.0f); // Smooth rotation
        }
    }
}

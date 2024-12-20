using UnityEngine;

public class enemyAI : MonoBehaviour
{
    public Transform player; // Reference to the player
    public float detectionRadius = 5.0f; // Detection radius
    public float speed = 2.0f; // Speed of movement
    private Vector3 originalPosition; // Original position of the enemy
    private bool returningToOrigin = false; // Track if the enemy is returning to origin
    public float touchCooldown = 1.5f; // Time to wait after touching player
    private float touchCooldownTimer = 0.0f; // Timer for touch cooldown

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position; // Store the original position
    }

    // Update is called once per frame
    void Update()
    {
        // Reduce cooldown timer if active
        if (touchCooldownTimer > 0)
        {
            touchCooldownTimer -= Time.deltaTime;
            return; // Stop movement while waiting
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        Vector3 movementDirection;

        if (distanceToPlayer < detectionRadius)
        {
            // Player detected: Move towards the player
            movementDirection = (player.position - transform.position).normalized;
            movementDirection.y = 0; // Ensure movement stays on the ground
            transform.position += movementDirection * speed * Time.deltaTime;
            returningToOrigin = false; // Stop returning to origin if chasing player

            // Check if touching the player
            if (distanceToPlayer < 0.5f) // Adjust the distance threshold as needed
            {
                movementDirection = Vector3.zero; // Stop moving
                touchCooldownTimer = touchCooldown; // Start cooldown timer
            }
        }
        else if (!returningToOrigin)
        {
            // If not already returning, move back to the original position
            float distanceToOrigin = Vector3.Distance(transform.position, originalPosition);

            if (distanceToOrigin > 0.1f) // Tolerance for reaching the origin
            {
                movementDirection = (originalPosition - transform.position).normalized;
                movementDirection.y = 0; // Ensure movement stays on the ground
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
            movementDirection.y = 0; // Ensure movement stays on the ground
            transform.position += movementDirection * Mathf.Abs(speed) * Time.deltaTime;

            if (transform.position.x > originalPosition.x + 2)
            {
                transform.position = new Vector3(originalPosition.x + 2, transform.position.y, transform.position.z);
                speed = -Mathf.Abs(speed); // Change direction to left
            }
            if (transform.position.x < originalPosition.x - 2)
            {
                transform.position = new Vector3(originalPosition.x - 2, transform.position.y, transform.position.z);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keymove : MonoBehaviour
{
    public float speed;
    public float sprintSpeed;
    public Animator animator;
    public Rigidbody _rb;
    public float rotationSpeed;
    static readonly int Speed = Animator.StringToHash("Speed");

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        // Move the character
        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        // Calculate current speed
        float currentSpeed = movementDirection.magnitude * speed;

        // Update the animator with the current speed
        UpdateAnimator(currentSpeed);

        // Rotate the character towards the movement direction
        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }

    // Method to update the animator with the current speed
    void UpdateAnimator(float currentSpeed)
    {
        animator.SetFloat(Speed, currentSpeed);
    }
}

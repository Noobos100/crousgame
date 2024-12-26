using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMove : MonoBehaviour
{
    public float speed;
    public float sprintSpeed;
    public Animator animator;
    public Rigidbody _rb;
    public float rotationSpeed;
    static readonly int Speed = Animator.StringToHash("Speed");
    public Vector3 jump;
    public float jumpForce = 2.0f;

    private bool isGrounded;
    public Transform cameraTransform; // Reference to the camera's transform
    private bool canMove = true; // Flag to determine if the player can move


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionStay()
    {
        isGrounded = true;
    }

    void Update()
    {

        if (!canMove) return;
        
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Get the camera's forward and right vectors
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Ensure the vectors are normalized and ignore the y-component for movement
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        // Calculate the movement direction relative to the camera
        Vector3 movementDirection = forward * verticalInput + right * horizontalInput;

        // Normalize the movement direction
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

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            _rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    // Method to disable movement
    public void DisableMovement()
    {
        canMove = false;
    }

    // Method to update the animator with the current speed
    void UpdateAnimator(float currentSpeed)
    {
        animator.SetFloat(Speed, currentSpeed);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSwat : MonoBehaviour
{
    public AudioSource pickupSound;

    // Player's hand position and rotation
    public Transform handPosition;

    private bool isPickedUp = false; // Tracks if the object has been picked up
    private Rigidbody rb;
    private ObjectSpin spinScript; // Reference to the spinning script

    private void Start()
    {
        // Get the Rigidbody and spinning script components
        rb = GetComponent<Rigidbody>();
        spinScript = GetComponent<ObjectSpin>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isPickedUp)
        {
            isPickedUp = true;

            // Play the pickup sound
            if (pickupSound != null)
            {
                pickupSound.Play();
            }

            // Disable physics interactions
            if (rb != null)
            {
                rb.isKinematic = true;
                rb.useGravity = false;
            }

            // Stop spinning
            if (spinScript != null)
            {
                spinScript.StopSpinning();
            }

            // Attach the object to the player's hand
            transform.SetParent(handPosition);

            // Reset position and rotation relative to the hand
            // with adjustment : Position y = handPosition.position.y + 0.5f 
            transform.localPosition = new Vector3(0, 0.5f, 0);
            transform.localRotation = Quaternion.identity;
        }
    }
}

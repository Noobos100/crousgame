using System.Collections;
using UnityEngine;
using TMPro; // For TextMeshPro

public class PickupSwat : MonoBehaviour
{
    public AudioSource pickupSound;

    // Player's hand position and rotation
    public Transform handPosition;

    // UI message display
    public TextMeshProUGUI messageText; // Reference to the UI text
    private bool isPickedUp = false; // Tracks if the object has been picked up
    private Rigidbody rb;
    private ObjectSpin spinScript; // Reference to the spinning script

    private void Start()
    {
        // Get the Rigidbody and spinning script components
        rb = GetComponent<Rigidbody>();
        spinScript = GetComponent<ObjectSpin>();

        // Ensure the message text is initially hidden
        if (messageText != null)
        {
            messageText.gameObject.SetActive(false);
        }
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
            transform.localPosition = new Vector3(0, 0.5f, 0);
            transform.localRotation = Quaternion.identity;

            // Show the message
            DisplayMessage("Appuyez sur F pour frapper les cafards!");
        }
    }

    private void DisplayMessage(string message)
    {
        if (messageText != null)
        {
            messageText.text = message; // Update the message text
            messageText.gameObject.SetActive(true); // Show the message

            // Hide the message after 5 seconds
            StartCoroutine(HideMessageAfterDelay(5f));
        }
    }

    private IEnumerator HideMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (messageText != null)
        {
            messageText.gameObject.SetActive(false); // Hide the message
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // For TextMeshPro

public class Chest : MonoBehaviour
{
    public Animator chestAnimator;
    public GameObject itemToSpawn;
    public Transform spawnPoint;
    public TextMeshProUGUI promptText; // Reference to the UI text
    private bool isOpened = false;
    private bool playerInRange = false;
    public AudioSource m_openChest; // Damage sound

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            UpdatePromptText(); // Update the prompt text when the player enters range
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            HidePromptText(); // Hide the prompt text when the player exits range
        }
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            pickupKey keyScript = GameObject.FindWithTag("Key").GetComponent<pickupKey>();
            if (keyScript != null && keyScript.isPickedUp && !isOpened)
            {
                isOpened = true;

                // Play the chest opening animation
                if (chestAnimator != null)
                {
                    chestAnimator.SetTrigger("Chest_Animated");
                    m_openChest.Play();
                }

                // Hide the prompt text
                HidePromptText();

                // Spawn the item after a delay
                StartCoroutine(SpawnItemWithDelay(1.0f)); // Adjust the delay based on the animation duration

                // Destroy the key
                Destroy(GameObject.FindWithTag("Key"));
            }
        }
    }

    private IEnumerator SpawnItemWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (itemToSpawn != null && spawnPoint != null)
        {
            Instantiate(itemToSpawn, spawnPoint.position, spawnPoint.rotation);
        }
    }

    private void UpdatePromptText()
    {
        if (promptText != null)
        {
            pickupKey keyScript = GameObject.FindWithTag("Key").GetComponent<pickupKey>();
            if (keyScript != null && keyScript.isPickedUp && !isOpened)
            {
                promptText.text = "Appuyez sur E pour ouvrir le coffre";
                promptText.gameObject.SetActive(true);
            }
        }
    }

    private void HidePromptText()
    {
        if (promptText != null)
        {
            promptText.gameObject.SetActive(false);
        }
    }
}

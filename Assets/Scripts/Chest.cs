using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Animator chestAnimator;
    public GameObject itemToSpawn;
    public Transform spawnPoint;
    private bool isOpened = false;
    private bool playerInRange = false; // Indique si le joueur est � port�e

    private void OnTriggerEnter(Collider other)
    {
        // V�rifiez si l'objet entrant est le joueur
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // V�rifiez si l'objet sortant est le joueur
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void Update()
    {
        // V�rifiez si le joueur est � port�e, a r�cup�r� la cl� et appuie sur la touche E
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            pickupKey keyScript = GameObject.FindWithTag("Key").GetComponent<pickupKey>();
            if (keyScript != null && keyScript.isPickedUp && !isOpened)
            {
                isOpened = true;

                // Jouer l'animation d'ouverture du coffre
                if (chestAnimator != null)
                {
                    chestAnimator.SetTrigger("Chest_Animated");
                }

                // Faire appara�tre l'objet apr�s un court d�lai pour synchroniser avec l'animation
                StartCoroutine(SpawnItemWithDelay(1.0f)); // Ajustez le d�lai selon la dur�e de l'animation
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
}
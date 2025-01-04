using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Animator chestAnimator;
    public GameObject itemToSpawn;
    public Transform spawnPoint;
    private bool isOpened = false;
    private bool playerInRange = false; // Indique si le joueur est à portée

    private void OnTriggerEnter(Collider other)
    {
        // Vérifiez si l'objet entrant est le joueur
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Vérifiez si l'objet sortant est le joueur
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void Update()
    {
        // Vérifiez si le joueur est à portée, a récupéré la clé et appuie sur la touche E
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            pickupKey keyScript = GameObject.FindWithTag("Player").GetComponent<pickupKey>();
            if (keyScript != null && keyScript.isPickedUp && !isOpened)
            {
                isOpened = true;

                // Jouer l'animation d'ouverture du coffre
                if (chestAnimator != null)
                {
                    chestAnimator.SetTrigger("Chest_Animated");
                }

                // Faire apparaître l'objet après un court délai pour synchroniser avec l'animation
                StartCoroutine(SpawnItemWithDelay(1.0f)); // Ajustez le délai selon la durée de l'animation
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
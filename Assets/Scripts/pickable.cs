using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    public AudioSource m_pickupSound;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger : " + other.name);
        if (other.tag == "Player")
        {
            // Play the pickup sound
            m_pickupSound.Play();

            // Update the global counter
            if (GameManager.Instance != null)
            {
                GameManager.Instance.AddPickup();
            }

            // Destroy the object after a delay
            Invoke("DestroyObject", 1);
        }
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}

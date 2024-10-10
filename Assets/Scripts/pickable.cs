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
            m_pickupSound.Play();
            Invoke("DestroyObject", 1);
        }
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}

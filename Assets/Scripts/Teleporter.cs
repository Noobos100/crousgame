using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform pointA; // Point de d�part
    public Transform pointB; // Point de destination
    public GameObject platform; // La plateforme de t�l�portation
    public float offset = 1.0f; // D�calage pour �viter d'�tre bloqu�

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector3 newPosition = pointB.position;
            newPosition.y += offset; // Ajouter un d�calage vertical
            collision.transform.position = newPosition;
        }
    }
}
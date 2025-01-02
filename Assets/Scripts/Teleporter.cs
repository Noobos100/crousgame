using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform pointA; // Point de départ
    public Transform pointB; // Point de destination
    public GameObject platform; // La plateforme de téléportation
    public float offset = 1.0f; // Décalage pour éviter d'être bloqué

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
            newPosition.y += offset; // Ajouter un décalage vertical
            collision.transform.position = newPosition;
        }
    }
}
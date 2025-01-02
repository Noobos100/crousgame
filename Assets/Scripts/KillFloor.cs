using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFloor : MonoBehaviour
{
    public Transform respawnPoint;
    public float offset = 1.0f; // D�calage pour �viter d'�tre bloqu�
    private Vector3 initialSpawnPosition;

    // Start est appel� avant la premi�re mise � jour du frame
    void Start()
    {
        // Stocke la position initiale du point de respawn
        initialSpawnPosition = respawnPoint.position;
    }

    // Update est appel� une fois par frame
    void Update()
    {
        // Logique de mise � jour si n�cessaire
    }

    void OnTriggerEnter(Collider other)
    {
        // V�rifie si l'objet entrant a le tag "Player"
        if (other.CompareTag("Player"))
        {
            // Appelle la m�thode pour tuer et r�appara�tre le joueur
            KillPlayer(other.gameObject);
        }
    }

    void KillPlayer(GameObject player)
    {
        // D�sactive le joueur
        player.SetActive(false);
        // D�place le joueur au point de respawn initial avec un d�calage
        Vector3 newPosition = initialSpawnPosition;
        newPosition.y += offset; // Ajouter un d�calage vertical
        player.transform.position = newPosition;
        // R�active le joueur
        player.SetActive(true);
    }
}
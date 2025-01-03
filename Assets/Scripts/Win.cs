using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Assurez-vous d'inclure ce namespace

public class NewBehaviourScript : MonoBehaviour
{
    // Variable pour vérifier si le niveau est gagné
    private bool levelWon = false;

    // Start is called before the first frame update
    void Start()
    {
        // Initialisation si nécessaire
    }

    // Update is called une fois par frame
    void Update()
    {
        if (levelWon)
        {
            // Faire tourner le trophée
            transform.Rotate(Vector3.up * Time.deltaTime * 50);
        }
    }

    // Méthode pour appeler lorsque le niveau est gagné
    public void WinLevel()
    {
        Debug.Log("Win!");
        levelWon = true;
        // Charger la scène de victoire
        SceneManager.LoadScene("Win");
    }

    // Détecter la collision avec le joueur
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            WinLevel();
        }
    }
}
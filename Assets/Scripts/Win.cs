using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    // Variable pour vérifier si le niveau est gagné
    private bool levelWon = false;

    void Start()
    {
    }

    // Update is called une fois par frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 50);
    }

    // Méthode pour appeler lorsque le niveau est gagné
    public void WinLevel()
    {
        if (!levelWon)
        {
            Debug.Log("Win!");
            levelWon = true;
            // Charger la scène de victoire
            SceneManager.LoadScene("Win");
        }
    }

    // Détecter la collision avec le joueur
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collision détectée avec le joueur.");
            WinLevel();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Assurez-vous d'inclure ce namespace

public class NewBehaviourScript : MonoBehaviour
{
    // Variable pour v�rifier si le niveau est gagn�
    private bool levelWon = false;

    // Start is called before the first frame update
    void Start()
    {
        // Initialisation si n�cessaire
    }

    // Update is called une fois par frame
    void Update()
    {
        if (levelWon)
        {
            // Faire tourner le troph�e
            transform.Rotate(Vector3.up * Time.deltaTime * 50);
        }
    }

    // M�thode pour appeler lorsque le niveau est gagn�
    public void WinLevel()
    {
        Debug.Log("Win!");
        levelWon = true;
        // Charger la sc�ne de victoire
        SceneManager.LoadScene("Win");
    }

    // D�tecter la collision avec le joueur
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            WinLevel();
        }
    }
}
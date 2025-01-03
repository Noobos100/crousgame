using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    // Variable pour v�rifier si le niveau est gagn�
    private bool levelWon = false;

    void Start()
    {
    }

    // Update is called une fois par frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * 50);
    }

    // M�thode pour appeler lorsque le niveau est gagn�
    public void WinLevel()
    {
        if (!levelWon)
        {
            Debug.Log("Win!");
            levelWon = true;
            // Charger la sc�ne de victoire
            SceneManager.LoadScene("Win");
        }
    }

    // D�tecter la collision avec le joueur
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collision d�tect�e avec le joueur.");
            WinLevel();
        }
    }
}
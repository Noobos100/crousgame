using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void Restart ()
    {
        SceneManager.LoadScene("Game");
    }

    public void BackToMenu ()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame ()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}

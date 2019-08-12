using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Level Gen");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}

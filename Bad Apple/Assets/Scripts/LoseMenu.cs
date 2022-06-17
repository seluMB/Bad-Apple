using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour
{
    public GameObject loseMenuUI;

    public void Lost()
    {
        loseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting...");
        Application.Quit();
    }

    public void ReplayGame()
    {
        Debug.Log("Rplaying...");
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        loseMenuUI.SetActive(false);
    }
}

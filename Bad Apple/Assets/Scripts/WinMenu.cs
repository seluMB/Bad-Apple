using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public GameObject winMenuUI;

    public void Win()
    {
        winMenuUI.SetActive(true);
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
        winMenuUI.SetActive(false);
    }
}

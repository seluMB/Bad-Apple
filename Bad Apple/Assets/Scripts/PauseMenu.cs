using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Debug.Log("Quitting...");
        Application.Quit();
    }

    public void RestartGame()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Debug.Log("Restarting...");
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
    }
}

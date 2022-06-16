using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject loseMenu;
    bool gameHasEnded = false;
    public GameObject pauseMenu;
    public GameObject winScreen;
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            loseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        
    }

    //Pause the game and enable the pause UI
    public void Pause()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    //Resume Game and disable the Pause UI
    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    //Restart the game from the beginning
    public void Restart ()
    {
        Time.timeScale = 1;
        loseMenu.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Brings you to win screen

    public void Win ()
    {
        Time.timeScale = 0;
        winScreen.SetActive(true);

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused=false;
    public GameObject pauseMenuUI;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }
    public void resume()
    {
         pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused=false;

    }

    public void pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused=true;
    }

    public void retry()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
    public void mainMenu()
    {
       SceneManager.LoadScene("MainMenu");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public bool paused = false;


    public void Pause()
    {


        if (!paused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
           

            paused = true;
        }
        else if (paused == true)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            

            paused = false;

        }


    }

    public void Resume()

    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        


    }

    public void Menu(int sceneID)
    {
        if (!paused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            

            paused = true;
        }
        else if (paused == true)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            


            paused = false;

        }
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}

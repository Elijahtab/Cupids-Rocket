using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        // Additional code to display pause menu or perform other actions
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        // Additional code to hide pause menu or perform other actions
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasScript : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject PauseScreen;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) TogglePause();
    }

    public void TogglePause()
    {
        if (GamePaused) Resume();
        else Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0;
        PauseScreen.SetActive(true);
        GamePaused = true;
    }


    public void Resume()
    {
        Time.timeScale = 1;
        PauseScreen.SetActive(false);
        GamePaused = false;
    }

    public void MainMenu()
    {
        Resume();
        SceneManager.LoadScene("StartMenu");
    }
}

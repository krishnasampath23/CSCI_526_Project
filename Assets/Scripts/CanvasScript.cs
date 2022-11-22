using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    public static bool GamePaused = false;
    public GameObject PauseScreen;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GamePaused) Resume();
            else Pause();
        }
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
}

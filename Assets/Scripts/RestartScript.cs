using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    public void LoadGame()
    {
        StaticScript.timePrevious=StaticScript.timeElapsed;
        StaticScript.score = 0;
        StaticScript.timeLeft = 180;
        StaticScript.timerOn = false;
        StaticScript.no_of_poops = 10;
        StaticScript.health = 100;

        SceneManager.LoadScene("Scene1");
    }

     public void LoadLevels()
    {
        StaticScript.timePrevious=StaticScript.timeElapsed;
        StaticScript.score = 0;
        StaticScript.timeLeft = 180;
        StaticScript.timerOn = false;
        StaticScript.no_of_poops = 10;
        StaticScript.health = 100;

        SceneManager.LoadScene("Levels");
    }
    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void LoadLevel4()
    {
        SceneManager.LoadScene("Level4");
    }

    public void LoadBack()
    {
        SceneManager.LoadScene("RestartScene");
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}

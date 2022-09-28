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
    public void ExitGame()
    {
        Application.Quit();
    }
}

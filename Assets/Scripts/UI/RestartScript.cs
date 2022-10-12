using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    public void LoadGame()
    {
        StaticScript.success_or_fail=-1;
        StaticScript.lines_drawn=0;
        StaticScript.timePrevious=StaticScript.timeElapsed;
        StaticScript.score = 0;
        StaticScript.timeLeft = 10;
        StaticScript.timerOn = false;
        StaticScript.enemies_killed=0;
        StaticScript.no_of_enemies = 3;
        StaticScript.level += 1;
        if(StaticScript.level == 2 || StaticScript.level == 3){
            StaticScript.no_of_enemies = 5;
        }

        StaticScript.no_of_poops += 10;
        StaticScript.health = 100;
        StaticScript.playingOrNot = true;
        Debug.Log("Level"+StaticScript.level.ToString());
        SceneManager.LoadScene("Level"+StaticScript.level.ToString());
    }

    public void LoadAgain()
    {
        StaticScript.success_or_fail=-1;
        StaticScript.lines_drawn=0;
        StaticScript.timePrevious=StaticScript.timeElapsed;
        StaticScript.score = 0;
        StaticScript.timeLeft = 10;
        StaticScript.timerOn = false;
        StaticScript.enemies_killed=0;
        StaticScript.no_of_enemies = 3;
        StaticScript.level += 0;
        if(StaticScript.level == 2 || StaticScript.level == 3){
            StaticScript.no_of_enemies = 5;
        }
        StaticScript.no_of_poops = 10;
        StaticScript.health = 100;
        StaticScript.playingOrNot = true;
        if(StaticScript.level==0){
            StaticScript.timeLeft = 1000;
            SceneManager.LoadScene("Tutorial");
        }
        else{
            Debug.Log("Level"+StaticScript.level.ToString());
            SceneManager.LoadScene("Level"+StaticScript.level.ToString());
        }
        
    }

     public void LoadLevels()
    {
        StaticScript.success_or_fail=-1;
        StaticScript.lines_drawn=0;
        StaticScript.timePrevious=StaticScript.timeElapsed;
        StaticScript.score = 0;
        StaticScript.timeLeft = 10;
        StaticScript.timerOn = false;
        StaticScript.enemies_killed=0;
        StaticScript.no_of_enemies = 3;
        StaticScript.level = -1;
        StaticScript.no_of_poops += 10;
        StaticScript.health = 100;
        StaticScript.playingOrNot = false;

        SceneManager.LoadScene("Levels");
    }
    public void LoadTutorial()
    {
        StaticScript.success_or_fail=-1;
        StaticScript.lines_drawn=0;
        StaticScript.timePrevious=StaticScript.timeElapsed;
        StaticScript.score = 0;
        StaticScript.timeLeft = 10000;
        StaticScript.timerOn = false;
        StaticScript.enemies_killed=0;
        StaticScript.no_of_enemies = 3;
        StaticScript.level = 0;
        StaticScript.no_of_poops += 10;
        StaticScript.health = 100;
        StaticScript.playingOrNot = true;
        SceneManager.LoadScene("Tutorial");
    }

    public void LoadLevel1()
    {
        StaticScript.success_or_fail=-1;
        StaticScript.lines_drawn=0;
        StaticScript.timePrevious=StaticScript.timeElapsed;
        StaticScript.score = 0;
        StaticScript.timeLeft = 12;
        StaticScript.timerOn = false;
        StaticScript.enemies_killed=0;
        StaticScript.no_of_enemies = 3;
        StaticScript.level = 1;
        StaticScript.no_of_poops += 10;
        StaticScript.health = 100;
        StaticScript.playingOrNot = true;
        SceneManager.LoadScene("Level1");
    }
    public void LoadLevel2()
    {
        StaticScript.success_or_fail=-1;
        StaticScript.lines_drawn=0;
        StaticScript.timePrevious=StaticScript.timeElapsed;
        StaticScript.score = 0;
        StaticScript.timeLeft = 12;
        StaticScript.timerOn = false;
        StaticScript.enemies_killed=0;
        StaticScript.no_of_enemies = 5;
        StaticScript.level = 2;
        StaticScript.no_of_poops += 10;
        StaticScript.health = 100;
        StaticScript.playingOrNot = true;
        SceneManager.LoadScene("Level2");
    }

    public void LoadLevel3()
    {
        StaticScript.success_or_fail=-1;
        StaticScript.lines_drawn=0;
        StaticScript.timePrevious=StaticScript.timeElapsed;
        StaticScript.score = 0;
        StaticScript.timeLeft = 12;
        StaticScript.timerOn = false;
        StaticScript.enemies_killed=0;
        StaticScript.no_of_enemies = 5;
        StaticScript.level = 3;
        StaticScript.no_of_poops += 10;
        StaticScript.health = 100;
        StaticScript.playingOrNot = true;
        SceneManager.LoadScene("Level3");

    }

    public void LoadLevel4()
    {
        StaticScript.success_or_fail=-1;
        StaticScript.lines_drawn=0;
        StaticScript.timePrevious=StaticScript.timeElapsed;
        StaticScript.score = 0;
        StaticScript.timeLeft = 10;
        StaticScript.timerOn = false;
        StaticScript.enemies_killed=0;
        StaticScript.no_of_enemies = 3;
        StaticScript.level = 4;
        StaticScript.no_of_poops += 10;
        StaticScript.health = 100;
        StaticScript.playingOrNot = true;
        SceneManager.LoadScene("Level4");
    }

    public void LoadBack()
    {
        StaticScript.playingOrNot = false;
        SceneManager.LoadScene("RestartScene");

    }

    public void LoadMenu(){
        StaticScript.playingOrNot = false;
        SceneManager.LoadScene("StartMenu");
    }

    public void ExitGame()
    {
        StaticScript.playingOrNot = false;
        Application.Quit();
    }
}

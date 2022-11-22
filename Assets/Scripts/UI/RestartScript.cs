using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    public void LoadGame()
    {
        StaticScript.success_or_fail=-1;
        StaticScript.timePrevious=StaticScript.timeElapsed;
        StaticScript.score = 0;
        StaticScript.timeLeft = 12;
        StaticScript.timerOn = false;
        StaticScript.enemies_killed=0;
        StaticScript.no_of_enemies = 3;
        StaticScript.level += 1;
        StaticScript.lines_drawn=0;
        StaticScript.no_of_erasers = 3;
        if(StaticScript.level == 2 || StaticScript.level == 4 ||  StaticScript.level == 5){
            StaticScript.no_of_enemies = 4;
            Debug.Log(StaticScript.level);
            Debug.Log(StaticScript.no_of_enemies);
        }
        if(StaticScript.level == 6){
            StaticScript.no_of_enemies = 3;
            Debug.Log(StaticScript.level);
            Debug.Log(StaticScript.no_of_enemies);
        }
        StaticScript.no_of_poops += 10;
        StaticScript.health = 100;
        StaticScript.playingOrNot = true;
        StaticScript.no_color_switches=0;
        if(StaticScript.level >= 6){
            SceneManager.LoadScene("Levels", LoadSceneMode.Single);
        }
        if(StaticScript.level == 1){
            StaticScript.no_of_poops = 10;
        }


    Debug.Log("Level"+StaticScript.level.ToString());
        SceneManager.LoadScene("Level"+StaticScript.level.ToString(), LoadSceneMode.Single);
    }

    // public void Load_Tutorial_Page()
    // {
    //     SceneManager.LoadScene("Tutorial");
    // }

    public void LoadAgain()
    {
        StaticScript.success_or_fail=-1;
        StaticScript.lines_drawn=0;
        StaticScript.timePrevious=StaticScript.timeElapsed;
        StaticScript.score = 0;
        StaticScript.timeLeft = 12;
        StaticScript.timerOn = false;
        StaticScript.enemies_killed=0;
        StaticScript.no_of_enemies = 3;
        StaticScript.level += 0;
        StaticScript.no_of_erasers = 3;
        StaticScript.no_color_switches=0;
        if(StaticScript.level == 2 || StaticScript.level == 4 ||  StaticScript.level == 5){
            StaticScript.no_of_enemies = 4;
        }
        if(StaticScript.level == 6){
            StaticScript.no_of_enemies = 3;
        }
        StaticScript.no_of_poops = 10;
        StaticScript.health = 100;
        StaticScript.playingOrNot = true;
        if (StaticScript.level==0){
            StaticScript.timeLeft = 1000;
            StaticScript.lines_limit = 10000;
            StaticScript.no_of_erasers = 10000;
            StaticScript.no_of_poops = 10000;
            if(StaticScript.tutorial_flag == false){
            StaticScript.no_of_enemies = 5;
            }
            else{
                StaticScript.no_of_enemies = 3;
            }
            SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
            StaticScript.tutorial_flag = true;

            StaticScript.lines_limit = 3;
        }
        else{
            Debug.Log("Level"+StaticScript.level.ToString());
            SceneManager.LoadScene("Level"+StaticScript.level.ToString(), LoadSceneMode.Single);
        }
        
    }

     public void LoadLevels()
    {
        StaticScript.success_or_fail=-1;
        StaticScript.timePrevious=StaticScript.timeElapsed;
        StaticScript.lines_drawn=0;
        StaticScript.score = 0;
        StaticScript.timeLeft = 12;
        StaticScript.timerOn = false;
        StaticScript.no_of_erasers = 3;
        StaticScript.enemies_killed=0;
        StaticScript.no_of_enemies = 3;
        StaticScript.level = -1;
        StaticScript.no_of_poops += 10;
        StaticScript.health = 100;
        StaticScript.playingOrNot = false;
        StaticScript.no_color_switches=0;

        SceneManager.LoadScene("Levels", LoadSceneMode.Single);
    }
    public void LoadTutorial()
    {
        StaticScript.success_or_fail=-1;
        StaticScript.timePrevious=StaticScript.timeElapsed;
        StaticScript.score = 0;
        StaticScript.timeLeft = 12;
        StaticScript.timerOn = false;
        StaticScript.no_of_erasers = 10000;
        StaticScript.enemies_killed=0;
        if(StaticScript.tutorial_flag == false){
            StaticScript.no_of_enemies = 5;
        }
        else{
            StaticScript.no_of_enemies = 3;
        }
        
        StaticScript.level = 0;
        StaticScript.no_of_poops = 10000;
        StaticScript.health = 100;
        StaticScript.lines_limit = 10000;
        StaticScript.lines_drawn = 0;
        StaticScript.playingOrNot = true;
        StaticScript.no_color_switches=0;
        SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
        StaticScript.tutorial_flag = true;
        StaticScript.lines_limit = 3;
        
    }

    public void LoadLevel1()
    {
        StaticScript.success_or_fail=-1;
        StaticScript.timePrevious=StaticScript.timeElapsed;
        StaticScript.score = 0;
        StaticScript.timeLeft = 12;
        StaticScript.no_of_erasers = 3;
        StaticScript.lines_drawn=0;
        StaticScript.timerOn = false;
        StaticScript.enemies_killed=0;
        StaticScript.no_of_enemies = 3;
        StaticScript.level = 1;
        StaticScript.no_of_poops = 10;
        StaticScript.health = 100;
        StaticScript.playingOrNot = true;
        StaticScript.no_color_switches=0;
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }
    public void LoadLevel2()
    {
        StaticScript.success_or_fail=-1;
        StaticScript.timePrevious=StaticScript.timeElapsed;
        StaticScript.score = 0;
        StaticScript.timeLeft = 12;
        StaticScript.lines_drawn=0;
        StaticScript.timerOn = false;
        StaticScript.no_of_erasers = 3;
        StaticScript.enemies_killed=0;
        StaticScript.no_of_enemies = 4;
        StaticScript.level = 2;
        StaticScript.no_of_poops = 10;
        StaticScript.health = 100;
        StaticScript.playingOrNot = true;
        StaticScript.no_color_switches=0;
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
    }

    public void LoadLevel3()
    {
        StaticScript.success_or_fail=-1;
        StaticScript.timePrevious=StaticScript.timeElapsed;
        StaticScript.score = 0;
        StaticScript.lines_drawn=0;
        StaticScript.no_of_erasers = 3;
        StaticScript.timeLeft = 12;
        StaticScript.timerOn = false;
        StaticScript.enemies_killed=0;
        StaticScript.no_of_enemies = 3;
        StaticScript.level = 3;
        StaticScript.no_of_poops = 10;
        StaticScript.health = 100;
        StaticScript.playingOrNot = true;
        StaticScript.no_color_switches=0;
        SceneManager.LoadScene("Level3", LoadSceneMode.Single);

    }

    public void LoadLevel4()
    {
        StaticScript.success_or_fail=-1;
        StaticScript.timePrevious=StaticScript.timeElapsed;
        StaticScript.score = 0;
        StaticScript.timeLeft = 12;
        StaticScript.timerOn = false;
        StaticScript.no_of_erasers = 3;
        StaticScript.enemies_killed=0;
        StaticScript.no_of_enemies = 4;
        StaticScript.level = 4;
        StaticScript.lines_drawn = 0;
        StaticScript.no_of_poops = 10;
        StaticScript.health = 100;
        StaticScript.playingOrNot = true;
        StaticScript.no_color_switches=0;
        SceneManager.LoadScene("Level4", LoadSceneMode.Single);
    }

    public void LoadLevel5()
    {
        StaticScript.success_or_fail=-1;
        StaticScript.timePrevious=StaticScript.timeElapsed;
        StaticScript.score = 0;
        StaticScript.timeLeft = 12;
        StaticScript.lines_drawn=0;
        StaticScript.timerOn = false;
        StaticScript.no_of_erasers = 3;
        StaticScript.enemies_killed=0;
        StaticScript.no_of_enemies = 4;
        StaticScript.level = 5;
        StaticScript.no_of_poops = 10;
        StaticScript.health = 100;
        StaticScript.playingOrNot = true;
        StaticScript.no_color_switches=0;
        SceneManager.LoadScene("Level5", LoadSceneMode.Single);
    }

    public void LoadLevel6()
    {
        StaticScript.success_or_fail=-1;
        StaticScript.timePrevious=StaticScript.timeElapsed;
        StaticScript.score = 0;
        StaticScript.timeLeft = 12;
        StaticScript.lines_drawn=0;
        StaticScript.timerOn = false;
        StaticScript.no_of_erasers = 3;
        StaticScript.enemies_killed=0;
        StaticScript.no_of_enemies = 3;
        StaticScript.level = 6;
        StaticScript.no_of_poops = 10;
        StaticScript.health = 100;
        StaticScript.playingOrNot = true;
        StaticScript.no_color_switches=0;
        SceneManager.LoadScene("Level6", LoadSceneMode.Single);
    }

    public void LoadBack()
    {
        StaticScript.playingOrNot = false;
        SceneManager.LoadScene("RestartScene", LoadSceneMode.Single);

    }

    public void LoadMenu(){
        StaticScript.playingOrNot = false;
        SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        StaticScript.playingOrNot = false;
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    // static variables are now handled in Assets\Scripts\UI\Level.cs
    public void LoadGame()
    {
        StaticScript.level += 1;
        if(StaticScript.level >= 6){
            SceneManager.LoadScene("Levels", LoadSceneMode.Single);
        }
        SceneManager.LoadScene("Level"+StaticScript.level.ToString(), LoadSceneMode.Single);
    }

    public void LoadAgain()
    {
        if (StaticScript.level==0){
            SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
        }
        else{
            Debug.Log("Level"+StaticScript.level.ToString());
            SceneManager.LoadScene("Level"+StaticScript.level.ToString(), LoadSceneMode.Single);
        }
    }

    public void LoadLevels()
    {
        StaticScript.level = -1;
        StaticScript.playingOrNot = false;
        SceneManager.LoadScene("Levels", LoadSceneMode.Single);
    }
    public void LoadTutorial()
    {
        SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level3", LoadSceneMode.Single);
    }

    public void LoadLevel4()
    {
        SceneManager.LoadScene("Level4", LoadSceneMode.Single);
    }

    public void LoadLevel5()
    {
        SceneManager.LoadScene("Level5", LoadSceneMode.Single);
    }

    public void LoadLevel6()
    {
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

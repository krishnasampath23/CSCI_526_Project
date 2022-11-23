using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    // static variables are now handled in Assets\Scripts\UI\Level.cs
    public void LoadGame()
    {
        LoadLevel(StaticScript.level + 1);
    }

    public void LoadAgain()
    {
        LoadLevel(StaticScript.level);
    }

    public void LoadLevels()
    {
        StaticScript.level = -1;
        SceneManager.LoadScene("Levels", LoadSceneMode.Single);
    }

    public void LoadLevel(int level_id)
    {
        string scene_name;
        if (level_id > 6) scene_name = "Levels";
        if (level_id == 0) scene_name = "Tutorial";
        else scene_name = "Level" + level_id.ToString();
        SceneManager.LoadScene(scene_name);
    }

    public void LoadBack()
    {
        SceneManager.LoadScene("RestartScene", LoadSceneMode.Single);

    }

    public void LoadMenu(){
        SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

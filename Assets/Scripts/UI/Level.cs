using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    public int NoOfErasers = 3;
    public int NoOfBullets = 10;
    public int NoOfLines = 3;

    void Start()
    {
        StaticScript.success_or_fail = -1;
        StaticScript.playingOrNot = true;

        StaticScript.timePrevious = StaticScript.timeElapsed;

        StaticScript.health = 100;
        StaticScript.score = 0;
        StaticScript.lines_drawn = 0;
        StaticScript.enemies_killed = 0;
        StaticScript.no_color_switches = 0;

        StaticScript.no_of_erasers = NoOfErasers;
        StaticScript.no_of_poops = NoOfBullets;
        StaticScript.lines_limit = NoOfLines;
        StaticScript.no_of_enemies =
            GameObject.FindGameObjectsWithTag("Black Enemy").Length +
            GameObject.FindGameObjectsWithTag("Green Enemy").Length;

        string scene_name = SceneManager.GetActiveScene().name;
        if (scene_name == "Tutorial")
        {
            if (StaticScript.tutorial_flag)
            {
                StaticScript.no_of_enemies = 3;
            }
            else
            {
                StaticScript.no_of_enemies = 5;
            }
            StaticScript.tutorial_flag = true;
            StaticScript.level = 0;
        }
        else
        {
            int suffix = scene_name[scene_name.Length-1] - '0';
            if (suffix > 0 && suffix < 10)
                StaticScript.level = suffix;
        }
    }

    void Update()
    {

        StaticScript.timeElapsed+=Time.deltaTime;
        StaticScript.score = StaticScript.enemies_killed*100;

        if(StaticScript.enemies_killed == StaticScript.no_of_enemies && StaticScript.playingOrNot == true){
            StaticScript.success_or_fail = 1;
            StaticScript.playingOrNot = false;
            Debug.Log("End Game: Level Complete");
            SceneManager.LoadScene("RestartScene");
        }

        if(StaticScript.health == 0 && StaticScript.playingOrNot == true)
        {
            //Application.Quit(); // Replace this Play Again/ Restart scene
            StaticScript.playingOrNot = false;
            StaticScript.success_or_fail = 0;
            Debug.Log("End Game: Health Lost");
            SceneManager.LoadScene("FailScene");
        }
        if(StaticScript.no_of_poops == 0 && StaticScript.playingOrNot == true)
        {
            //Application.Quit(); // Replace this Play Again/ Restart scene
            Debug.Log("Number of bullets");
            Debug.Log(GameObject.FindGameObjectsWithTag("Bullet").Length);


            if(GameObject.FindGameObjectsWithTag("Bullet").Length == 1)
            {
                StaticScript.playingOrNot = false;
                StaticScript.success_or_fail = 0;
                Debug.Log("End Game: Poops Over");
                SceneManager.LoadScene("FailScene");
            }
        }
    }

}

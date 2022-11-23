using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    public float TimeLeft = 12;
    public int NoOfErasers = 3;
    public int NoOfBullets = 10;
    public int NoOfLines = 3;

    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        StaticScript.level = scene.name[scene.name.Length-1] - '0';

        StaticScript.success_or_fail = -1;
        StaticScript.playingOrNot = true;

        StaticScript.timerOn = true;
        StaticScript.timePrevious = StaticScript.timeElapsed;
        StaticScript.timeLeft = TimeLeft;

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

        if (StaticScript.timerOn && StaticScript.timeLeft > 0)
        {
            StaticScript.timeLeft -= Time.deltaTime / 4;
        }
    }

}

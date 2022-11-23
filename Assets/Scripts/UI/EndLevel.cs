using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{

    void Start()
    {
        StaticScript.timerOn = true;
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

using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIscript : MonoBehaviour
{
    public TMP_Text TimerTxt;
    public TMP_Text Score;
    public TMP_Text PoopNumTxt;
    public TMP_Text Lines_left;
    public TMP_Text Erasers;
    public Slider HealthBar;
    public Slider PoopBar;
   

    void Start()
    {
        StaticScript.timerOn = true;
        Lines_left.text = "= 0";
        PoopBar.maxValue = StaticScript.no_of_poops;
    }

    void Update()
    {

        StaticScript.timeElapsed+=Time.deltaTime;
        HealthBar.value = StaticScript.health;
        PoopBar.value = StaticScript.no_of_poops;
        StaticScript.score = StaticScript.enemies_killed*100;
        PoopNumTxt.text = "x" + StaticScript.no_of_poops.ToString();

        if(StaticScript.level == 0){
            Lines_left.text = "= " + (10000 - StaticScript.lines_drawn).ToString();
        }
        else {
            if (StaticScript.lines_drawn <= 3)
            {
                Lines_left.text = "= " + (StaticScript.lines_limit - StaticScript.lines_drawn).ToString();
            }
        }

        Erasers.text = "= " + StaticScript.no_of_erasers.ToString();

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
        Score.text = "score = " + StaticScript.score.ToString();

        if (StaticScript.timerOn && StaticScript.timeLeft > 0)
        {
            StaticScript.timeLeft -= Time.deltaTime / 4;

            if (StaticScript.timeLeft <= 10)
            {

                updateTimer(StaticScript.timeLeft);
                // TimerTxt.text = StaticScript.timeLeft.ToString();
            }
        }
    }

    void updateTimer(float currentTime){
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("{0:00} : {1:00}",minutes,seconds);
    }

}

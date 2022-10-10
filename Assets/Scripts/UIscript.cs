using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIscript : MonoBehaviour
{
    public TMP_Text TimerTxt;
    public TMP_Text Score;
    public Slider slider;
    public Slider slider1;




    void Start()
    {
        StaticScript.timerOn = true;
        Score.text = "score = 0";
        slider.maxValue = 100;
        slider.value = 100;
        slider1.maxValue = 10;
        slider1.value = 10;



    }

    void Update()
    {
        StaticScript.timeElapsed+=Time.deltaTime;
        slider.value = StaticScript.health;
        slider1.value = StaticScript.no_of_poops;
        if(StaticScript.enemies_killed == StaticScript.no_of_enemies){
            SceneManager.LoadScene("RestartScene");
        }
        if(StaticScript.health == 0)
        {
            //Application.Quit(); // Replace this Play Again/ Restart scene
            Debug.Log("End Game");
            SceneManager.LoadScene("FailScene");
        }
        if(StaticScript.no_of_poops == 0)
        {
            //Application.Quit(); // Replace this Play Again/ Restart scene
            Debug.Log("End Game");
            SceneManager.LoadScene("FailScene");
        }
        Score.text = "score = " + StaticScript.score.ToString();
        if(StaticScript.timerOn)
        {
            if(StaticScript.timeLeft > 0){
                StaticScript.timeLeft -= Time.deltaTime/4;
                updateTimer(StaticScript.timeLeft);
                // TimerTxt.text = StaticScript.timeLeft.ToString();

            }

            else{

                // TimerTxt.text = "Times Up !!!";
                // //Application.Quit(); // Replace this Play Again/ Restart scene
                // SceneManager.LoadScene("RestartScene");
                // Debug.Log("End Game");
            }
        }

        // basic.text = "Enemies Killed: " + StaticScript.counter.ToString();
    }

    void updateTimer(float currentTime){
        currentTime += 1;
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("{0:00} : {1:00}",minutes,seconds);
    }

    //public void Sethealth(int health)
    //{
    //    slider.value = health;
    //}

}

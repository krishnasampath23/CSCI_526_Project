using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class HintScript : MonoBehaviour
{
    [SerializeField]
    public TMPro.TMP_Text HintText;
    // public Text HintText;
    // // Start is called before the first frame update

    private float targetTime = 200.0f;
    private float lastTime = 0.0f;

     void Start() 
    {
        HintText.text = "";
    }

     private void FixedUpdate(){

        targetTime -= 1.0f;
        if (targetTime - lastTime<= 0.0f)
        {
           HintText.text = "";
        }
    }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    public void Level1_Hints()
    {
        targetTime = 200.0f;
        HintText.text = "Touch the platforms to change color";

    }
    public void Level2_Hints()
    {
        targetTime = 200.0f;
        HintText.text = "Try drawing a line which can reflect the bomb to reach enemies above current level.";

    }
    public void Level3_Hints()
    {
        targetTime = 500.0f;
        HintText.text = "Enemies' bullets can change the color of the platform. See where you can use an eraser and what angles you can use to draw lines to manipulate the enemy bullets.";

    }
    public void Level4_Hints()
    {
        targetTime = 350.0f;
        HintText.text = "Touching the beige colored shelters can kill the player.";

    }
    public void Level5_Hints()
    {
        targetTime = 350.0f;
        HintText.text = "See where you can use an eraser or draw lines to change the color of the platforms.";

    }
    public void Level6_Hints()
    {
        targetTime = 400.0f;
        HintText.text = "You could try drawing a line to stop the trajectory of bullets from one enemy. Use available lines very carefully.";

    }

}

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
        HintText.text = "Touch the platforms to change color";

    }

}

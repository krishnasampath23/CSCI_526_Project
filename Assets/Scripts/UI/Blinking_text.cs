
using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Blinking_text : MonoBehaviour
{
    private void Update()
    {
        if (StaticScript.timeLeft < 9) {
            GetComponent<Animator>().enabled = false;
        }
    }

}
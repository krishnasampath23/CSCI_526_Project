using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyCounter : MonoBehaviour
{
    public TMP_Text basic;
    void Start()
    {
        basic.text = "Enemies Killed: " + StaticScript.counter.ToString();
    }

    void Update()
    {
        basic.text = "Enemies Killed: " + StaticScript.counter.ToString();
    }
}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class lose : MonoBehaviour
{


    public TMP_Text Reason;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Reason.text = StaticScript.lose;
     }
}

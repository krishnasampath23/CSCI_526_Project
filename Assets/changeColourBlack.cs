using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColourBlack : MonoBehaviour
{
    
    public void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Player")){
            GetComponent<SpriteRenderer>().color = new Color (0,1,0,1);
        }
    }
}

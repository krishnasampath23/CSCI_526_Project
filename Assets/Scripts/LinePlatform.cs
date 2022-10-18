using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinePlatform : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Eraser")){
                Destroy(this.gameObject);
                Destroy(collision.gameObject);
            }

    }
}

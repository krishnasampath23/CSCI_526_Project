using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_gameobject : MonoBehaviour
{


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("person"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("player"))
        {
            Application.Quit(); // For Web GL Build
                                //UnityEditor.EditorApplication.isPlaying = false;
        }
    }


    //private void OnTriggerEnter2D(Collider2D collision)
    //{

    //    if (collision.gameObject.CompareTag("person"))
    //    {
    //        Destroy(collision.gameObject);
    //    }


    //}
}

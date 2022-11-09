using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Change the color of the object upon certain collisions
public class DynamicColor : MonoBehaviour
{
    public bool ByEnemyBullet = true;


    private SpriteRenderer sprite;
    private GameObject contactingWith = null;


    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        updateColor();
    }

    void updateColor()
    {
        if (contactingWith != null)
        {
            Color targetColor = contactingWith.GetComponent<SpriteRenderer>().color;
            if (gameObject.CompareTag("player") && sprite.color != targetColor)
            {
                StaticScript.no_color_switches+=1;
            }
            sprite.color = targetColor;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (ByEnemyBullet && collision.gameObject.CompareTag("EnemyBullet"))
        {
            contactingWith = collision.gameObject;
            updateColor();
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (GameObject.ReferenceEquals(collision.gameObject, contactingWith))
        {
            contactingWith = null;
        }
    }
}

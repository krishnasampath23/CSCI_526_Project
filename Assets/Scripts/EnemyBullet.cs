using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{   
    public float bulletSpeed = 15f;
    private Rigidbody2D rb;

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision){

            if (collision.gameObject.CompareTag("player")){
                StaticScript.health -= 10;
                Destroy(this.gameObject);
            }

            if (collision.gameObject.CompareTag("Platform1")){
                var colorValue = this.GetComponent<SpriteRenderer>().color;
                collision.gameObject.GetComponent<SpriteRenderer>().color = colorValue;
                Destroy(this.gameObject);
                TipScript.Ins.PlatformChangeGreen(colorValue);
            }
            if (collision.gameObject.CompareTag("Platform2")){
                collision.gameObject.GetComponent<SpriteRenderer>().color = this.GetComponent<SpriteRenderer>().color;
                Destroy(this.gameObject);
            }

            if (collision.gameObject.CompareTag("LevelStart")){
                Destroy(this.gameObject);
            }
            if (collision.gameObject.CompareTag("ground")){
                Destroy(this.gameObject);
            }

            if (collision.gameObject.CompareTag("Line"))
            {
                Destroy(this.gameObject);
            }

    }
    }

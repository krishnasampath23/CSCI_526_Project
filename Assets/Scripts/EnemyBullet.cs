using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{   
    public float bulletSpeed = 15f;
    public float bulletDamage = 10f;
    public Rigidbody2D rb;

    private void FixedUpdate(){
        //rb.velocity = Vector2.right * bulletSpeed;
        rb.velocity = Vector2.up * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision){

            if (collision.gameObject.CompareTag("player")){
                StaticScript.health -= 10;
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

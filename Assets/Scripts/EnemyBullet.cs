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
    //     if (collision.gameObject.CompareTag("person")){
    //         // Red person/BadPerson = person
    //         StaticScript.score += 100;
    //         StaticScript.timeLeft += 20;
    //         Destroy(collision.gameObject);
    //         Destroy(this.gameObject);
    //     }
    //     if (collision.gameObject.CompareTag("goodPerson"))
    //     {
    //         StaticScript.score -= 50;
    //         StaticScript.timeLeft -= 10;
    //         Destroy(collision.gameObject);
    //         Destroy(this.gameObject);
    //     }
    //     if (collision.gameObject.CompareTag("enemyFire"))
    //     {
    //         // Debug.Log("Hello");
    //         Destroy(collision.gameObject);
    //         Destroy(this.gameObject);
    //     }
    //     if (collision.gameObject.CompareTag("ground"))
    //     {
    //         // Debug.Log("Hello");
    //         Destroy(this.gameObject);
    //     }

            if (collision.gameObject.CompareTag("player")){
                StaticScript.health -= 10;
                Destroy(this.gameObject);
            }

            if (collision.gameObject.CompareTag("LevelStart")){
                Destroy(this.gameObject);
            }

            // if (collision.gameObject.CompareTag("Bullet")){
            //     Destroy(this.gameObject);
            //     // Destroy(collision.gameObject);
            // }



    }
    }

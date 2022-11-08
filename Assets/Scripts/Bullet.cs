using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   
    public float bulletSpeed = 15f;
    public float bulletDamage = 10f;
    public Rigidbody2D rb;

    private void FixedUpdate(){
        //rb.velocity = Vector2.right * bulletSpeed;
        rb.velocity = Vector2.down * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        //if (collision.gameObject.CompareTag("person")){
        //    // Red person/BadPerson = person
        //    StaticScript.score += 100;
        //    StaticScript.timeLeft += 20;
        //    Destroy(collision.gameObject);
        //    Destroy(this.gameObject);
        //}
        //if (collision.gameObject.CompareTag("goodPerson"))
        //{
        //    StaticScript.score -= 50;
        //    StaticScript.timeLeft -= 10;
        //    Destroy(collision.gameObject);
        //    Destroy(this.gameObject);
        //}

         if (collision.gameObject.CompareTag("Green Enemy"))
        {
            if(this.gameObject.GetComponent<SpriteRenderer>().color == collision.gameObject.GetComponent<SpriteRenderer>().color){
                StaticScript.enemies_killed += 1;
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
                TipScript.Ins.KillGreenEnemy();
            }
            else
            {
                Destroy(this.gameObject);
                TipScript.Ins.BlackBulletTouchGreenEnemy();
            }
        }

        if (collision.gameObject.CompareTag("Black Enemy"))
        {
            
            Destroy(this.gameObject);
            if(this.gameObject.GetComponent<SpriteRenderer>().color == collision.gameObject.GetComponent<SpriteRenderer>().color){
                StaticScript.enemies_killed += 1;
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
                TipScript.Ins.KillBlackEnemy();
            }
            else
            {
                
            }
        }

        if (collision.gameObject.CompareTag("Platform1"))
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Platform2"))
        {
            Destroy(this.gameObject);
        }
        
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("ground"))
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("EnemyShield"))
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }

    }
}

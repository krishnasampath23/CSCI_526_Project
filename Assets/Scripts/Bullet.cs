using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{   
    private float bulletSpeed = 100f;
    private float bulletDamage = 10f;
    private bool isref = false;

    private float targetTime = 10.0f;
    Vector2 lastVelocity;
    public Rigidbody2D rb;
    

    private void Start(){
        // rb.AddForce(Vector2.down * bulletSpeed);
        rb.velocity = Vector2.down * bulletSpeed;
        lastVelocity = rb.velocity;
    }

    private void FixedUpdate(){
        //rb.velocity = Vector2.right * bulletSpeed;
        // // rb.velocity = Vector2.down * bulletSpeed;
        // rb.velocity.x += bulletSpeed;
        // rb.velocity.y += bulletSpeed;
        // if(isref == true){
        //     // rb.velocity *= bulletSpeed*10;
        //     rb.AddForce(transform.position * bulletSpeed);
        //     isref = false;
        // }
        lastVelocity = rb.velocity;
        targetTime -= Time.deltaTime;
        if (targetTime <= 0.0f)
        {
            Destroy(this.gameObject);
        }
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

         if (collision.gameObject.CompareTag("Line"))
        {
            rb.velocity = Vector2.Reflect(lastVelocity, collision.contacts[0].normal);
            // if(isref==false){
            //     rb.velocity = Vector2.Reflect(lastVelocity, collision.contacts[0].normal);
            //     isref = true;
            // }
            
        }

         if (collision.gameObject.CompareTag("LevelStart"))
        {
            Destroy(this.gameObject);
            // rb.velocity = Vector2.Reflect(lastVelocity, collision.contacts[0].normal);
            // if(isref==false){
            //     rb.velocity = Vector2.Reflect(lastVelocity, collision.contacts[0].normal);
            //     isref = true;
            // }
        }


        if (collision.gameObject.CompareTag("Platform"))
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

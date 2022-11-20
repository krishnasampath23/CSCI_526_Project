using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{   
    private float bulletSpeed = 100f;
    private float targetTime = 10.0f;
    Vector2 lastVelocity;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * bulletSpeed;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Line"))
        {
            rb.velocity = Vector2.Reflect(lastVelocity, collision.contacts[0].normal);
            // if(isref==false){
            //     rb.velocity = Vector2.Reflect(lastVelocity, collision.contacts[0].normal);
            //     isref = true;
            // }
            
        }
        // else if (collision.gameObject.CompareTag("LevelStart"))
        // {
        //     rb.velocity = Vector2.Reflect(lastVelocity, collision.contacts[0].normal);
        //     // if(isref==false){
        //     //     rb.velocity = Vector2.Reflect(lastVelocity, collision.contacts[0].normal);
        //     //     isref = true;
        //     // }
        // }
        else {
            Destroy(this.gameObject);
        }

        
    }
}

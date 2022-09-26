using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireScript : MonoBehaviour
{
    public float bulletSpeed = 15f;
    public float bulletDamage = 10f;
    public Rigidbody2D rb;

    private void FixedUpdate()
    {
        //rb.velocity = Vector2.right * bulletSpeed;
        rb.velocity = Vector2.up * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            Debug.Log("Hello");
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("LevelStart"))
        {
            //Debug.Log("Hello");
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Debug.Log("Hello");
            //Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}

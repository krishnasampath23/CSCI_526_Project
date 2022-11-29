using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private float bulletSpeed = 100f;
    private float targetTime = 10.0f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * bulletSpeed;
        Destroy(this.gameObject, targetTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Line"))
        {
            rb.velocity = Vector2.Reflect(rb.velocity, collision.contacts[0].normal);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}

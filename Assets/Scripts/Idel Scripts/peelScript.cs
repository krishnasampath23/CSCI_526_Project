using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class peelScript : MonoBehaviour
{
    public float bulletSpeed = 0;
    public float bulletDamage = 10f;
    public Rigidbody2D rb;

    [SerializeField]
    bool isGrounded = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        // transform.Translate(Vector2.right * Time.deltaTime/2);
       /* if (isGrounded == false)
        {
            // transform.Translate(Vector2.left);
            transform.Translate(Vector2.down / 500);
        }*/

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Debug.Log("Hello");
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("ground"))
        {
            if (isGrounded == false)
            {
                isGrounded = true;
            }
        }
    }
}

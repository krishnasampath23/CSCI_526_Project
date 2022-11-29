using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlockMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private float currentX;
    public float velocityX = 20;
    public float rangeVal = 25;
    public bool initialRightDirection = false;

    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
      spriteRenderer = GetComponent<SpriteRenderer>();
      currentX = rb.position.x;
      changeDirection(initialRightDirection);
    }

    void Update()
    {
      if (rb.position.x >= currentX+rangeVal)
      {
        changeDirection(false);
      }
      if (rb.position.x <= currentX-rangeVal)
      {
        changeDirection(true);
      }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
      if (!enabled) return;
      if (collision.gameObject.CompareTag("Line") || collision.gameObject.CompareTag("player"))
      {
        changeDirection(rb.velocity.x < 0);
      }
    }

    void changeDirection(bool toRight)
    {
      rb.velocity = (toRight ? Vector2.right : Vector2.left) * velocityX;
      spriteRenderer.flipX = !toRight;
    }
}

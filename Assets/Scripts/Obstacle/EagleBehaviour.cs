using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleBehaviour : MonoBehaviour
{
    Rigidbody2D robotrigidbody2D;
    SpriteRenderer spriteRender;
    private int moveSpeedX;
    private const int MinSpeedX = 10;
    private const int MaxSpeedX = 30;

    Vector2 position;
    float currentDis;

    void Start()
    {
        robotrigidbody2D = GetComponent<Rigidbody2D>();
        spriteRender = GetComponent<SpriteRenderer>();
        transform.localPosition = new Vector2(200, Random.Range(-80, 10));
        moveSpeedX = -Random.Range(MinSpeedX, MaxSpeedX);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        position = robotrigidbody2D.position;
        position.x += moveSpeedX * Time.deltaTime;
        robotrigidbody2D.MovePosition(position);
        if (spriteRender.flipX && transform.localPosition.x < -200
            || !spriteRender.flipX && transform.localPosition.x >= 200)
        {
            EagleFactory.Ins.BackToPool(gameObject);
            return;
        }

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            spriteRender.flipX = !spriteRender.flipX;
            moveSpeedX = -moveSpeedX * 2;
        }
    }
}



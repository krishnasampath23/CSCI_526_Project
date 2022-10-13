using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehaviour : MonoBehaviour
{
    Rigidbody2D robotrigidbody2D;
    public int moveSpeedX;
    public int moveSpeedY;
    public float moveDistanceX;
    public float moveDistanceY;
    public int directionX = 1;
    public int directionY = 1;
    float initx, inity;
    Vector2 position;
    float currentDis;

    void Start()
    {
        robotrigidbody2D = GetComponent<Rigidbody2D>();
        initx = transform.position.x;
        inity = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        position = robotrigidbody2D.position;

        position.x += moveSpeedX * directionX * Time.deltaTime;
        currentDis = Mathf.Abs(position.x - initx);
        if (currentDis < 0.01f || currentDis > moveDistanceX)
        {
            directionX *= -1;
        }

        position.y += moveSpeedY * directionY * Time.deltaTime;
        currentDis = Mathf.Abs(position.y - inity);
        if (currentDis < 0.01f || currentDis > moveDistanceY)
        {
            directionY *= -1;
        }

        //¸ü¸ÄÎ»ÖÃ
        robotrigidbody2D.MovePosition(position);

    }
}

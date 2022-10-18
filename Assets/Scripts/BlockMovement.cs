using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlockMovement : MonoBehaviour
{
    public GameObject block;
    private Rigidbody2D rb;
    private float currentX;
    private int val;
    public bool isRightDirection=false;
    private void Awake(){
      rb = GetComponent<Rigidbody2D>();
    }
    // private void FixedUpdate(){
    //   rb.velocity = new Vector2(20f, 0f);
    // }
    float rangeVal;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
      currentX = block.transform.position.x;
      rangeVal = Random.Range(15f,35f);
      val = Random.Range(1,3);
      Debug.Log(val);
      if(val == 1)
      {
        isRightDirection = true;
      }
      if(val ==  2)
      {
        isRightDirection = false;
      }
      spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
      if(isRightDirection)
      {
        moveObjectRight();
      }
      if(!isRightDirection)
      {
        moveObjectLeft();
      }
      if(block.transform.position.x >=currentX+rangeVal)
      {
        isRightDirection = false;
        spriteRenderer.flipX = true;
      }
      if(block.transform.position.x <= currentX-rangeVal)
      {
        isRightDirection = true;
        spriteRenderer.flipX = false;
      }
    }
    void moveObjectRight()
    {
      rb.velocity = new Vector2(20f, 0f);
    }
    void moveObjectLeft()
    {
      rb.velocity = new Vector2(-20f, 0f);
    }
    void OnCollisionEnter2D(Collision2D collision2D)
    {
      if(isRightDirection)
      {
        isRightDirection = false;
        spriteRenderer.flipX = true;
      }
      else if(!isRightDirection)
      {
        isRightDirection = true;
        spriteRenderer.flipX = false;
      }
    }
}

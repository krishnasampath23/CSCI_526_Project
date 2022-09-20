using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalking : MonoBehaviour
{
    Vector2 back = new Vector2(0, 0); //assign it whatever value you want one edge of the movement to be
    Vector2 forth = new Vector2(100, 0); //again, assign whatever the other edge is supposed to be
    float phase = 0.5F;
    float speed = 0.2F; //adjust to anything that results in the speed u want
    float phaseDirection = 1; //this is just to make the code less "ify" =D

    [SerializeField]
    bool isGrounded = false;
    Rigidbody2D rb;
    float moveSpeed = 5f;
    Transform target;
    Vector2 moveDirection;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
       
    }

    void Update()
    {
        transform.position = Vector3.Lerp(back, forth, phase); //phase determines (in percent, basically) where on the line between the points "back" and "forth" you want the enemy to be placed, so if we gradually increase/decrease the variable, it makes the enemy move between those two points.
        phase += Time.deltaTime * speed * phaseDirection; //subtracts from 1 to zero when phaseDirection is negative, adds from zero to one when phaseDirection is positive.
        if (phase >= 1 || phase <= 0) phaseDirection *= -1; //flip the sign to flip direction
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        /*if (collision.gameObject.CompareTag("ground"))
        {
            if (isGrounded == false)
            {
                isGrounded = true;
            }
        }*/

        if (collision.gameObject.CompareTag("player"))
        {
            Application.Quit(); // For Web GL Build
                                //UnityEditor.EditorApplication.isPlaying = false;

        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Debug.Log("Hello");
            Vector3 currScale = transform.localScale;
            currScale[0] -= 4;
            currScale[1] -= 4;
            if (currScale[0] > 0)
            {
                transform.localScale = currScale;
            }
            else
            {

                Destroy(this.gameObject);
            }
            isGrounded = false;
        }

        if (collision.gameObject.CompareTag("Peel"))
        {
            // Debug.Log("Hello");
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("obstacle"))
        {
            transform.Translate(Vector2.left * 2 * Time.deltaTime);

        }


    }
}


using UnityEngine;

public class EnemyScript : MonoBehaviour
{
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
        if (isGrounded == false)
        {
            transform.Translate(Vector2.down/200);
        }

        target = GameObject.Find("Player").transform;


    }

    // Update is called once per frame
    private void Update()
    {
        
        // transform.Translate(Vector2.right * Time.deltaTime/2);
        if (isGrounded == false)
        {
            transform.Translate(Vector2.down/200);
        }

        else if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
            moveDirection = direction;
        }
    }

    private void FixedUpdate()
    {
        if (isGrounded == false)
        {
            transform.Translate(Vector2.down / 200);
        }

        else if (target)
        {
            rb.velocity = new Vector2(moveDirection.x, transform.position.y) * moveSpeed;

        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            if (isGrounded == false)
            {
                isGrounded = true;
            }
        }

        if (collision.gameObject.CompareTag("player"))
        {
             //Application.Quit(); // For Web GL Build
             //UnityEditor.EditorApplication.isPlaying = false;
            
        }
        if (collision.gameObject.CompareTag("Bullet")){
            // Debug.Log("Hello");
            // Vector3 currScale = transform.localScale;
            // currScale[0] -= 4;
            // currScale[1] -= 4;
            // if(currScale[0] > 0)
            // {
            //     transform.localScale = currScale;
            // }
            // else
            // {
            //     // StaticScript.score += 1;
            //     // Debug.Log("hello");
            //     Destroy(this.gameObject);
            // }
            // isGrounded = false;
            StaticScript.enemies_killed += 1;
            Destroy(this.gameObject);

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

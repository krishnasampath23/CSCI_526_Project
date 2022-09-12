
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    bool isGrounded = false;
    Rigidbody2D rb;
    float moveSpeed = 3f;
    Transform target;
    Vector2 moveDirection;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    private void Update()
    {
        // transform.Translate(Vector2.right * Time.deltaTime/2);
        if(isGrounded == false)
        {
            transform.Translate(Vector2.down /200);
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
        if(target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;

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
             UnityEditor.EditorApplication.isPlaying = false;
            
        }

        if (collision.gameObject.CompareTag("obstacle"))
        {
            transform.Translate(Vector2.left * 2 * Time.deltaTime);

        }


    }
}

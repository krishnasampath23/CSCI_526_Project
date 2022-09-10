
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]
    bool isGrounded = false;

    Rigidbody2D RB;

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate(Vector2.right * Time.deltaTime/2);
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

        if (collision.gameObject.CompareTag("obstacle"))
        {
            transform.Translate(Vector2.left * 2 * Time.deltaTime);

        }


    }
}

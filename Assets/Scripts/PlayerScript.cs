
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float JumpForce;
    float score;

    [SerializeField]
    bool isGrounded = false;
    bool isAlive = true;

    public float MinSpeed;
    public float MaxSpeed;
    public float CurrSpeed;

    public float SpeedMultiplier;

    Rigidbody2D RB;

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        CurrSpeed = MinSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector2.right * CurrSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(isGrounded==false)
            {
                RB.AddForce(Vector2.up * JumpForce);
                isGrounded = false;
            }

        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RB.AddForce(Vector2.right * JumpForce);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            RB.AddForce(Vector2.left * JumpForce);
        }

        if (isAlive)
        {
            score += Time.deltaTime * 10;
        }

        if (CurrSpeed < MaxSpeed)
        {
            CurrSpeed += SpeedMultiplier;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            if (isGrounded == false)
            {
                isGrounded = true;
            }
        }
    }
}

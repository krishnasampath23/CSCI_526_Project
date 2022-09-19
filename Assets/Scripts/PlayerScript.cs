
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

    int playerLives = 3;

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

        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            Application.Quit(); ; // For Web GL Build
            Debug.Log("All enemies are dead");
            //UnityEditor.EditorApplication.isPlaying = false;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            /*if(isGrounded==true)
            {
                RB.AddForce(Vector2.up * JumpForce);
                isGrounded = false;
            }*/
            if (isGrounded == false)
            {
                RB.AddForce(Vector2.up * JumpForce);
                isGrounded = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            RB.AddForce(Vector2.right * JumpForce);
        }

        if (Input.GetKeyDown(KeyCode.A))
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

            Application.Quit();
            //UnityEditor.EditorApplication.isPlaying = false;

        }
        if (collision.gameObject.CompareTag("enemyFire"))
        {
            playerLives -= 1;
            if (playerLives <= 0)
            {
                Application.Quit();
                //UnityEditor.EditorApplication.isPlaying = false;
            }
        }
    }
}

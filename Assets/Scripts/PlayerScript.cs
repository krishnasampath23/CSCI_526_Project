
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public bool WASDEnabled = true;

    public float JumpForce;
    float score;

    [SerializeField]
    bool isGrounded = false;
    bool isAlive = true;


    int playerLives = 3;


    Rigidbody2D RB;

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            Application.Quit(); ; // For Web GL Build
            Debug.Log("All enemies are dead");
            //UnityEditor.EditorApplication.isPlaying = false;
        }

        move();

        if (isAlive)
        {
            score += Time.deltaTime * 10;
        }

    }

    private void move()
    {
        Vector2 input = new Vector2();;
        if (WASDEnabled)
        {
            if (Input.GetKeyDown(KeyCode.W)) input += Vector2.up;
            if (Input.GetKeyDown(KeyCode.D)) input += Vector2.right;
            if (Input.GetKeyDown(KeyCode.A)) input += Vector2.left;
            if (Input.GetKeyDown(KeyCode.S)) input += Vector2.down;
        }
        RB.AddForce(input * JumpForce);
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

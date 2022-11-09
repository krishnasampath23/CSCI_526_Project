
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public bool WASDEnabled = true;
    public bool ArrowKeysEnabled = true;
    public bool RightClickMoveEnabled = false;

    private float maxSpeed = 100f;

    public float JumpForce;

    [SerializeField]
    Rigidbody2D RB;

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    private void move()
    {
        Vector2 input = new Vector2();
        if (WASDEnabled)
        {
            // if (Input.GetKeyDown(KeyCode.W)) input += Vector2.up;
            // if (Input.GetKeyDown(KeyCode.A)) input += Vector2.left;
            // if (Input.GetKeyDown(KeyCode.S)) input += Vector2.down;
            // if (Input.GetKeyDown(KeyCode.D)) input += Vector2.right;
            if (Input.GetKey(KeyCode.W)) input = Vector2.up;
            if (Input.GetKey(KeyCode.A)) input = Vector2.left;
            if (Input.GetKey(KeyCode.S)) input = Vector2.down;
            if (Input.GetKey(KeyCode.D)) input = Vector2.right;
            if(input == Vector2.up || input == Vector2.left || input == Vector2.down || input == Vector2.right)
            {
                TipScript.Ins.DirStepOk();
            }
        }
        if (ArrowKeysEnabled)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow)) input += Vector2.up;
            if (Input.GetKeyDown(KeyCode.LeftArrow)) input += Vector2.left;
            if (Input.GetKeyDown(KeyCode.DownArrow)) input += Vector2.down;
            if (Input.GetKeyDown(KeyCode.RightArrow)) input += Vector2.right;
        }
        if (RightClickMoveEnabled)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Vector2 delta = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                delta.Normalize();
                input += delta;
            }
        }
        RB.AddForce(input * JumpForce);
        // check if speed > maxSpeed
        if(RB.velocity.magnitude > maxSpeed)
        {
            RB.velocity = RB.velocity.normalized * maxSpeed;
        }
        // RB.velocity = input * JumpForce;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            // StaticScript.health = 0;
            if(StaticScript.playingOrNot == true)
            {
                StaticScript.playingOrNot = false;
                Debug.Log("Hit Ground : End Game");
                StaticScript.success_or_fail = 0;
                StaticScript.lines_drawn=GameObject.FindGameObjectsWithTag("Line").Length;
                SceneManager.LoadScene("FailScene");
            }
            //Application.Quit(); // Replace this Play Again/ Restart scene
            //UnityEditor.EditorApplication.isPlaying = false;

        }

        if (collision.gameObject.CompareTag("EnemyShield"))
        {
            StaticScript.health -= 10;
            RB.AddForce(Vector2.up * 2000);

        }

        if (collision.gameObject.name == "Green Platform")
        {
            TipScript.Ins.ToGreenPlatformOK();
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            StaticScript.health -= 10;
            RB.AddForce(Vector2.up * 2000);

        }
        if (collision.gameObject.CompareTag("Green Enemy"))
        {
            StaticScript.health -= 10;
            RB.AddForce(Vector2.up * 1000);
        }
        if (collision.gameObject.CompareTag("Black Enemy"))
        {
            StaticScript.health -= 10;
            RB.AddForce(Vector2.up * 1000);
        }

        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            StaticScript.health -= 10;
        }
    }
}

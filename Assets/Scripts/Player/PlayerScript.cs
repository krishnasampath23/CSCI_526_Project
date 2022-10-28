
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public bool WASDEnabled = true;
    public bool ArrowKeysEnabled = true;
    public bool RightClickMoveEnabled = false;

    public float JumpForce;
    float score;

    [SerializeField]
    bool isGrounded = false;
    bool isAlive = true;
    public string whichPlatform;
    bool isCurrentlyColliding = false;
    Rigidbody2D RB;

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isCurrentlyColliding == true){
            // Debug.Log(whichPlatform);
            if(this.GetComponent<SpriteRenderer>().color != GameObject.FindGameObjectWithTag(whichPlatform).GetComponent<SpriteRenderer>().color){
                StaticScript.no_color_switches+=1;
            }
            this.GetComponent<SpriteRenderer>().color=GameObject.FindGameObjectWithTag(whichPlatform).GetComponent<SpriteRenderer>().color;

        }

        //StaticScript.score += 1;


        if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            //Application.Quit(); ; // For Web GL Build
            //Debug.Log("All enemies are dead");
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
        // RB.velocity = input * JumpForce;
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform1"))
        {

            whichPlatform = "Platform1";
            // if(this.GetComponent<SpriteRenderer>().color != collision.gameObject.GetComponent<SpriteRenderer>().color){
            //     StaticScript.no_color_switches+=1;
            // }
            this.GetComponent<SpriteRenderer>().color = collision.gameObject.GetComponent<SpriteRenderer>().color;
            isCurrentlyColliding = false;
            // GetComponent<SpriteRenderer>().color = new Color (0,0,0,1);

        }

        if (collision.gameObject.CompareTag("Platform2"))
        {
            whichPlatform = "Platform2";
            // if(this.GetComponent<SpriteRenderer>().color != collision.gameObject.GetComponent<SpriteRenderer>().color){
            //     StaticScript.no_color_switches+=1;
            // }
            this.GetComponent<SpriteRenderer>().color = collision.gameObject.GetComponent<SpriteRenderer>().color;
            isCurrentlyColliding = false;
            // GetComponent<SpriteRenderer>().color = new Color32 (5,137,35,255);

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
        // if (collision.gameObject.CompareTag("person"))
        // {
        //     StaticScript.health -= 20;
        //     Destroy(collision.gameObject);
        // }

        // if (collision.gameObject.CompareTag("food"))
        // {
        //     StaticScript.no_of_poops += 1;
        //     Destroy(collision.gameObject);

        //     //Application.Quit();
        //     //UnityEditor.EditorApplication.isPlaying = false;

        // }
        if (collision.gameObject.CompareTag("EnemyShield"))
        {
            StaticScript.health -= 10;
            RB.AddForce(Vector2.up * 2000);

        }

        if (collision.gameObject.CompareTag("Platform1"))
        {
            whichPlatform = "Platform1";
            if(this.GetComponent<SpriteRenderer>().color != collision.gameObject.GetComponent<SpriteRenderer>().color){
                StaticScript.no_color_switches+=1;
            }
            this.GetComponent<SpriteRenderer>().color = collision.gameObject.GetComponent<SpriteRenderer>().color;
            isCurrentlyColliding = true;
            // GetComponent<SpriteRenderer>().color = new Color (0,0,0,1);

        }

        if (collision.gameObject.CompareTag("Platform2"))
        {
            whichPlatform = "Platform2";
            if(this.GetComponent<SpriteRenderer>().color != collision.gameObject.GetComponent<SpriteRenderer>().color){
                StaticScript.no_color_switches+=1;
            }
            this.GetComponent<SpriteRenderer>().color = collision.gameObject.GetComponent<SpriteRenderer>().color;
            isCurrentlyColliding = true;
            // GetComponent<SpriteRenderer>().color = new Color32 (5,137,35,255);

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
    }
}

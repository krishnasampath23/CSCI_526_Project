using System.Collections;
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
            if (Input.GetKey(KeyCode.UpArrow)) input += Vector2.up;
            if (Input.GetKey(KeyCode.LeftArrow)) input += Vector2.left;
            if (Input.GetKey(KeyCode.DownArrow)) input += Vector2.down;
            if (Input.GetKey(KeyCode.RightArrow)) input += Vector2.right;
            if (input == Vector2.up || input == Vector2.left || input == Vector2.down || input == Vector2.right)
            {
                TipScript.Ins.DirStepOk();
            }
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
    }


    IEnumerator FadeAlphaToZero(SpriteRenderer renderer, float fadeSpeed, GameObject G1)
    {

        Color matColor = renderer.material.color;
        float alphaValue = renderer.material.color.a;

        while (renderer.material.color.a > 0f)
        {
            alphaValue -= Time.deltaTime / fadeSpeed;
            renderer.material.color = new Color(matColor.r, matColor.g, matColor.b, alphaValue);
            yield return null;
            //yield return new WaitForSeconds(500);
        }
        renderer.material.color = new Color(matColor.r, matColor.g, matColor.b, 0f);
        //Destroy(G1);
        SceneManager.LoadScene("FailScene");

    }



    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
            Debug.Log("Hit Ground : End Game");
            StaticScript.success_or_fail = 0;
            StaticScript.lines_drawn=GameObject.FindGameObjectsWithTag("Line").Length;
            StartCoroutine(FadeAlphaToZero(this.gameObject.GetComponent<SpriteRenderer>(), 0.5f, this.gameObject));
        }

        if (collision.gameObject.CompareTag("EnemyShield"))
        {
            StaticScript.health -= 10;
            RB.AddForce(Vector2.up * 2000);
            if (StaticScript.health == 0)
            {
                StaticScript.success_or_fail = 0;
                Debug.Log("End Game: Health Lost");
                StartCoroutine(FadeAlphaToZero(this.gameObject.GetComponent<SpriteRenderer>(), 0.5f, this.gameObject));
            }


        }

        if (collision.gameObject.name == "Green Platform")
        {
            TipScript.Ins.ToGreenPlatformOK();
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            StaticScript.health -= 10;
            RB.AddForce(Vector2.up * 2000);
            if (StaticScript.health == 0)
            {
                StaticScript.success_or_fail = 0;
                Debug.Log("End Game: Health Lost");
                StartCoroutine(FadeAlphaToZero(this.gameObject.GetComponent<SpriteRenderer>(), 0.5f, this.gameObject));
            }


        }
        if (collision.gameObject.CompareTag("Green Enemy"))
        {
            StaticScript.health -= 10;
            RB.AddForce(Vector2.up * 1000);
            if (StaticScript.health == 0)
            {
                StaticScript.success_or_fail = 0;
                Debug.Log("End Game: Health Lost");
                StartCoroutine(FadeAlphaToZero(this.gameObject.GetComponent<SpriteRenderer>(), 0.5f, this.gameObject));
            }

        }
        if (collision.gameObject.CompareTag("Black Enemy"))
        {
            StaticScript.health -= 10;
            RB.AddForce(Vector2.up * 1000);
            if (StaticScript.health == 0)
            {
                StaticScript.success_or_fail = 0;
                Debug.Log("End Game: Health Lost");
                StartCoroutine(FadeAlphaToZero(this.gameObject.GetComponent<SpriteRenderer>(), 0.5f, this.gameObject));
            }

        }

        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            StaticScript.health -= 10;
            if (StaticScript.health == 0)
            {
                StaticScript.success_or_fail = 0;
                Debug.Log("End Game: Health Lost");
                StartCoroutine(FadeAlphaToZero(this.gameObject.GetComponent<SpriteRenderer>(), 0.5f, this.gameObject));
            }

        }
    }
}

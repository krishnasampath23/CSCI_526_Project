using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletSpeed = 100f;
    private float bulletDamage = 10f;
    private bool isref = false;

    private float targetTime = 10.0f;
    Vector2 lastVelocity;
    public Rigidbody2D rb;


    private void Start(){
        rb.velocity = Vector2.down * bulletSpeed;
        lastVelocity = rb.velocity;
        Destroy(this.gameObject, targetTime);
    }

    private void FixedUpdate(){
        lastVelocity = rb.velocity;
    }

    IEnumerator FadeAlphaToZero(SpriteRenderer renderer, float fadeSpeed, GameObject G1, int enemycheck)
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
        renderer.material.color = new Color(matColor.r, matColor.g, matColor.b, 0.0f);
        renderer.material.color = new Color(matColor.r, matColor.g, matColor.b, 0f);
        Destroy(G1);
        if (enemycheck == 1)
        {
            StaticScript.enemies_killed += 1;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision){

         if (collision.gameObject.CompareTag("Green Enemy"))
        {

            if (StaticScript.level != 0)
            {
                if (this.gameObject.GetComponent<SpriteRenderer>().color == collision.gameObject.GetComponent<SpriteRenderer>().color)
                {
                    StartCoroutine(FadeAlphaToZero(collision.gameObject.GetComponent<SpriteRenderer>(), 0.5f, collision.gameObject,1));
                    StartCoroutine(FadeAlphaToZero(this.gameObject.GetComponent<SpriteRenderer>(), 0.5f, this.gameObject, 0));
                }
                else
                {
                    Destroy(this.gameObject);

                }

            }

            else
            {
                if (this.gameObject.GetComponent<SpriteRenderer>().color == collision.gameObject.GetComponent<SpriteRenderer>().color)
                {
                    StaticScript.enemies_killed += 1;
                    Destroy(collision.gameObject);
                    Destroy(this.gameObject);
                    TipScript.Ins.KillGreenEnemy();
                }
                else
                {
                    Destroy(this.gameObject);
                    TipScript.Ins.BlackBulletTouchGreenEnemy();
                }
            }
        }

        if (collision.gameObject.CompareTag("Black Enemy"))
        {
            if (StaticScript.level != 0)
            {
                if (this.gameObject.GetComponent<SpriteRenderer>().color == collision.gameObject.GetComponent<SpriteRenderer>().color)
                {

                    StartCoroutine(FadeAlphaToZero(collision.gameObject.GetComponent<SpriteRenderer>(), 0.5f, collision.gameObject,1));
                    StartCoroutine(FadeAlphaToZero(collision.gameObject.GetComponent<SpriteRenderer>(), 0.5f, this.gameObject, 0));
                    //StaticScript.enemies_killed += 1;
                    //TipScript.Ins.KillBlackEnemy();

                }
                else
                {
                    Destroy(this.gameObject);
                }

            }
            else
            {
                Destroy(this.gameObject);
                if (this.gameObject.GetComponent<SpriteRenderer>().color == collision.gameObject.GetComponent<SpriteRenderer>().color)
                {
                    StaticScript.enemies_killed += 1;
                    Destroy(collision.gameObject);
                    Destroy(this.gameObject);
                    TipScript.Ins.KillBlackEnemy();
                }
                else
                {
                    Destroy(this.gameObject);
                }
            }

        }

         if (collision.gameObject.CompareTag("Line"))
        {
            rb.velocity = Vector2.Reflect(lastVelocity, collision.contacts[0].normal);
            // if(isref==false){
            //     rb.velocity = Vector2.Reflect(lastVelocity, collision.contacts[0].normal);
            //     isref = true;
            // }
            
        }

         if (collision.gameObject.CompareTag("LevelStart"))
        {
            Destroy(this.gameObject);
            // rb.velocity = Vector2.Reflect(lastVelocity, collision.contacts[0].normal);
            // if(isref==false){
            //     rb.velocity = Vector2.Reflect(lastVelocity, collision.contacts[0].normal);
            //     isref = true;
            // }
        }


        if (collision.gameObject.CompareTag("Platform"))
        {
            Destroy(this.gameObject);
        }
        
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("ground"))
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("EnemyShield"))
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }

    }
}

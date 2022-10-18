
using UnityEngine;
using System.Collections;



public class WaterScript : MonoBehaviour
{
    public WaterGenerator waterGenerator;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * waterGenerator.CurrSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("nextLine"))
        {
            waterGenerator.GenerateNextWaterWithGap();
        }

        if (collision.gameObject.CompareTag("player"))
        {
            
            Destroy(this.gameObject);
            //Time.timeScale = 0;

        }

        /*if (collision.gameObject.CompareTag("obstacle"))
        {
            float temp = waterGenerator.CurrSpeed;
            waterGenerator.CurrSpeed = 0;
            StartCoroutine(Waiter());
            waterGenerator.CurrSpeed = temp;

        }*/

        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(this.gameObject);
        }
    }
    IEnumerator Waiter()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
    }
}

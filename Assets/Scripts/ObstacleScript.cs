
using UnityEngine;
using System.Collections;

public class ObstacleScript : MonoBehaviour
{
    public ObstacleGenerator obstacleGenerator;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * obstacleGenerator.CurrSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("nextLine"))
        {
            obstacleGenerator.GenerateNextObstacleWithGap();
        }

        if (collision.gameObject.CompareTag("player"))
        {
            if(this.gameObject.tag == "obstacle1")
            {
                //Time.timeScale = 0;
                //Application.Quit(); // For Web GL Build
                //UnityEditor.EditorApplication.isPlaying = false;
            }
            obstacleGenerator.CurrSpeed = obstacleGenerator.CurrSpeed - 5;
            Destroy(this.gameObject);
        }



        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(this.gameObject);
        }
    }

    /*public void Quit()
    {
        /*if UNITY_STANDALONE
                Application.Quit();
        #endif
       // #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }*/

    IEnumerator Waiter()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1);
    }
}

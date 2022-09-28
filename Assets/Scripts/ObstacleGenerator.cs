
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    /*
    public GameObject obstacle;
    public GameObject water;
    GameObject instance;

    public float MinSpeed;
    public float MaxSpeed;
    public float CurrSpeed;

    public float SpeedMultiplier;

    void Awake()
    {
        instance = obstacle;
        CurrSpeed = MinSpeed;
        generateObstacle();
    }

    public void GenerateNextObstacleWithGap()
    {
        float randomWait = Random.Range(0.1f, 0.7f);
        int random = Random.Range(0, 2);
        Debug.Log(random);
        if (random == 0)
        {
            instance = water;
        }
        else
        {
            instance = obstacle;
        }
        Invoke("generateObstacle", randomWait);
    }

    void generateObstacle()
    {
        GameObject ObstacleIns = Instantiate(instance, transform.position, transform.rotation);

        ObstacleIns.GetComponent<ObstacleScript>().obstacleGenerator = this;
    }


    // Update is called once per frame
    void Update()
    {
        if (CurrSpeed < MaxSpeed)
        {
            CurrSpeed += SpeedMultiplier;
        }
    }
*/
}

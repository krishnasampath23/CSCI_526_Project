
using UnityEngine;

public class WaterGenerator : MonoBehaviour
{
    public GameObject water;

    public float MinSpeed;
    public float MaxSpeed;
    public float CurrSpeed;

    public float SpeedMultiplier;

    void Awake()
    {
        CurrSpeed = MinSpeed;
        generateWater();
    }

    public void GenerateNextWaterWithGap()
    {
        float randomWait = Random.Range(0.1f, 0.7f);
        Invoke("generateWater", randomWait);
    }

    void generateWater()
    {
        GameObject WaterIns = Instantiate(water, transform.position, transform.rotation);

        WaterIns.GetComponent<WaterScript>().waterGenerator = this;
    }


    // Update is called once per frame
    void Update()
    {
        if (CurrSpeed < MaxSpeed)
        {
            CurrSpeed += SpeedMultiplier;
        }
    }
}

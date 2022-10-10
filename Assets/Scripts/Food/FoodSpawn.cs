using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawn : MonoBehaviour
{
    public GameObject[] foodItem;
    public Vector3 minValue;
    public Vector3 maxValue;
    private List<GameObject> q;


    // Start is called before the first frame update
    void Start()
    {
        q = new List<GameObject>();
        InvokeRepeating("spawnObject", 0, 3);
    }
    void spawnObject()
    {
        GameObject item = Instantiate(foodItem[Random.Range(0, foodItem.Length)]);
        item.transform.position = transform.position + new Vector3(Random.Range(minValue.x, maxValue.x),
        Random.Range(minValue.y, maxValue.y), 0);
        item.transform.parent = transform;
        q.Add(item);
        Object.Destroy(q[0], 5.0f);
        q.Remove(q[0]);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            StaticScript.no_of_poops += 1;
            Destroy(this.gameObject);

            //Application.Quit();
            //UnityEditor.EditorApplication.isPlaying = false;

        }
    }
}
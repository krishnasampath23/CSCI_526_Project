using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person_Spawner : MonoBehaviour
{

    [SerializeField]
    private GameObject[] personReference;

    [SerializeField]
    private Transform leftpos, rightpos ;

    private GameObject SpawnedPlayer;
    private int randomIndex;
    private int randomside;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPlayer());
    }

    IEnumerator SpawnPlayer()
    {
        while (true)
        {

            yield return new WaitForSeconds(Random.Range(3, 10));
            //randomIndex = Random.Range(0, personReference.Length);
            randomside = Random.Range(0, 2);

            SpawnedPlayer = Instantiate(personReference[0]);

            // left side
            if (randomside == 0)
            {
                SpawnedPlayer.transform.position = leftpos.position;
                SpawnedPlayer.transform.localScale = new Vector3(10f, 10f, 1f);
                SpawnedPlayer.GetComponent<Person>().speed = Random.Range(20,30);

            }
            else
            {   // right side
                SpawnedPlayer.transform.position = rightpos.position;
                SpawnedPlayer.GetComponent<Person>().speed = -Random.Range(20, 30);
                SpawnedPlayer.transform.localScale = new Vector3(-10f, 10f, 1f);
            }

        }

    }



    // Update is called once per frame
    //void Update()
    //{
        
    //}
}

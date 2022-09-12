using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class SpawnerScript : MonoBehaviour
{
    [SerializeField]
    public GameObject[] objects;

    public void SpawnRandom()
    {
        Instantiate(objects[UnityEngine.Random.Range(0, objects.Length - 1)]);
    }
}
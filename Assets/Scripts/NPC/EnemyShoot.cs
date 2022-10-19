using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    private Color color;
    private Vector3 firingPointDelta;

    private void Start()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        color = sprite.color;
        firingPointDelta = Vector3.up * transform.lossyScale.y / 2;
        StartCoroutine(SpawnFire());
    }

    IEnumerator SpawnFire()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2, 5));
            Shoot();
        }
    }

    void Shoot()
    {
        bulletPrefab.GetComponent<SpriteRenderer>().color = color;
        Instantiate(bulletPrefab, transform.position + firingPointDelta, Quaternion.Euler(new Vector3(0f, 0f, 0)));
    }

}

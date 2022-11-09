using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletPrefab;

    public int firingInterval = 3;
    public bool randomizeFiringInterval = true;
    public int minFiringInterval = 2;
    public int maxFiringInterval = 5;

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
            int interval = randomizeFiringInterval?
                Random.Range(minFiringInterval, maxFiringInterval) :
                firingInterval;
            yield return new WaitForSeconds(interval);
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position + firingPointDelta, Quaternion.identity);
        bullet.GetComponent<SpriteRenderer>().color = color;
    }

}

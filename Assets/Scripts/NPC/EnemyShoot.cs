using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletPrefab;

    public int firingInterval = 1;
    public bool randomizeFiringInterval = true;
    public int minFiringInterval = 0;
    public int maxFiringInterval = 1;

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
            float interval = randomizeFiringInterval ?
                (float)(Random.Range(minFiringInterval, maxFiringInterval)) :
                (float)(firingInterval);
            if (StaticScript.level == 6)
            {
                interval = 0.2f;
            }
            if (StaticScript.level == 7)
            {
                interval = 0.2f;
            }
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

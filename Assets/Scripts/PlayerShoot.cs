using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float fireRate = 0.2f;
    public Transform firingPoint;
    public GameObject bulletPrefab;
    public GameObject peelPrefab;

    float timeUntilFire;

    private void Start(){
    }
    
    private void Update(){
        if (Input.GetMouseButtonDown(0) && timeUntilFire < Time.time){
            Shoot();
            timeUntilFire = Time.time + fireRate;
        }
        if (Input.GetMouseButtonDown(1) && timeUntilFire < Time.time)
        {
            Peel();
            //timeUntilFire = Time.time + fireRate;
        }
    }

    void Shoot(){
        /*Vector3 mouseDelta = Input.mousePosition;
        float angle = Mathf.Atan2(mouseDelta.y, mouseDelta.x) * Mathf.Rad2Deg;
        if (angle < 0) angle += 360;*/
        Vector3 posBullet = new Vector3(0, 0, 0);
        posBullet = transform.position;
        //Debug.Log(posBullet);
        posBullet[0] += 1;
        // pos[1] -= 1;
        Instantiate(bulletPrefab,posBullet, Quaternion.Euler(new Vector3(0f,0f,0)));
    }
    void Peel()
    {
        //Debug.Log(transform.position);
        Vector3 pos = new Vector3(0,0,0);
        pos = transform.position;
        //Debug.Log(pos);
        pos[0] -= 2;
        pos[1] -= 1;
        Instantiate(peelPrefab, pos, Quaternion.Euler(new Vector3(10f, 10f, 0)));
    }
}



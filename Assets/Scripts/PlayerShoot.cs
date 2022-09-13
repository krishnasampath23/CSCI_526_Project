using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float fireRate = 0.2f;
    public Transform firingPoint;
    public GameObject bulletPrefab;

    float timeUntilFire;

    private void Start(){
    }
    
    private void Update(){
        if (Input.GetMouseButtonDown(0) && timeUntilFire < Time.time){
            Shoot();
            timeUntilFire = Time.time + fireRate;
        }
    }

    void Shoot(){
        Instantiate(bulletPrefab,transform.position, Quaternion.Euler(new Vector3(0f,0f,0)));
    }
}



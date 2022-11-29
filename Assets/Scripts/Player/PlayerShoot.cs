using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float fireRate = 0.2f;
    public GameObject bulletPrefab;
    public GameObject EraserPrefab;

    float timeUntilFire;

    private void Update(){
        /*if (Input.GetMouseButtonDown(0) && timeUntilFire < Time.time){
            Shoot();
            timeUntilFire = Time.time + fireRate;
        }
        if (Input.GetMouseButtonDown(1) && timeUntilFire < Time.time)
        {
            //Peel();
            //timeUntilFire = Time.time + fireRate;
        }*/
        if (Input.GetKeyDown(KeyCode.Space) && timeUntilFire < Time.time && StaticScript.no_of_poops > 0)
        {
            
            Shoot(GetComponent<SpriteRenderer>().color);
            StaticScript._poopsUsed+=1;
            timeUntilFire = Time.time + fireRate;
        }

        if (Input.GetKeyDown(KeyCode.X) && timeUntilFire < Time.time && StaticScript.no_of_erasers > 0)
        {    
            Shoot_eraser();
            timeUntilFire = Time.time + fireRate;
        }
    }

    void Shoot(Color x){
        /*Vector3 mouseDelta = Input.mousePosition;
        float angle = Mathf.Atan2(mouseDelta.y, mouseDelta.x) * Mathf.Rad2Deg;
        if (angle < 0) angle += 360;*/
        Vector3 posBullet = new Vector3(0, 0, 0);
        posBullet = transform.position;
        //Debug.Log(posBullet);
        //posBullet[0] += 1;
        posBullet[1] -= 1;
        // pos[1] -= 1
        StaticScript.no_of_poops -= 1;

        GameObject bullet = Instantiate(bulletPrefab, posBullet, Quaternion.identity);
        bullet.GetComponent<SpriteRenderer>().color = this.GetComponent<SpriteRenderer>().color;
    }

    void Shoot_eraser(){
        Vector3 posBullet = new Vector3(0, 0, 0);
        posBullet = transform.position;
        posBullet[1] -= 1;
        // pos[1] -= 1
        StaticScript.no_of_erasers -= 1; 
        Instantiate(EraserPrefab,posBullet, Quaternion.Euler(new Vector3(0f,0f,0)));
    }
}



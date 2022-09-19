using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFlyButton : MonoBehaviour
{
    private Vector3 direction;
    public float gravity = -9.8f;
    public float strength = 50f;

    private void Update(){
        if (Input.GetKeyDown(KeyCode.RightArrow)){
            direction = Vector3.up;
            direction = direction * strength;
        }

        if (Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began){
                direction = Vector3.up * strength;
            }
        }
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;       

        
    }


}

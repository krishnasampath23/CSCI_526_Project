using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonWalking : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    Vector2 back = new Vector2(0, 0); //assign it whatever value you want one edge of the movement to be
    Vector2 forth = new Vector2(100, 0); //again, assign whatever the other edge is supposed to be
    float phase = 0.5F;
    float speed = 0.2F; //adjust to anything that results in the speed u want
    float phaseDirection = 1; //this is just to make the code less "ify" =D

    void Update()
    {
        transform.position = Vector3.Lerp(back, forth, phase); //phase determines (in percent, basically) where on the line between the points "back" and "forth" you want the enemy to be placed, so if we gradually increase/decrease the variable, it makes the enemy move between those two points.
        phase += Time.deltaTime * speed * phaseDirection; //subtracts from 1 to zero when phaseDirection is negative, adds from zero to one when phaseDirection is positive.
        if (phase >= 1 || phase <= 0) phaseDirection *= -1; //flip the sign to flip direction
    }
}

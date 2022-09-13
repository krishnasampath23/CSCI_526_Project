using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public float Speed = 1f;

    private void Update()
    {
      transform.position += -transform.right* Time.deltaTime* Speed;
    }

private void OnCollisionEnter2D(Collision2D collision)
{
  Destroy(gameObject);
}

}

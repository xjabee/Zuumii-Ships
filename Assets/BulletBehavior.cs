using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D c)
    {
        if(c.transform.tag == "bordertop")
        {
            Destroy(gameObject);
        }
    }
}

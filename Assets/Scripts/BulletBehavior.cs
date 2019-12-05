using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    void Start()
    {
        Invoke("destroy", 4f);
    }
    private void OnCollisionEnter2D(Collision2D c)
    {
        if(c.transform.tag == "bordertop")
        {
            Destroy(gameObject);
        }
        if(c.transform.tag == "enemy")
        {
            Destroy(gameObject);
        }
    }
    void destroy()
    {
        Destroy(gameObject);
    }
}

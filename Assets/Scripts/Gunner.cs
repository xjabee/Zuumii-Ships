using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunner : MonoBehaviour
{
    public GameObject bullet;
    public float bulletSpeed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroy", 5f);
        InvokeRepeating("shoot", 0f, .15f);
    }

    void shoot()
    {
        GameObject bulletClone = Instantiate(bullet, transform.position, Quaternion.identity);
        Rigidbody2D rb = bulletClone.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.down * bulletSpeed, ForceMode2D.Impulse);
    }

    void destroy()
    {
        Destroy(gameObject);
    }
    
}

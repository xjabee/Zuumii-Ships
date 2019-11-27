using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    [Range(0.0f, 1f)]
    public float fireRate = 1f;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public Transform firePosition;
    bool allowfire = true;
    AudioSource bulletSound;
    bool playBulletSound;

    void Start()
    {
        bulletSound = GetComponent<AudioSource>();
        playBulletSound = true;
    }

    // Update is called once per frame
    void Update()
    {
        float hmovement = Input.GetAxis("Horizontal");
        float vmovement = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(hmovement, vmovement);
        transform.Translate(movement * moveSpeed * Time.deltaTime);
        
        if(Input.GetKey(KeyCode.Space) && (allowfire))
        {
            StartCoroutine(shootBullet());
        }


    }

    IEnumerator shootBullet()
    {
        allowfire = false;
        bulletSound.Play();
        GameObject bullet = Instantiate(bulletPrefab, firePosition.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * bulletSpeed, ForceMode2D.Impulse);
        Destroy(bullet, 3f);
        yield return new WaitForSeconds(fireRate);
        allowfire = true;
    }
}

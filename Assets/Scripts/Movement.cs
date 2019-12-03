using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    [Range(0.0f, 1f)]
    public int HP = 3;
    public float fireRate = 1f;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public Transform firePosition;
    bool allowfire = true;
    AudioSource bulletSound;
    private bool isDamaged;
    public float flashLength = .1f;
    private float flashCounter;
    private SpriteRenderer sr;
    void Start()
    {
        bulletSound = GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
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
        if (isDamaged)
        {
            if (flashCounter > flashLength * .66f)
            {
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0f);
            }
            else if (flashCounter > flashCounter * .33f)
            {
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
            }
            else if (flashCounter > 0f)
            {
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0f);
            }
            else
            {
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
                isDamaged = false;
            }
            flashCounter -= Time.deltaTime;

        }



    }

    IEnumerator shootBullet()
    {
        allowfire = false;
        bulletSound.Play();
        GameObject bullet = Instantiate(bulletPrefab, firePosition.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * bulletSpeed, ForceMode2D.Impulse);
        Destroy(bullet, 5f);
        yield return new WaitForSeconds(fireRate);
        allowfire = true;
    }


    private void OnCollisionEnter2D(Collision2D c)
    {
        if (HP > 1)
        {
            if (c.gameObject.tag == "enemy")
            {
                UIManager.Instance.HP[HP-1].SetActive(false);
                HP--;
                Destroy(c.gameObject);
                isDamaged = true;
                flashCounter = flashLength;
            }
            if (c.gameObject.tag == "boomer")
            {
                UIManager.Instance.HP[HP - 1].SetActive(false);
                HP--;
                Destroy(c.gameObject);
                isDamaged = true;
                flashCounter = flashLength;
            }
        }
        else
        {
            HP--;
            UIManager.Instance.HP[0].SetActive(false);
            Destroy(gameObject);
        }
    }
}

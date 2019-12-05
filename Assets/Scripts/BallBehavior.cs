using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public GameObject player;
    public int HP = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, .5f * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        if (HP > 1)
        {
            if(c.gameObject.tag == "bullet")
            {
                HP--;
                ScoreManager.Instance.Score++;
                Destroy(c.gameObject);

            }
            
        }
        else
        {
            Destroy(gameObject);
            Destroy(c.gameObject);
        }
    }
}

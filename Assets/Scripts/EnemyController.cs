using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Range (-0.1f, -5f)]
    public float moveSpeed;
    [Range (-1f, -5f)]
    public float turnRateRight;
    [Range (1f, 5f)]
    public float turnRateLeft;
    bool turn;
    public float move;
    public Animator animator;
    ScoreManager scoreManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(turn)
        {
            transform.Translate(new Vector2 (turnRateRight, moveSpeed) * Time.deltaTime);
        }
        else
        {
            transform.Translate(new Vector2(turnRateLeft, moveSpeed) * Time.deltaTime);

        }
    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.transform.tag == "bordersides")
        {
            if(turn)
            {
                turn = false;
            }
            else
            {
                turn = true;
            }
        }
        if (c.transform.tag == "boomer")
        {
            if (turn)
            {
                turn = false;
            }
            else
            {
                turn = true;
            }
        }
        if (c.transform.tag == "bullet")
        {
            animator.SetBool("gotHit", true);
            Destroy(c.gameObject);
            Destroy(gameObject, .5f);
            ScoreManager.Instance.Score++;
            Debug.Log("I got Hit!" + ScoreManager.Instance.Score);
        }
    }
    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.transform.tag == "bordersides")
        {
            if (turn)
            {
                turn = false;
            }
            else
            {
                turn = true;
            }
        }
        if (c.transform.tag == "bullet")
        {
            ScoreManager.Instance.Score++;
            Debug.Log("I got Hit!" + ScoreManager.Instance.Score);
            animator.SetBool("gotHit", true);
            Destroy(c.gameObject);
            Destroy(gameObject, .5f);
            

        }
    }

}

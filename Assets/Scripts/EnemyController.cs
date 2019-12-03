using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Range (-0.1f, -5f)]
    public float moveSpeed =-0.5f;
    [Range (-1f, -5f)]
    public float turnRateRight = -1f;
    [Range (1f, 5f)]
    public float turnRateLeft = -1f;
    bool turn;
    public float move;
    public Animator animator;
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
        if(transform.position.x < -4 || transform.position.x > 3)
        {
            Destroy(gameObject);
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
            GameManager.Instance.killCounter++;
           // Debug.Log("I got Hit!" + ScoreManager.Instance.Score);
        }
    }
}

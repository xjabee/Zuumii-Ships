using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBehavior : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector2(Random.Range(-1.76f, 1.75f), Random.Range(-1.9f, -3.7f));
        StartCoroutine(BubbleSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator BubbleSpawn()
    { 
        yield return new WaitForSeconds(10);
        animator.SetBool("breakBubble", true);
        yield return new WaitForSeconds(.33f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if(c.gameObject.tag == "enemy")
        {

            Destroy(c.gameObject);
        }
    }
}

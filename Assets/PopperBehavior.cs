using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PopperBehavior : MonoBehaviour
{
    [Range(-0.1f, -5f)]
    public float moveSpeed;
    [Range(-1f, -5f)]
    public float turnRateRight;
    [Range(1f, 5f)]
    public float turnRateLeft;
    public float move;
    public GameObject Popper;
    public float teleportRate = 2f;
    float initXpos;
    public Animator animator;
    bool didTeleport = true;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Teleport", 0, 5f); ;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Teleport()
    {
        StartCoroutine(teleport());
    }

    IEnumerator teleport()
    {
        yield return new WaitForSeconds(.33f);
        animator.SetBool("IsTeleportingIn", true);
        yield return new WaitForSeconds(2f);
        transform.position = new Vector2(Random.Range(-2.29f, 2.31f), transform.position.y - .5f);
        animator.SetBool("IsTeleportingOut", true);
        animator.SetBool("IsTeleportingIn", false);
        yield return new WaitForSeconds(.33f);
        animator.SetBool("IsTeleportingOut", false);

    }
    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.transform.tag == "bullet")
        {
            animator.SetBool("gotHit", true);
            Destroy(c.gameObject);
            Destroy(gameObject, .1f);
            ScoreManager.Instance.Score++;
            Debug.Log("I got Hit!" + ScoreManager.Instance.Score);
        }
    }
}

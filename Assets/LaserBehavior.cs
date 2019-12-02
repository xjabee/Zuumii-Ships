using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehavior : MonoBehaviour
{
    public GameObject laserAttack;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        LaserAttack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LaserAttack()
    {
        StartCoroutine(LaserBeamAttack());
    }

    IEnumerator LaserBeamAttack()
    {
        yield return new WaitForSeconds(1);
        animator.SetBool("fireLaser", true);
        yield return new WaitForSeconds(2);
        Instantiate(laserAttack, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

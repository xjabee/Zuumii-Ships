using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    [Header("Boss Attacks")]
    public GameObject Laser;
    public GameObject ball;
    public GameObject bubble;
    public GameObject gunners;
    public GameObject[] laserpos = new GameObject[4];
    public Animator animator;
    public GameObject player;
    [Header("Boss HP")]
    public int HP = 250;
    private bool isDamaged;
    public float flashLength = .1f;
    private float flashCounter;
    private SpriteRenderer sr;
    [Header("Boss Death")]
    public GameObject winScreen;
    public GameObject[] endButtons = new GameObject[2];
    public GameObject loseScreen;
    public GameObject finalScore;
    public GameObject endPanel;
    private static BossBehavior instance;
    public static BossBehavior Instance
    {
        get
        {
            return instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("attackController", 8f, 30f);
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(0.17f, 2.12f), 1f * Time.deltaTime);
        if(isDamaged)
        {
            if(flashCounter > flashLength * .66f)
            {
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0f);
            }
            else if(flashCounter > flashCounter * .33f)
            {
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
            }
            else if(flashCounter > 0f)
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

        StartCoroutine(bossDeath());

    }

    void attackController()
    {
        int pattern = Random.Range(1, 4);
        Debug.Log("Pattern: " + pattern);
        if (pattern == 1)
        {
            StartCoroutine(AttackPattern1());
        }
        else if (pattern == 2)
        {
            StartCoroutine(AttackPattern2());
        }
        else if (pattern == 3)
        {
            StartCoroutine(AttackPattern3());
        }
    }

    void laserAttack()
    {
        int laserpattern = Random.Range(1, 4);
        //bug.Log("Pattern: " + laserpattern);
        if(laserpattern == 1)
        {
            Instantiate(Laser, laserpos[1].transform.position, Quaternion.identity);
            Instantiate(Laser, laserpos[2].transform.position, Quaternion.identity);
            Instantiate(Laser, laserpos[3].transform.position, Quaternion.identity);
        }
        if (laserpattern == 2)
        {
            Instantiate(Laser, laserpos[0].transform.position, Quaternion.identity);
            Instantiate(Laser, laserpos[2].transform.position, Quaternion.identity);
            Instantiate(Laser, laserpos[3].transform.position, Quaternion.identity);
        }
        if (laserpattern == 3)
        {
            Instantiate(Laser, laserpos[0].transform.position, Quaternion.identity);
            Instantiate(Laser, laserpos[1].transform.position, Quaternion.identity);
            Instantiate(Laser, laserpos[3].transform.position, Quaternion.identity);
        }
        if (laserpattern == 4)
        {
            Instantiate(Laser, laserpos[0].transform.position, Quaternion.identity);
            Instantiate(Laser, laserpos[1].transform.position, Quaternion.identity);
            Instantiate(Laser, laserpos[2].transform.position, Quaternion.identity);
        }
    }
    void ballAttack()
    {
        GameObject ballInstance = Instantiate(ball, transform.position, Quaternion.identity) as GameObject;
        ballInstance.GetComponent<BallBehavior>().player = player;
    }
    void bulletAttack()
    {

        Instantiate(bubble, transform.position, Quaternion.identity);
        Instantiate(gunners, gunners.transform.position, Quaternion.identity);

    }

    IEnumerator AttackPattern1()
    {
        laserAttack();
        yield return new WaitForSeconds(8f);
        ballAttack();
        yield return new WaitForSeconds(8f);
        bulletAttack();
        yield return new WaitForSeconds(8f);

    }
    IEnumerator AttackPattern2()
    {
        bulletAttack();
        yield return new WaitForSeconds(8f);
        ballAttack();
        yield return new WaitForSeconds(8f);
        laserAttack();
        yield return new WaitForSeconds(8f);

    }
    IEnumerator AttackPattern3()
    {
        ballAttack();
        yield return new WaitForSeconds(8f);
        bulletAttack();
        yield return new WaitForSeconds(8f);
        laserAttack();
        yield return new WaitForSeconds(8f);

    }
    IEnumerator AttackPattern4()
    {
        laserAttack();
        yield return new WaitForSeconds(8f);
        laserAttack();
        yield return new WaitForSeconds(8f);
        laserAttack();
        yield return new WaitForSeconds(8f);

    }

    IEnumerator bossDeath()
    {
        yield return new WaitForSeconds(5f);
        if(Movement.Instance.HP == 0)
        {
            endPanel.SetActive(true);
            endButtons[0].SetActive(true);
            endButtons[1].SetActive(true);
            loseScreen.SetActive(true);
            finalScore.SetActive(true);
        }
        else if (HP == 0)
        {
            endPanel.SetActive(true);
            endButtons[0].SetActive(true);
            endButtons[1].SetActive(true);
            winScreen.SetActive(true);
            finalScore.SetActive(true);
        }

    }



    private void OnCollisionEnter2D(Collision2D c)
    {
        if (HP > 1)
        {
            if (c.gameObject.tag == "bullet")
            {
                HP--;
                Destroy(c.gameObject);
                isDamaged = true;
                flashCounter = flashLength;
                ScoreManager.Instance.Score++;
            }
            
        }
        else
        {
            Destroy(gameObject);
            Destroy(c.gameObject);
        }
    }


}

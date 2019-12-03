using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpanwer : MonoBehaviour
{
    public GameObject boomer;
    public GameObject boss;
    public GameObject blinker;
    public GameObject[] laserpos = new GameObject[4];
    public ScoreManager scoreManager;
    public GameManager gameManager;
    private int SpawnCounter = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnWave());
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(scoreManager.Score);
        Debug.Log(ScoreManager.Instance.Score);
        if(gameManager.killCounter > 75)
        {
            gameManager.GetComponent<AudioSource>().Stop();
            bossSpawn();
        }
    }
    
    IEnumerator spawnOrder()
    {
        InvokeRepeating("boomerSpawn", 1f, 3f);
        yield return new WaitForSeconds(12f);
        CancelInvoke("boomerSpawn");
        InvokeRepeating("blinkerSpawn", 1f, 2f);
        yield return new WaitForSeconds(12f);
        CancelInvoke("blinkerSpawn");
        InvokeRepeating("boomerSpawn", 1f, 3f);
        yield return new WaitForSeconds(12f);
        CancelInvoke("boomerSpawn");
        InvokeRepeating("blinkerSpawn", 1f, 2f);
        yield return new WaitForSeconds(12f);
        CancelInvoke("blinkerSpawn");
        yield return new WaitForSeconds(12f);
        gameManager.GetComponent<AudioSource>().Stop();
        bossSpawn();
        yield return new WaitForSeconds(10f);
    }

    IEnumerator spawnWave()
    {
        while(gameManager.killCounter < 75)
        {
            for (int x = 0; x < 5; x++)
            {
                boomerSpawn();
                yield return new WaitForSeconds(5f);
            }
            for (int x = 0; x < 5; x++)
            {
                blinkerSpawn();
                yield return new WaitForSeconds(1f);
            }
        }
    }





    void boomerSpawn()
    {
        GameObject boomerSpawned = Instantiate(boomer, new Vector2(Random.Range(-2f, 1.75f), 6.48f), Quaternion.identity);
        Destroy(boomerSpawned, 10f);
    }
    void blinkerSpawn()
    {
        Instantiate(blinker, new Vector2(Random.Range(-2f, 2.31f), 4.48f), Quaternion.identity);
    }
    void bossSpawn()
    {
        boss.SetActive(true);
    }
}

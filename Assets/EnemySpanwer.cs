using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpanwer : MonoBehaviour
{
    public GameObject boomer;
    public GameObject boss;
    public GameObject blinker;
    public GameObject[] laserpos = new GameObject[4];
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnOrder());
    }

    // Update is called once per frame
    void Update()
    {
        
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
        bossSpawn();
        yield return new WaitForSeconds(10f);
    }

    void boomerSpawn()
    {
        Instantiate(boomer, new Vector2(Random.Range(-2f, 1.75f), 6.48f), Quaternion.identity);
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

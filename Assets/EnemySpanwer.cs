using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpanwer : MonoBehaviour
{
    public GameObject boomer;
    private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnEnemy", 2f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void spawnEnemy()
    {
        Instantiate(boomer, new Vector2(Random.Range(-2f, 2.5f), transform.position.y), Quaternion.identity);
        counter++;
    }
}

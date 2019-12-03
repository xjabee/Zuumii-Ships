using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Movement player;
    public ScoreManager scoreManager;
    public UIManager uIManager;
    public EnemySpanwer enemySpawner;
    public int killCounter = 0;
    private static GameManager instance;

    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }
    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        if(c.transform.tag == "boomer")
        {
            Destroy(c.gameObject);
            UIManager.Instance.HP[player.HP - 1].SetActive(false);
            player.HP--;
        }
    }
}

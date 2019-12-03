using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Movement player;
    public BossBehavior enemy;
    public TextMeshProUGUI ScoreBox;
    public GameObject[] HP;
    ScoreManager scoreManager;
    public TextMeshProUGUI finalScore;
    public bool win = false;
    [Header("Boss Death")]
    public GameObject winScreen;
    public GameObject loseScreen;
    private static UIManager instance;

    public static UIManager Instance
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
       // ScoreBox.text = "Score - " + 0;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreBox.text = "Score - " + ScoreManager.Instance.Score * 10;
        finalScore.text = "Final Score - " + ScoreManager.Instance.Score * 10;
        StartCoroutine(bossDeath());
    }
    IEnumerator bossDeath()
    {
        Debug.Log("Boss HP: " + enemy.HP);
        Debug.Log("Player HP: " + player.HP);
        if (player.HP <= 0)
        {
            yield return new WaitForSeconds(2f);
            winScreen.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("u ded bish");
        }
        if (enemy.HP <= 0)
        {
            yield return new WaitForSeconds(2f);
            loseScreen.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("u ded bish");
        }

    }
}

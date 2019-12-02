using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreBox;
    public GameObject[] HP;
    ScoreManager scoreManager;
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
    }
}

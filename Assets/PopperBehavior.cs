using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopperBehavior : MonoBehaviour
{
    [Range(-0.1f, -5f)]
    public float moveSpeed;
    [Range(-1f, -5f)]
    public float turnRateRight;
    [Range(1f, 5f)]
    public float turnRateLeft;
    bool turn;
    public float move;
    public GameObject Popper;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawn()
    {
        transform.Translate()
    }
}

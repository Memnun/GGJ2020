using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConstants : MonoBehaviour
{

    public int Cash = 100;
    public int Swings = 0;
    public List<GameObject> Furniture = new List<GameObject>();
    public List<int> Upgrades = new List<int>();
    public Vector2 shadowOffset = new Vector2(0.1f, -0.1f);
    public float launchStrength = 500f;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

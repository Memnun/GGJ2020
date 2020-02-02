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
    public List<GameObject> ammotypes = new List<GameObject>();
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
        if (Upgrades.Contains(1) &&
            GetComponent<CameraController>().followTarget != GetComponent<CameraController>().defaultTarget &&
            Input.GetKeyDown("space"))
        {
            GetComponent<CameraController>().followTarget.GetComponent<Rigidbody2D>().isKinematic = true;
        }
            
    }
    
}

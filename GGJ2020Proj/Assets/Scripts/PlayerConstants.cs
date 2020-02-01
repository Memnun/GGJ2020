using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConstants : MonoBehaviour
{

    public int Cash;
    public int Swings;
    public List<int> Furniture;
    public List<int> Upgrades;
    public Vector2 shadowOffset;
    public float launchStrength;
    
    // Start is called before the first frame update
    void Start()
    {
        Cash = 100;
        Swings = 0;
        Furniture = new List<int>();
        Upgrades = new List<int>();
        shadowOffset = new Vector2(0.1f, -0.1f);
        launchStrength = 500f;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

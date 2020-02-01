using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConstants
{

    public int Cash;
    public int Swings;
    public List<int> Furniture;
    public List<int> Upgrades;
    
    // Start is called before the first frame update
    void Start()
    {
        Cash = 100;
        Swings = 0;
        Furniture = new List<int>();
        Upgrades = new List<int>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

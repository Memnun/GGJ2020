using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviors : MonoBehaviour
{
    
    private PlayerConstants player;

    void Start()
    {
        player = Camera.main.GetComponent<PlayerConstants>();
    }

    public void buyFreeze()
    {
        if (player.Cash >= 1000 && !player.Upgrades.Contains(1))
        {
            player.Cash -= 1000;
            player.Upgrades.Add(1);
        }
    }

    public void buyRandomFurniture()
    {
        if (player.Cash >= 50)
        {
            player.Cash -= 50;
            player.Furniture.Add(player.ammotypes[Random.Range(0, player.ammotypes.Count-1)]);
        }
    }

    public void buySpecificFurniture(int furnitureType)
    {
        if (player.Cash >= 100)
        {
            player.Cash -= 100;
            player.Furniture.Add(player.ammotypes[furnitureType]);
        }
    }
    
}

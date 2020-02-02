using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class ButtonBehaviors : MonoBehaviour
{
    
    private PlayerConstants player;
    private GameObject cashout;

    void Start()
    {
        player = Camera.main.GetComponent<PlayerConstants>();
        cashout = GameObject.Find("cashReadout");
    }

    private void Update()
    {
        cashout.GetComponent<TextMeshProUGUI>().text = "Wallet: " + player.Cash + " cash";
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

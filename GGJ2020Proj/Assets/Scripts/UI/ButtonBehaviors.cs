using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        cashout.GetComponent<TextMeshProUGUI>().text = player.Cash+"";
    }

    public void buyFreeze()
    {
        if (player.Cash >= 1000)
        {
            player.Cash -= 1000;
            player.Upgrades.Add(1);
        }
    }

    public void buyPower()
    {
        if (player.Cash >= 500)
        {
            player.Cash -= 500;
            player.Upgrades.Add(2);
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

    public void returnToLevel()
    {
        switch (player.currentLevel)
        {
            case 1:
                SceneManager.LoadScene("LVLTwo_Rooms", LoadSceneMode.Single);
                Camera.main.GetComponent<GlobalSounds>().MusicIntensity = 0;
                break;
            case 2:
                SceneManager.LoadScene("LVLFour_Rooms", LoadSceneMode.Single);
                Camera.main.GetComponent<GlobalSounds>().MusicIntensity = 0;
                break;
            default:
                Application.Quit(94537);
                break;
        }
    }
    
}

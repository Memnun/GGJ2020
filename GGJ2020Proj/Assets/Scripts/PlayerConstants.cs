using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerConstants : MonoBehaviour
{

    public int Cash = 100;
    public int Swings = 0;
    public List<GameObject> Furniture = new List<GameObject>();
    public List<int> Upgrades = new List<int>();
    public List<GameObject> ammotypes = new List<GameObject>();
    public Vector2 shadowOffset = new Vector2(0.1f, -0.1f);
    public float launchStrength = 500f;

    public int currentLevel;
    
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Upgrades.Contains(1) &&
            GetComponent<CameraController>().followTarget != GetComponent<CameraController>().defaultTarget &&
            Input.GetKeyDown("space"))
        {
            GetComponent<CameraController>().followTarget.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        }

        if (SceneManager.GetActiveScene().name != "ShopMenu" && Furniture.Count <= 0 && GetComponent<CameraController>().followTarget == GetComponent<CameraController>().defaultTarget)
        {
            currentLevel = checkForWin();
            GetComponent<GlobalSounds>().MusicIntensity = 2;
            SceneManager.LoadScene("ShopMenu");
        }
            
    }

    private int checkForWin()
    {
        int holes = 0;
        int accuracy = 0;
        foreach (GameObject collider in GameObject.FindGameObjectsWithTag("hole"))
        {
            holes += 100;
            accuracy += collider.GetComponent<OverlapMeasure>().overlapCount;
        }

        Cash += accuracy * 5;
        Cash += 50;

        if ((float) holes / (float) accuracy < 2)
        {
            return currentLevel + 1;
        }

        return currentLevel;
    }
    
}

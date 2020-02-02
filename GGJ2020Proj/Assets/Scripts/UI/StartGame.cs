using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Begin()
    {
        SceneManager.LoadScene("LVLTwo_Rooms", LoadSceneMode.Single);
    }

    public void EndGame()
    {
        Application.Quit();
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject followTarget;
    public BoxCollider2D cameraBounds;


    void Awake()
    {
        transform.position = followTarget.transform.position + new Vector3(0, 0, -100f);
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

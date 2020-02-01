using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject followTarget;
    public BoxCollider2D cameraBounds;
    private GameObject defaultTarget;
    public bool isFollowing;
    private bool isFollowingFrameBuff;
    private float launchtime;
    
    void Awake()
    {
        transform.position = followTarget.transform.position + new Vector3(0, 0, -100f);
    }
    // Start is called before the first frame update
    void Start()
    {
        defaultTarget = followTarget;
        isFollowing = false;
        isFollowingFrameBuff = false;
        launchtime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //////////// CAMERA TRACKING //////////////
        if (followTarget.transform.position.x < -90f)
        {
            transform.position = new Vector3(-90f, transform.position.y, -10f);
        } else if (followTarget.transform.position.x > 90f)
        {
            transform.position = new Vector3(90f, transform.position.y, -10f);
        }
        else
        {
            transform.position = new Vector3(followTarget.transform.position.x, transform.position.y, -10f);
        }

        if (followTarget.transform.position.y < 15f)
        {
            transform.position = new Vector3(transform.position.x, 15f, -10f);
        } else if (followTarget.transform.position.y > 85f)
        {
            transform.position = new Vector3(transform.position.x, 85f, -10f);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, followTarget.transform.position.y, -10f);
        }
        
        ///////////////// TARGET SWITCHING ///////////////////
        if (isFollowing && !isFollowingFrameBuff)
        {
            launchtime = Time.time;
            isFollowingFrameBuff = isFollowing;
        }
        
    }
}

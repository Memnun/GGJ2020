using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject followTarget;
    public Vector4 bounds;
    private GameObject defaultTarget;
    private bool framedelay;
    void Awake()
    {
        transform.position = followTarget.transform.position + new Vector3(0, 0, -100f);
    }
    // Start is called before the first frame update
    void Start()
    {
        defaultTarget = followTarget;
        framedelay = false;
    }

    // Update is called once per frame
    void Update()
    {
        //////////// CAMERA TRACKING //////////////
        if (followTarget.transform.position.x < bounds.x)
        {
            transform.position = new Vector3(bounds.x, transform.position.y, -10f);
        } else if (followTarget.transform.position.x > bounds.y)
        {
            transform.position = new Vector3(bounds.y, transform.position.y, -10f);
        }
        else
        {
            transform.position = new Vector3(followTarget.transform.position.x, transform.position.y, -10f);
        }

        if (followTarget.transform.position.y < bounds.z)
        {
            transform.position = new Vector3(transform.position.x, bounds.z, -10f);
        } else if (followTarget.transform.position.y > bounds.w)
        {
            transform.position = new Vector3(transform.position.x, bounds.w, -10f);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, followTarget.transform.position.y, -10f);
        }
        
        ///////////////// TARGET SWITCHING ///////////////////
        if (followTarget != defaultTarget)
        {
            if (framedelay == false)
            {
                framedelay = true;
            }
            else
            {
                if (followTarget.GetComponent<Rigidbody2D>().velocity.magnitude < 0.05f)
                {
                    followTarget = defaultTarget;
                    framedelay = false;
                }
            }
        }
        
    }
}

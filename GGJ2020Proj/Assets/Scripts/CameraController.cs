using System.Collections;
using System.Collections.Generic;
using TMPro;
using FMODUnity;
using FMOD.Studio;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject followTarget;
    public Vector4 bounds;
    public GameObject defaultTarget;
    private int framedelay;
    void Awake()
    {
        transform.position = followTarget.transform.position + new Vector3(0, 0, -100f);
    }
    // Start is called before the first frame update
    void Start()
    {
        defaultTarget = followTarget;
        framedelay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (followTarget == null)
        {
            GameObject x = GameObject.Find("CannonWheel");
            if (x != null)
            {
                followTarget = x;
            }
        }
        if (defaultTarget == null)
        {
            GameObject x = GameObject.Find("CannonWheel");
            if (x != null)
            {
                defaultTarget = x;
            }
        }
        //////////// CAMERA TRACKING //////////////
            if (followTarget.transform.position.x < bounds.x)
            {
                transform.position = new Vector3(bounds.x, transform.position.y, -10f);
            }
            else if (followTarget.transform.position.x > bounds.y)
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
            }
            else if (followTarget.transform.position.y > bounds.w)
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
            if (framedelay < 60)
            {
                framedelay++;
            }
            else
            {
                if (followTarget.GetComponent<Rigidbody2D>().velocity.magnitude < 0.05f)
                {
                    followTarget = defaultTarget;
                    framedelay = 0;
                    GameObject.Find("CannonBody").GetComponent<LevelSound>().reloaded = true;
                    GetComponent<GlobalSounds>().MusicIntensity = 0;
                }
            }
        }

        if (GameObject.Find("CannonBody") != null)
        {
            GameObject.Find("CannonBody").GetComponent<LevelSound>().ambienceWoosh
                .setParameterByName("LevelPosition",
                    followTarget.GetComponent<Rigidbody2D>().velocity.magnitude * 1.0f);
        }

        if (GameObject.Find("level1"))
        {
            bounds = new Vector4(-251, 29, -14, 30);
            Destroy(GameObject.Find("level1"));
        }

        if (GameObject.Find("level2"))
        {
            bounds = new Vector4(-210, 31, 8, 20);
            Destroy(GameObject.Find("level2"));
        }

    }
}

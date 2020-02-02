using System;
using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class Impact : MonoBehaviour
{

    public int weightval;
    private float Map(float s, float lo1, float hi1, float lo2, float hi2)
    {
        return lo2 + (s-lo1)*(hi2-lo2)/(hi1-lo1);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        GetComponent<StudioEventEmitter>().SetParameter("ImpactSpeed", Map(GetComponent<Rigidbody2D>().velocity.magnitude, 1, 10, 0, 1));
        GetComponent<StudioEventEmitter>().SetParameter("Weight", weightval);
        GetComponent<StudioEventEmitter>().Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using FMOD;
using UnityEditor;
using UnityEngine;

public class OverlapMeasure : MonoBehaviour
{

    public List<Vector2> raypoints;
    public SpriteRenderer b;
    public Collider2D c;
    public int overlapCount;
    
    // Start is called before the first frame update
    void Start()
    {
        raypoints = new List<Vector2>();
        while (raypoints.Count < 100)
        {
            Vector3 bmin = b.sprite.bounds.min;
            Vector3 bmax = b.sprite.bounds.max;
            Vector3 randomPoint = transform.TransformPoint(new Vector3(Random.Range(bmin.x,bmax.x), Random.Range(bmin.y,bmax.y), 0));
            raypoints.Add(new Vector2(randomPoint.x, randomPoint.y));
            if (Physics2D.OverlapPoint(raypoints[raypoints.Count - 1]) != c)
            {
                raypoints.Remove(raypoints[raypoints.Count - 1]);
            }
        }

        c.enabled = !c.enabled;
    }

    // Update is called once per frame
    void Update()
    {
        overlapCount = 0;
        for (int i = 0; i < raypoints.Count; i++)
        {
            if (Physics2D.OverlapPoint(raypoints[i]) != null)
            {
                overlapCount++;
            }
        }
    }
}

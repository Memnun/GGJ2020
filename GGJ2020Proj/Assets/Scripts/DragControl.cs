﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragControl : MonoBehaviour
{
    private Vector2 startPos;
    private GameObject reticle;
    private float cannonOffset;
    public Sprite reticleSprite;

    public void Start()
    {
        cannonOffset = 15f;
    }
    
    public void OnMouseDown()
    {
        startPos = transform.position;
        reticle = new GameObject("reticle");
        reticle.AddComponent<SpriteRenderer>();
        reticle.GetComponent<SpriteRenderer>().sprite = reticleSprite;
        
        reticle.GetComponent<SpriteRenderer>().sortingLayerName = GetComponent<SpriteRenderer>().sortingLayerName;
        reticle.GetComponent<SpriteRenderer>().sortingOrder = GetComponent<SpriteRenderer>().sortingOrder - 1;
        
        
    }

    public void OnMouseDrag()
    {
        Vector2 p= Camera.main.ScreenToWorldPoint(Input.mousePosition);

        List<int> k = Camera.main.GetComponent<PlayerConstants>().Upgrades;
        int j = 0;
        foreach (int i in k)
        {
            if (i == 2) j++;
        }
        
        float radius = 5.0f + (j*0.5f);
        Vector2 dir = p - startPos;
        if (dir.magnitude > radius)
            dir = dir.normalized * radius;
        
        reticle.transform.position = startPos + dir;
        transform.eulerAngles = new Vector3(0, 0, Vector2.SignedAngle(Vector2.right, dir.normalized)-cannonOffset);
    }

    public void OnMouseUp()
    {
        if (Camera.main.GetComponent<PlayerConstants>().Furniture.Count > 0)
        {
            GetComponent<ParticleSystem>().Play();
            Vector2 dir = (Vector2) reticle.transform.position - startPos;
            GameObject ammo = Instantiate(Camera.main.GetComponent<PlayerConstants>().Furniture[0], transform.TransformPoint(new Vector3(6, 3, 0)),
                Quaternion.identity);
            ammo.GetComponent<Rigidbody2D>().AddForce(Camera.main.GetComponent<PlayerConstants>().launchStrength * dir);
            ammo.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-150f, 150f));
            Camera.main.GetComponent<CameraController>().followTarget = ammo;
            Camera.main.GetComponent<PlayerConstants>().Furniture.RemoveAt(0);
            GetComponent<LevelSound>().fired = true;
            Camera.main.GetComponent<GlobalSounds>().MusicIntensity = 1;
        }
        Destroy(reticle);
    }
}

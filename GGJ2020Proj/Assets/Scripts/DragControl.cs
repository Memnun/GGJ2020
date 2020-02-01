using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragControl : MonoBehaviour
{
    private Vector2 startPos;
    private GameObject reticle;
    public Sprite reticleSprite;
    
    public void OnMouseDown()
    {
        startPos = transform.position;
        reticle = new GameObject("reticle");
        reticle.AddComponent<SpriteRenderer>();
        reticle.GetComponent<SpriteRenderer>().sprite = reticleSprite;
        
        GetComponent<SpriteRenderer>().sortingLayerName = reticle.GetComponent<SpriteRenderer>().sortingLayerName;
        GetComponent<SpriteRenderer>().sortingOrder = reticle.GetComponent<SpriteRenderer>().sortingOrder - 1;
        
        
    }

    public void OnMouseDrag()
    {
        Vector2 p= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        float radius = 3.6f;
        Vector2 dir = p - startPos;
        if (dir.magnitude > radius)
            dir = dir.normalized * radius;
        
        reticle.transform.position = startPos + dir;
    }

    public void OnMouseUp()
    {
        Vector2 dir = (Vector2) reticle.transform.position - startPos;
        GetComponent<Rigidbody2D>().AddForce(Camera.main.GetComponent<PlayerConstants>().launchStrength * dir);
        GetComponent<Rigidbody2D>().AddTorque(Random.Range(-150f, 150f));
        Destroy(reticle);
        //Destroy(this);
    }
}

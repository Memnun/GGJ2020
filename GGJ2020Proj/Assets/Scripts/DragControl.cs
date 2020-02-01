using System.Collections;
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
        
        float radius = 3.6f;
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
            Vector2 dir = (Vector2) reticle.transform.position - startPos;
            GameObject ammo = Instantiate(Camera.main.GetComponent<PlayerConstants>().Furniture[0], transform.position,
                Quaternion.identity);
            ammo.GetComponent<Rigidbody2D>().AddForce(Camera.main.GetComponent<PlayerConstants>().launchStrength * dir);
            ammo.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-150f, 150f));
            Camera.main.GetComponent<PlayerConstants>().Furniture.RemoveAt(0);
        }
        Destroy(reticle);
    }
}

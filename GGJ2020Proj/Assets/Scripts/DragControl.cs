using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragControl : MonoBehaviour
{
    private Vector2 startPos;
    
    public void OnMouseDown()
    {
        startPos = transform.position;
    }

    public void OnMouseDrag()
    {
        Vector2 p= Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Keep it in a certain radius
        float radius = 3.6f;
        Vector2 dir = p - startPos;
        if (dir.magnitude > radius)
            dir = dir.normalized * radius;

        // Set the Position
        transform.position = startPos + dir;
    }

    public void OnMouseUp()
    {
        Vector2 dir = (Vector2) transform.position - startPos;
        GetComponent<Rigidbody2D>().AddForce(Camera.main.GetComponent<PlayerConstants>().launchStrength * dir);
    }
}

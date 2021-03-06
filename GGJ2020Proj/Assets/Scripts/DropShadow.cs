﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropShadow : MonoBehaviour
{

    public Material ShadowMaterial;
    public SpriteRenderer Silhouette;
    private GameObject shadowSprite;
    
    void Start()
    {
        shadowSprite = new GameObject("shadow");
        SpriteRenderer shadowSpriteRenderer = shadowSprite.AddComponent<SpriteRenderer>();
        shadowSpriteRenderer.sprite = Silhouette.sprite;
        shadowSpriteRenderer.material = ShadowMaterial;
        
        shadowSpriteRenderer.sortingLayerName = Silhouette.sortingLayerName;
        shadowSpriteRenderer.sortingOrder = Silhouette.sortingOrder - 1;
        
    }
    
    void LateUpdate()
    {
        shadowSprite.transform.localPosition = transform.localPosition + (Vector3)Camera.main.GetComponent<PlayerConstants>().shadowOffset;
        shadowSprite.transform.localRotation = transform.localRotation;
    }
}

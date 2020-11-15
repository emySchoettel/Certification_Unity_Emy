using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    protected GameSceneController gameSceneController; 
    protected float halfWidth; 
    protected float haldHeight; 
    private SpriteRenderer SpriteRenderer;
    public string Name;

    void Start()
    {
        gameSceneController = FindObjectOfType<GameSceneController>(); 
        SpriteRenderer = GetComponent<SpriteRenderer>();
        halfWidth = SpriteRenderer.bounds.extents.x; 
        haldHeight = SpriteRenderer.bounds.extents.y;
        SetColor(Color.yellow); 
    }

    public void SetColor(Color newColor)
    {
        SpriteRenderer spriteRenderer =  GetComponent<SpriteRenderer>();
        spriteRenderer.color = newColor;
    }
}

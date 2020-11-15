using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : Shape
{
    public Vector2 projectileDirection;
    public float projectileSpeed; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject != null)
        {
            MoveProjectile();
        }
        
    }

    private void MoveProjectile()
    {
        transform.Translate(projectileDirection * Time.deltaTime * projectileSpeed, Space.World);

        float top = transform.position.y + haldHeight;
        if(top >= gameSceneController.screenBounds.y)
        {
            Destroy(gameObject);
        }
    }
}

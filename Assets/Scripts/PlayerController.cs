using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Shape
{
 public ProjectileController projectileController; 
    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        if(Input.GetKeyDown(KeyCode.Space))
        {
            FireProjectile(); 
        }
    }

    private void MovePlayer()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");

        if(Mathf.Abs(horizontalMovement) > Mathf.Epsilon)
        {
            horizontalMovement = horizontalMovement * Time.deltaTime * gameSceneController.playerSpeed; 
            horizontalMovement += transform.position.x; 

            float right = gameSceneController.screenBounds.x - halfWidth;
            float left = -right; 

            float limit = 
            Mathf.Clamp(horizontalMovement, left, right);

            transform.position = new Vector2(limit, transform.position.y); 
        }
    }

    private void FireProjectile()
    {
        Vector2 spawnPosition = transform.position; 

        ProjectileController projectile = Instantiate(projectileController, spawnPosition, Quaternion.identity);

        projectile.projectileSpeed = 2;
        projectile.projectileDirection = Vector2.up; 

    }
}

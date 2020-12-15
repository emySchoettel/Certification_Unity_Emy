using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Shape
{
 public ProjectileController projectileController;
 private PlayerController playerController; 
    // Update is called once per frame

    protected override void Start()
    {
        base.Start();
        playerController = FindObjectOfType<PlayerController>();
    }


    void Update()
    {
        MovePlayer();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            FireProjectile(); 
            playerController.SetColor(Color.red);
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            playerController.SetColor(Color.yellow);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void TextOutputHandler(string text); 
public class GameSceneController : MonoBehaviour
{
    public float playerSpeed; 
    public Vector3 screenBounds; 
    public EnemyController enemy; 

    private HubControl hud;
    private int totalPoints; 
    // Start is called before the first frame update
    void Start()
    {
        hud = FindObjectOfType<HubControl>();
        playerSpeed = 10; 
        screenBounds = GetScreenBounds(); 
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnEnemies()
    {
        WaitForSeconds wait = new WaitForSeconds(2);
        while(true)
        {
            float horizontalPosition = Random.Range(-screenBounds.x, screenBounds.x);
            Vector2 spawnPosition = new Vector2(horizontalPosition, screenBounds.y);

            EnemyController enemyC = Instantiate(enemy, spawnPosition, Quaternion.identity);

            enemyC.EnemyEscaped += EnemyAtBottom;
            enemyC.EnnemyKilled += EnemyKilled; 
            yield return wait; 
        }
    }

    void EnemyKilled(int pointValue)
    {
        totalPoints += pointValue; 
        hud.scoreText.text = totalPoints.ToString();
    }

    private Vector3 GetScreenBounds()
    {
        Camera mainCamera = Camera.main; 
        Vector3 screenVector = new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z);

        return mainCamera.ScreenToWorldPoint(screenVector);
    }

    public void KillObject(IKillable killable)
    {
        killable.Kill();
    }

    public void OutputText(string output)
    {
        Debug.LogFormat("{0} output by GM", output);
    }

    private void EnemyAtBottom(EnemyController enemy)
    {
        Destroy(enemy.gameObject);
        Debug.Log("Enemy Escaped");
    }
}
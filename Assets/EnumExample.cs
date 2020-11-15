using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumExample : MonoBehaviour
{

    private GameState gameState; 
    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.Running; 
    }

    // Update is called once per frame
    void Update()
    {
        switch(gameState)
        {
            case GameState.Running: 
                print("Le jeu est en cours"); 
            break; 

            case GameState.Paused:
                print("Le jeu est en pause");
            break; 

            case GameState.Ended:
                print("Le jeu est terminé");
            break; 
        }
    }
}

public enum GameState { Running, Paused, Ended }

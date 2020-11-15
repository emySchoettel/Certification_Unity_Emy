using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using UnityEngine;
namespace BeyondTheBasics.Gameplay{
public class SampleScript : UnityEngine.MonoBehaviour
{
    public int numberToDisplay;
    public int numberToMultiplyBy; 
    private void SayHelloWorld()
    {
        var randomNumber = UnityEngine.Random.Range(0, numberToDisplay);
        var displayText = "Hello World"; 
        for(int i = 0; i < randomNumber; i++)
        {
            print(displayText);
        }
    }

    private void AnonymousTypeExample()
    {
        //var enemy = new { name = "Monstrer", hitpoints = 100};

        var enemies = new[] {
            new { name = "Monster", hitPoints = 100},
            new { name = "Goblin", hitPoints = 200},
            new { name = "Beast", hitPoints = 300}
        };

        var enemiesQuery = 
            from enemy in enemies
            orderby enemy.name
            select enemy; 

        foreach(var enemy in enemiesQuery)
        {
            print(enemy.name);
        }

    }

    private void MultiplyNumber(int numberToMultiply)
    {
        #region essai
        int product = numberToMultiplyBy * numberToMultiply; 
        print(product);
        #endregion
    }
    // Start is called before the first frame update
   private void Start()
    {
        AnonymousTypeExample();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{

    public string nameOne = "circle"; 
    public string nameTwo = "square";
    public string nameThree = "triangle"; 
    public string nameFour = "octagon"; 

    public string[] shapes = { "circle", "square", "triangle", "octagon"}; 
    // Start is called before the first frame update
    void Start()
    {

        for(int i = 0; i < shapes.Length; i++)
        {
            shapes[i] = shapes[i].ToUpper(); 
            print(shapes[i]);
        }
        
        // nameOne = nameOne.ToUpper(); 
        // nameTwo = nameTwo.ToUpper(); 
        // nameThree = nameThree.ToUpper(); 
        // nameFour = nameFour.ToUpper(); 

        // print(nameOne);
        // print(nameTwo);
        // print(nameThree);
        // print(nameFour);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

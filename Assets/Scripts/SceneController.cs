using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{

    public List<Shape> gameShapes; 
    public Dictionary<string, Shape> shapeDictionnary; 
    // Start is called before the first frame update
    void Start()
    {
        shapeDictionnary = new Dictionary<string, Shape>(); 
        foreach(Shape shape in gameShapes)
        {
            shapeDictionnary.Add(shape.Name, shape);
        }
    }

    private void SetRedByName(string shapeName)
    {
        shapeDictionnary[shapeName].SetColor(Color.red); 
    }

    private void FindExample()
    {
        //foreach shape trouver là où s.Name == octagon
        Shape octagon = gameShapes.Find(s => s.Name == "Octagon");
        octagon.SetColor(Color.red);
    }
    private void ListExample()
    {
        string[] shapes = { "circle", "square", "triangle", "octagon"}; 
        List<string> moreShapes;

        moreShapes = new List<string> { "circle", "square", "triangle", "octagon"}; 

        moreShapes.Add("rectangle");
        moreShapes.Insert(2, "diamont");
        moreShapes.Sort();

        for(int i = 0; i < moreShapes.Count; i++)
        {
            moreShapes[i] = moreShapes[i].ToUpper();
            print(moreShapes[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            SetRedByName("Square");
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            SetRedByName("Circle");
        }
        
    }
}

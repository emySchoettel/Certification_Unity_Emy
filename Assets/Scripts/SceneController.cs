using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{

    public List<Shape> gameShapes; 
    public Dictionary<string, Shape> shapeDictionnary; 
    public Queue<Shape> shapeQueue;

    public Stack<Shape> shapeStack; 
    // Start is called before the first frame update
    void Start()
    {
        shapeStack = new Stack<Shape>(); 
        shapeQueue = new Queue<Shape>(); 
        shapeDictionnary = new Dictionary<string, Shape>(); 
        foreach(Shape shape in gameShapes)
        {
            shapeDictionnary.Add(shape.Name, shape);
        }

        shapeQueue.Enqueue(shapeDictionnary["Triangle"]);
        shapeQueue.Enqueue(shapeDictionnary["Square"]);
        shapeQueue.Enqueue(shapeDictionnary["Octagon"]);
        shapeQueue.Enqueue(shapeDictionnary["Circle"]);

        shapeStack.Push(shapeDictionnary["Triangle"]);
        shapeStack.Push(shapeDictionnary["Square"]);
        shapeStack.Push(shapeDictionnary["Octagon"]);
        shapeStack.Push(shapeDictionnary["Circle"]);
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
    private void DictionnaryExample()
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
    
    private void DeQueueExample()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(shapeQueue.Count > 0)
            {
                Shape shape = shapeQueue.Dequeue();
                shape.SetColor(Color.blue);
            }
            else
            {
                print("La queue est vide");
            }
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(shapeStack.Count > 0)
            {
                Shape shape = shapeStack.Pop();
                shape.SetColor(Color.green);
            }
            else
            {
                print("C'est vide !");
            }
        }
    }
}

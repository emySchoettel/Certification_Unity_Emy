using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineSceneController : MonoBehaviour
{
    private Coroutine countToNumberRoutine;
    public List<Shape> gameShapes;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private IEnumerator CountToNumber(int NumberToCountTo)
    {
        for(int i =0; i <= NumberToCountTo; i++)
        {
            print(i);
            yield return null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           countToNumberRoutine = StartCoroutine("CountToNumber", 15000);
            //  setShapesRed();
            StartCoroutine(SetShapesBlue());
            //Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            StopCoroutine(countToNumberRoutine);
           // StopCoroutine("CountToNumber");
            //StopAllCoroutines();
        }
    }

    private IEnumerator SetShapesBlue()
    {
        print("couleur bleue");
        foreach(Shape shape in gameShapes)
        {
            shape.SetColor(Color.blue); 
            yield return new WaitForSecondsRealtime(2);
            shape.SetColor(Color.white);
        }
        yield return new WaitForSecondsRealtime(1);
        print("j'ai attendu");

        yield return StartCoroutine(SetShapesBlue());
    }

    private void setShapesRed()
    {
        foreach(Shape shape in gameShapes)
        {
            shape.SetColor(Color.red); 
        }
    }
}

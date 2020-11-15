using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericMethodExample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        float newNumber = 5.3f; 
        Vector3 newVector = new Vector3(1,3,2);
        Evaluate("Hello world"); 
        Evaluate(10);
        Evaluate(newNumber);
        Evaluate(newVector);
    }

    private void Evaluate<T> (T suppliedValue)
    {
        Debug.LogFormat("the Type of {0} is {1}", suppliedValue, typeof(T));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

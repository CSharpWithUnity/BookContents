using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineNumbers : MonoBehaviour
{
    public int SomeInt = 1;
    public int OtherInt = 7;

    // Use this for initialization
    void Start()
    {
        print(MyFunction(SomeInt, OtherInt));
    }

    // Update is called once per frame
    void Update()
    {

    }

    int MyFunction(int a, int b)
    {
        return a + b;
    }
}
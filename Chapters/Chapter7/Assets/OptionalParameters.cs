/*
 * Chapter 7.7 Optional Parameters
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using UnityEngine;

public class OptionalParameters : MonoBehaviour
{
    /*
     * Section 7.7.1 Using Optionals
     */
    void MyFunction()
    {
        // some code here...
    }

    GameObject CreateACube(string name, Vector3 position)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.name = name;
        cube.transform.position = position;
        return cube;
    }

    GameObject CreateACube(string name, Vector3 position, float scale)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.name = name;
        cube.transform.position = position;
        cube.transform.localScale = new Vector3(scale, scale, scale);
        return cube;
    }

    void UseCreateACube()
    {
        GameObject bobCube = CreateACube("bob", new Vector3(10, 0, 0));
        Debug.Log("Created a cube named + " + bobCube.name + "At:" + bobCube.transform.position);
        // "Created a cube named + bobAt:(10.0, 0.0, 0.0)"
    }

    /*
     * Section 7.7.1 Using Optionals
     */

    GameObject CreateACubeWithOptions(string name = "bob", Vector3 position = new Vector3(), float scale = 1.0f)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.name = name;
        cube.transform.position = position;
        cube.transform.localScale = new Vector3(scale, scale, scale);
        return cube;
    }

    void ParamUsage(int i)
    {
        Debug.Log("using an int " + i);
        // "using an int 5"
    }

    void ParamUsage(string words)
    {
        Debug.Log("using a string " + words);
        // "using a string not a number"
    }

    void UsingParamUSage()
    {
        ParamUsage(5);
        ParamUsage("not a number");
    }

    /*
     * Section 7.7.1.1 Using Optionals : A Basic Example
     */
    
    void MoreParamUsage(int i)
    {
        Debug.Log("using int i, " + i + " no optional floats here.");
    }

    void MoreParamUsage(int i, float optionalFloat = 1f)
    {
        Debug.Log("using an int " + i + " and a float " + optionalFloat);
    }

    /*
     * Section 7.7.2 Optional Arguments
     */

    //void MoreParamUsage(int i, float requiredFloat)
    //{
    //    Debug.Log("using an int " + i + " and a float " + requiredFloat);
    //}
    /* uncomment the function above to see the error */

    void UsingParamUsageContinued()
    {
        MoreParamUsage(7);
        // using int i, 7 no optional floats here.
        MoreParamUsage(5, Mathf.PI);
        // using an int 5 and a float 3.141593
    }

    void UsingOptionals(int i = 1, float f = 1f)
    {
        Debug.Log("using an int " + i + " using a float " + f);
    }

    //void UsingOptionals(int i = 1, int j)
    //{
    //    Debug.Log("using an int " + i + " using a float " + f);
    //}
    /* uncomment the function above to see the error */

    void UsingUsingOptionals()
    {
        UsingOptionals();
        // "using an int 1 using a float 1"
        UsingOptionals(7);
        // "using an int 7 using a float 1"
        UsingOptionals(9, 13f);
        // "using an int 9 using a float 13"

        /* the following are not valid uses */
        /* of optionals                     */
        //UsingOptionals(23f);
        //UsingOptionals(,31f);
    }

    /*
     * Section 7.7.3 Named Parameters
     */
    void LotsOfParams(int a = 0, int b = 1, int c = 2, int d = 3)
    {
        Debug.Log("a: " + a + " b: " + b + " c: " + c + " d: " + d);
    }

    void UseLotsOfParams()
    {
        LotsOfParams();
        //"a: 0 b: 1 c: 2 d: 3"

        LotsOfParams(0, 99);
        //"a: 0 b: 99 c: 2 d: 3"

        LotsOfParams(b: 99);
        //"a: 0 b: 99 c: 2 d: 3"

        LotsOfParams(b: 99, a: 88, d: 777, c: 1234);
        //"a: 88 b: 99 c: 1234 d: 777"

        CreateACube(scale: 6.0f, name: "Henry", position: new Vector3(2f, z: 0, y: 1));
        // using named parameters

        CreateACube("Bob", new Vector3(3f, 0, 0));
        CreateACube("Henry", position: new Vector3(4f, 0, 0));
        //CreateACube(position: new Vector3(5f, 0, 0),  "Jack");
        /* uncomment the function above to see the error */
    }








    private void Start()
    {
        UseCreateACube();
        UsingParamUSage();
        UsingParamUsageContinued();
        UsingUsingOptionals();
        UseLotsOfParams();
    }
}

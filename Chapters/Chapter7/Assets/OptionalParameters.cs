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

    public GameObject CreateACube(string name, Vector3 position)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.name = name;
        cube.transform.position = position;
        return cube;
    }

    public GameObject CreateACube(string name, Vector3 position, float scale)
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
    public GameObject CreateACubeWithOptions(string name = "bob", Vector3 position = new Vector3(), float scale = 1.0f)
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.name = name;
        cube.transform.position = position;
        cube.transform.localScale = new Vector3(scale, scale, scale);
        return cube;
    }

    public void ParamUsage(int i)
    {
        Debug.Log("using an int " + i);
        // "using an int 5"
    }

    public void ParamUsage(string words)
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

    public void MoreParamUsage(int i, float optionalFloat = 1f)
    {
        Debug.Log("using an int " + i + " and a float? " + optionalFloat);
    }

    void UsingParamUsageContinued()
    {
        MoreParamUsage(7);
        MoreParamUsage(5, Mathf.PI);
        ParamUsage("some words");
    }

    private void Start()
    {
        UseCreateACube();
        UsingParamUSage();
        UsingParamUsageContinued();
    }
}

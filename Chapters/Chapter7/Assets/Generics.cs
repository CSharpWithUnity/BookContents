/*
 * Chapter 7.14 Generics
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

using UnityEngine;

public class Generics : MonoBehaviour
{
    /*
     * Section 7.14.1 Generics
     */

    void UseCastTypes()
    {
        float f = (float)1.0d;
        Debug.Log(f);
        // 1
    }

    /*
     *  Section 7.14.1.1 Generics : A Basic Example
     */
    void Log<T>(T thing)
    {
        string s = "thing is: " + thing.ToString();
        s += " type: " + thing.GetType().ToString();
        Debug.Log(s);
    }

    void UseLog()
    {
        Log(9);
        // thing is: 9 type: System.Int32
        Log(new GameObject("Zombie"));
        // thing is: Zombie (UnityEngine.GameObject) type: UnityEngine.GameObject
        Log(new Vector3());
        // thing is: (0.0, 0.0, 0.0) type: UnityEngine.Vector3
    }

    void LogInt(int i)
    {
        string s = "int is: " + i.ToString();
        Debug.Log(s);
    }

    void UseLogInt()
    {
        LogInt(13);
        //LogInt(new GameObject("Zombie"));
        //LogInt((int)new GameObject("Zombie"));
        /* uncomment the lines above to see the error */
    }

    private void Start()
    {
        UseCastTypes();
        UseLog();
    }
}

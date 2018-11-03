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

    /*   ┌─────────────────────┐ */
    /*   │ the "generic"       │ */
    /*   │ type is indicated   │ */
    /*   │ starting with <T>   │ */
    /*   │ which is used again │ */
    /*   │ in the parameter    │ */
    /*   └─────┬───────────────┘ */
    /*       ┌─┴┐                */
    /*       ↓  ↓                */
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

    /*
     * Section 7.14.1.2 Why T?
     */

    void LogCat<LOL>(LOL cat)
    {
        Debug.Log("I can has " + cat.GetType().ToString());
    }

     void UseLogCat()
    {
        LogCat(new GameObject("GameObject"));
        // I can has UnityEngine.GameObject
    }

    /*
     * Section 7.14.2 Making Use of Generic Functions
     */

    void Swap<T>(ref T first, ref T second)
    {
        T temp = second;
        second = first;
        first = temp;
    }

    void UseSwap()
    {
        int[] ints = new int[] { 7, 13 };
        foreach (int i in ints)
            Log(i);
        //thing is: 7 type: System.Int32
        //thing is: 13 type: System.Int32
        Swap(ref ints[0], ref ints[1]);
        foreach (int i in ints)
            Log(i);
        //thing is: 13 type: System.Int32
        //thing is: 7 type: System.Int32

        string[] strings = new string[] { "First", "Second" };
        foreach (string s in strings)
            Log(s);
        //thing is: First type: System.String
        //thing is: Second type: System.String
        Swap(ref strings[0], ref strings[1]);
        foreach (string s in strings)
            Log(s);
        //thing is: Second type: System.String
        //thing is: First type: System.String
    }

    private void Start()
    {
        UseCastTypes();
        UseLog();
        UseLogCat();
        UseSwap();
    }
}

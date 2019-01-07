/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 7.4 Function Overloading                                  *
 *                                                                   *
 * Copyright © 2019 Alex Okita                                       *
 *                                                                   *
 * This software may be modified and distributed under the terms     *
 * of the MIT license.  See the LICENSE file for details.            *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using UnityEngine;

public class FunctionOverloading : MonoBehaviour
{
    #region Chapter 5.4.1 A Closer Look at Functions
    /* * * * * * * * * * * * * * * * * * * * * * *
     * Section 7.4.1 A Closer Look at Functions  *
     * * * * * * * * * * * * * * * * * * * * * * */
    void UseDifferentFunctions()
    {
        int a = 8;
        float b = 7f;
        int halfA = HalfInt(a);
        float halfB = HalfFloat(b);
        Debug.Log("halfA: " + halfA + " halfB: " + halfB);
        // halfA: 4 halfB: 3.5
    }

    int HalfInt(int a)
    {
        return a / 2;
    }

    float HalfFloat(float a)
    {
        return a / 2;
    }
    /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
     * Section 7.4.1.1 A Closer Look at Functions A Basic Example  *
     * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
    void UseFunctionOverloading()
    {
        int a = 8;
        float b = 7f;
        int halfA = HalfValue(a);/* →─────────────────────────┐     */
        float halfB = HalfValue(b);/* →─────────────────────┐ │     */
        Debug.Log("halfA: " + halfA + " halfB: " + halfB);/*│ │     */
        // halfA: 4 halfB: 3.5                              │ │     
    }/*               ┌─────────────────────────────────────┘ │     */
     /*               ↓  a is an int so it uses this version  │     */
    int HalfValue(int i)//                                    │     */
    {                   //                                    │     */
        return i / 2;   //                                    │     */
    }/*                   ┌───────────────────────────────────┘     */
     /*                   ↓ b is a float, so it uses this version   */
    float HalfValue(float f)
    {
        return f / 2f;
    }

    /* Both return int, but use different parameters  */
    /*          uses a float                          */
    /*              ↓                                 */
    int HalfToInt(float f)
    {
        return (int)f / 2;
    }
    /*          uses an int                           */
    /*             ↓                                  */
    int HalfToInt(int i)
    {
        return i / 2;
    }

    int HalfFull(int i)/*←┐  ┌─────────────────┐     */
    {                  /* │  │ these functions │     */
        return i / 2;  /* ├──┤ have the same   │     */
    }                  /* │  │ signature.      │     */
    /*               ┌────┘  └─────────────────┘     */
    /*               ↓                               */
    //int HalfFull(int i) 
    //{
    //    return i * 0.5f;
    //}
    /* uncomment the above to see the error */
    #endregion

    #region Chapter 7.4.2 Function Signature
    /* * * * * * * * * * * * * * * * * * *
     * Section 7.4.2 Function Signature  *
     * * * * * * * * * * * * * * * * * * */

    int ReturnValue()
    {
        return 1;
    }
    /* return value doesn't count */
    /* as a part of the signature */
    //float ReturnValue()
    //{
    //    return 1f;
    //}
    /* uncomment the above to see the error */

    public static int Overloaded()
    {
        return 1;
    }
    public static int Overloaded(int a)
    {
        return a + 1;
    }
    public static float Overloaded(int a, float b)
    {
        return a / b;
    }
    public void UseOverloads()
    {
        int a = Overloaded();
        int b = Overloaded(1);
        float c = Overloaded(1, 3f);
        Debug.Log("a: " + a + " b: " + b + " c: " + c);
        // a: 1 b: 2 c: 0.3333333
        float d = 7;          /* initialized to 7                                 */
        Overloaded(3, d);     /* doesn't use ref in signature                     */
        Debug.Log("d: " + d); /* doesn't change from initialized version          */
        // d: 7               /* prints 7 since it didn't get changed             */
        Overloaded(3, ref d); /* this one uses ref which is a different signature */
        Debug.Log("d: " + d); /* d has been modified by ref                       */
        // d: 1               /* prints 1 since it's been modified 3/3            */
        Debug.Log("staticDouble: " + staticDouble);
        // staticDouble: 0
        Overloaded(9.0);
        Debug.Log("staticDouble: " + staticDouble);
        // staticDouble: 9
    }

    public static void Overloaded(int a, ref float b)
    {
        b = (float)a / 3;
    }

    public static double staticDouble;    
    public static void Overloaded(double d)
    {
        staticDouble = d;
    }
    #endregion

    #region Chapter 7.4.4 Putting it Together
    /* * * * * * * * * * * * * * * * * * * *
     * Section 7.4.4 Putting it Together   *
     * * * * * * * * * * * * * * * * * * * */
    GameObject CreateObject()
    {
        GameObject g = GameObject.CreatePrimitive(PrimitiveType.Cube);
        return g;
    }
    GameObject CreateObject(PrimitiveType primitive)
    {
        GameObject g = GameObject.CreatePrimitive(primitive);
        return g;
    }
    GameObject CreateObject(PrimitiveType primitive, Vector3 position)
    {
        GameObject g = GameObject.CreatePrimitive(primitive);
        g.transform.position = position;
        return g;
    }
    void UseCreateObject()
    {
        GameObject a = CreateObject();
        // makes a cube
        GameObject b = CreateObject(PrimitiveType.Capsule);
        // makes a capsule
        Vector3 position = new Vector3(0, 0, 1f);
        GameObject c = CreateObject(PrimitiveType.Sphere, position);
        // makes a sphere at x:0, y:0, z:1
    }
    #endregion

    #region Chapter 7.5.6 DrawWords
    /* * * * * * * * * * * * * * *
     * Section 7.4.6 DrawWords   *
     * * * * * * * * * * * * * * */
    void UseDrawWords()
    {
        DrawWords.DrawWord("Words Are Being Drawn", 1, Vector3.zero, Color.red);
    }
    #endregion

    void Start()
    {
        /* * * * * * * * * * * * * * * * * * * * * * *
         * Section 7.4.1 A Closer Look at Functions  *
         * * * * * * * * * * * * * * * * * * * * * * */
        UseDifferentFunctions();

        /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
         * Section 7.4.1.1 A Closer Look at Functions A Basic Example  *
         * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
        UseFunctionOverloading();

        /* * * * * * * * * * * * * * * * * * *
         * Section 7.4.2 Function Signature  *
         * * * * * * * * * * * * * * * * * * */
        UseOverloads();

        /* * * * * * * * * * * * * * * * * * * *
         * Section 7.4.4 Putting it Together   *
         * * * * * * * * * * * * * * * * * * * */
        UseCreateObject();
    }

    private void Update()
    {
        /* * * * * * * * * * * * * * *
         * Section 7.4.6 DrawWords   *
         * * * * * * * * * * * * * * */
        UseDrawWords();
    }
}

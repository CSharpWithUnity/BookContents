/*
 * Chapter 3.10 Variables
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

using UnityEngine;

#region Chapter 3.10.1 Identifiers
/* * * * * * * * * * * * * * * *
 * Section 3.10.1 Identifiers  *
 * * * * * * * * * * * * * * * */
class Identifiers
{
    /* Values which you might need for various equations *
     * can be found in the UnityEngine API. One example  *
     * of a constant value is Π Pi.                      */
    float myPi = UnityEngine.Mathf.PI;

    /* Long indentifiers can be hard                    *
     * to remember and type as you use                  *
     * the long name...                                 */
    int @OhHAICanIHasIdentifier01;

    /* Simple identifiers can be short.                 *
     * but these tend to be uninformative as to         *
     * what they do.                                    */
    int i;
}
#endregion

[UnityEngine.ExecuteInEditMode]
class Variables : MonoBehaviour
{
    #region Chapter 3.10.2 Data
    /* * * * * * * * * * * * * * * * * * * * *
     * Section 3.10.2 Data                   *
     *                                       *
     * A Declaration is the announcement to  *
     * Unity about your new variable.        *
     *                                       *
     * ┌──────┐┌────────────┐┌───────────┐   *
     * │ Type ││ Identifier ││ Separator │   *
     * └─┬────┘└────┬───────┘└────┬──────┘   *
     *   └─────┐    └┐            │          *
     *         │     │    ┌───────┘          *
     *       ──┴── ──┴─── ┴                  *
     *       float myFloat;                  *
     *       └────┬───────┘                  *
     *        ┌───┘                          *
     *  ┌─────┴─────────────────┐            *
     *  │ Declaration Statement │            *
     *  └───────────────────────┘            *
     *                                       *
     * * * * * * * * * * * * * * * * * * * * */

    public float MultiplyBy;/*→───┐ ①          */
    public float InputValue;/*→─┐ │ values are */
    public float Result;/*←─┐   │ │ assigned   */
    void Update()       /*  │   │ │            */
    {   /* ┌────────────────┘   │ │            */
        /* │         ┌──────────┘ │            */
        /* ↑         ↓            ↓            */
        Result = InputValue * MultiplyBy;
        /* ↑         ↓    ┌───┐   ↓            */
        /* │result is└────┤ * ├───┘            */
        /* ③updated       └─┬─┘② operation     */
        /* └────────────────┘    is performed  */
    }
    #endregion

    #region Chapter 3.10.3 Variable Manipulation
    /* * * * * * * * * * * * * * * * * * * * *
     * Section 3.10.3 Variable Manipulation  *
     * * * * * * * * * * * * * * * * * * * * */
    void MoreUpdates()
    {
        int i = 0;
        System.Console.Write(i);
        // i has been assigned 0

        i = 1;
        System.Console.Write(i);
        // i reasssigned to 1

        //int i = 1;
        // uncomment the line above to see the
        // error.
    }

    #region Chapter 3.10.3.1 Declaration Placement Examples
    /* * * * * * * * * * * * * * * * * * * * *
     * Section 3.10.3 Variable Manipulation  *
     * * * * * * * * * * * * * * * * * * * * */

    /* a variable declaration for a class must appear   *
     * in the body of the class definition. that is     *
     * it should appear after the opening curly brace   *
     * { and before the closing curly brace }           */

    /* comment out the lower line to                    *
     * produce an error                                 */

    //int outterInt;
    class SomeClass
    {
        int innerInt;

        /* * * * * * * * * * * * * * * * * * * * *
         * Section 3.9.4  Dynamic Initialization *
         * * * * * * * * * * * * * * * * * * * * */

        bool SomeBool;
        bool AnotherBool = false;

        /* The above two values are initialized as false *
         * even though AnotherBool has been assigned a   *
         * value, SomeBool gets automatically assigned   *
         * false when it's created.                      */

        int SomeInt;
        int AnotherInt = 0;

        /* SomeInt and AnotherInt have the same value    *
         * SomeInt is assigned 0 when it was created     *
         * AnotherInt is assigned the same value         *
         * explicitly.                                   */

        int OtherInt = 7;
        int LastInt = 11;

        /* You're allowed to assign a different          *
         * value from 0 when the variable is             *
         * created, this can be done dynamically         *
         * in the declaration of the variable.           */
    }
    #endregion
    #endregion

    private void Start()
    {

    }
}


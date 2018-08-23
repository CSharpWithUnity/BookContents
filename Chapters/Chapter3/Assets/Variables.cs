/*
 * Chapter 3.9 Variables
 */

class Identifiers
{
    /*
     * Section 3.9.1 Identifiers
     * 
     * Values which you might need for various equations
     * can be found in the UnityEngine API. One example
     * of a constant value is Π Pi.
     * 
     */

    float myPi = UnityEngine.Mathf.PI;

    /*
     * Simple identifiers can be short.
     * but these tend to be uninformative as to
     * what they do.
     */

    int i;

    /*
     * Long indentifiers can be hard
     * to remember and type as you use
     * the long name...
     */

    int @OhHAICanIHasIdentifier01;

}

[UnityEngine.ExecuteInEditMode]
class Variables : UnityEngine.MonoBehaviour
{
    /*
     * Section 3.9.2 Data
     * 
     * A Declaration is the announcement to
     * Unity about your new variable.
     *
     * ┌──────┐┌────────────┐┌───────────┐
     * │ Type ││ Identifier ││ Separator │
     * └─┬────┘└────┬───────┘└────┬──────┘
     *   └─────┐    └┐            │
     *         │     │    ┌───────┘
     *       ──┴── ──┴─── ┴ 
     *       float myFloat;
     *       └────┬───────┘
     *        ┌───┘
     *  ┌─────┴─────────────────┐
     *  │ Declaration Statement │
     *  └───────────────────────┘
     *  
     */

    public float InputValue;
    public float MultiplyBy;
    public float Result;

    void Update()
    {
        Result = InputValue * MultiplyBy;
        
        /*
         * Section 3.9.3 Variable Manipulation
         */

        int i = 0;
        System.Console.Write(i);
        // i has been assigned 0

        i = 1;
        System.Console.Write(i);
        // i reasssigned to 1

        int i = 1;
    }
}

/*
 * Section 3.9.3.1 Declaration Placement Examples
 * 
 * a variable declaration for a class must appear
 * in the body of the class definition. that is
 * it should appear after the opening curly brace
 * { and before the closing curly brace }
 */

//int someInt;
class SomeClass
{
    int someInt;
}



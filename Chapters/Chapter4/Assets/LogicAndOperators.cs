/*
 * Chapter 4.11 Logic and Operators
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using UnityEngine;

public class LogicAndOperators : MonoBehaviour
{
    /*
     * Section 4.11.1 Booleans
     */

    public bool someBool;
    /*
     * This value appears in the Inspector
     * panel.
     */

    /*
     * Some plain old data types
     * are always initialized to
     * zero.
     */

    //public int Gold;

    /* Uncomment the line above to see
     * what it's default initialization
     * is.
     * 
     * The above gets initialized
     * to 0 even though it's not
     * assigned anything when declared.
     */

    public int someInt;
    /*
     * used for section 4.11.5
     */



    /*
     * Section 4.11.2 Equality Operators
     */

    void Start()
    {
        /*
         * Section 4.11.2.1
         */

        someBool = (1 == 1);

        /*
         * The above assigns true
         * to the someBool boolean
         * property.
         */

        someBool = true;
        someBool = false;

        /* The above is similar
         * only there's no comparison
         * just an assignment.
         */

        int a = 1;
        int b = 1;
        someBool = (a == b);

        int c = 1;
        int d = 3;
        someBool = (c == d);



        /*
         * Section 4.11.3 If and Branching
         * the last assignment to someBool
         * is c == d or 1 == 3 which
         * evaluates to false.
         * so the following line does not
         * execute.
         * 
         */

        if (someBool)
        {
            transform.Rotate(new Vector3(45f, 0, 0));
        }

        /*
         * The following will always execute
         */

        if (true)
        {
            transform.Rotate(new Vector3(45f, 0, 0));
        }

        /*
         * Used in section 4.11.6
         * We get the material from CubeA
         * and use GetComponent to find
         * the mesh renderer attached to the
         * cube and then use the . operator
         * to get the material property
         * of the MeshRenderer. We'll cover
         * that in more detail in chapter 5.
         */
        cubeMaterial = CubeA.GetComponent<MeshRenderer>().material;
    }


    void Update()
    {
        if (someBool)
        {
            transform.Rotate(new Vector3(5f, 0, 0));
        }

        /*
         * Section 4.11.3.1 !Not
         */

        if (!someBool)
        {
            transform.Rotate(new Vector3(0, 5f, 0));
        }

        int a = 1;
        int b = 1;
        bool otherBool = (a != b); // false

        int c = 1;
        int d = 2;
        bool anotherBool = (c != d); // true

        /*
         * Section 4.11.4 Float Charts
         */
        int i = 1;
        if (i < 10)
        {
            Debug.Log("i is less than 10");
        }

        /*
         * 4.11.1 Flow Charts
         * 
         * The if statement above
         * can be turned into this flow
         * chart.
         *    ╭───────╮
         *    │ Start │
         *    ╰───┬───╯
         *     ┌──┴────┐ ╭─────╮ ┌────────────────────────────────┐
         *     │i < 10 ├─┤ yes ├─┤ Debug.Log("i is less than 10");│
         *     └──┬────┘ ╰─────╯ └──┬─────────────────────────────┘
         *      ╭─┴──╮              │
         *      │ no │              │
         *      ╰─┬──╯              │
         *        ├─────────────────┘
         *     ╭──┴──╮
         *     │ End │
         *     ╰─────╯
         */

        /*
         * Section 4.11.5 Relational Operators
         * 
         * == != < > >= <= 
         * don't put spaces between the ==, the
         * white space tells the lexer that the
         * (i == 1) and (i = = 1) are not the
         * same.
         */
        
        {
            /* -9 -8 -6 -5 -4 -3 -2 -1 ±0 +1 +2 +3 +4 +5 +6 +7 +8 +9 */

            int x = 1;
            bool xLessThan2 = (x < 2); // ( 1 < 2 )
            Debug.Log("xLessThan2: " + xLessThan2);
            // xLessThan2: true

            bool xLessThan1 = (x < 1); // ( 1 < 1 )
            Debug.Log("xLessThan1: " + xLessThan1);
            // xLessOrEqual: false

            bool xLessOrEqual = (x <= 1); // ( 1 <= 1 )
            Debug.Log("xLessOrEqual: " + xLessOrEqual);
            // xLessOrEqual: true
        }

        bool greater = someInt > 10;
        if (greater)
        {
            transform.position = new Vector3(0.5f, 0, 0);
        }

        if (someInt > 10)
        {
            transform.position = new Vector3(0.5f, 0, 0);
        }

        /*
         * Section 4.11.5.1 Else
         */

        //if (someInt > 10)
        if(someInt >= 10)
        {
            transform.position = new Vector3(0.5f, 0, 0);
        }
        else
        {
            transform.position = new Vector3(0, 0, 0);
        }

        /*
         *  This is equivalent to the above...
         *  
         *  if(someInt >= 10)
         *  {
         *      transform.position = new Vector3(0.5f, 0, 0);
         *  }
         *  if(someInt < 10)
         *  {
         *      transform.position = new Vector3(0, 0, 0);
         *  }
         *  
         *  but it's pretty awkward.
         */

        /*
         * Section 4.11.5.2 Else If
         */

        if (someInt >= 10)
        {
            transform.position = new Vector3(0.5f, 0, 0);
        }
        else if (someInt <= -10)
        {
            transform.position = new Vector3(-0.5f, 0, 0);
        }
        else
        {
            transform.position = new Vector3(0, 0, 0);
        }

        /*
         * Section 4.11.6 Rearranging Logic
         */
        UpdateCubes();
    }

    /*
     * Section 4.11.6 Rearranging Logic Continued...
     */
    public GameObject CubeA;
    public GameObject CubeB;
    public GameObject CubeC;
    
    /*
     * got reference to cubeMaterial in Start();
     */
    public Material cubeMaterial;

    void UpdateCubes()
    {
        Color col = Color.red;
        cubeMaterial.color = col;

        float positionAx = CubeA.transform.position.x;
        float positionAy = CubeA.transform.position.y;
        float positionBx = CubeB.transform.position.x;
        float positionBy = CubeB.transform.position.y;
        float e = positionAx + positionBx;
        // used for Section 4.11.7

        if (positionAx > positionBx)
        {
            cubeMaterial.color = Color.blue;
        }
        else
        {
            cubeMaterial.color = Color.black;
        }


        if (positionAx > positionBx)
        {
            cubeMaterial.color = Color.blue;
            {/*
              * Section 4.11.6 continued...
              */
                float d = positionAx + positionBx;
                if (d > 1.0f)
                {
                    cubeMaterial.color = Color.yellow;
                    if (d < 0f) // Will this ever prove true?
                    {
                        cubeMaterial.color = Color.cyan;
                    }
                }

                if (d < 0f)
                {
                    cubeMaterial.color = Color.cyan;
                }

                if (d > 0.5f)
                {
                    cubeMaterial.color = Color.red;
                }

                //cubeMaterial.color = Color.blue;

                /*
                 * 4.11.6.1 Unreachable Code
                 * 
                 *    ╭───────╮
                 *    │ Start │
                 *    ╰───┬───╯
                 *     ┌──┴─────┐ ╭─────╮ ┌──────────────────────┐
                 *     │d > 1.0 ├─┤ yes ├─┤ color = Color.yellow │
                 *     └──┬─────┘ ╰─────╯ └──┬───────────────────┘
                 *      ╭─┴──╮               │ (always greater than 1.0)
                 *      │ no │            ┌──┴─────┐ ╭─────╮ ┌────────────────────┐
                 *      ╰─┬──╯            │d < 0.0 ├─┤ yes ├─┤ color = Color.cyan │
                 *        │               └──┬─────┘ ╰─────╯ └──┬─────────────────┘
                 *        │                ╭─┴──╮               │
                 *        │                │ no │               │
                 *        │                ╰─┬──╯               │
                 *        ├──────────────────┘                  │
                 *        ├─────────────────────────────────────┘
                 *     ╭──┴──╮
                 *     │ End │
                 *     ╰─────╯
                 */
            }// Section 4.11.6.1 Unreachable Code

            {/*
              * Section 4.11.6.2 Order of Operations...
              */
                float d = positionAx + positionBx;
                if (d > 0f)
                {
                    cubeMaterial.color = Color.cyan;
                }

                if (d > 1.0f)
                {
                    cubeMaterial.color = Color.red;
                }

                //if (d > 0f) //always true if the above is true
                //{
                //    cubeMaterial.color = Color.cyan;
                //}
            }// Section 4.11.6.2 Order of Operations

            {/*
              * Section 4.11.7 Another Look at Scope
              */
            }// Section 4.11.7 Another Look at Scope
        }
        else
        {
            cubeMaterial.color = Color.black;
            /*
             * Section 4.11.7 Another Look at scope
             * 
             * the variable d which was calculated
             * in the if() statement above is not
             * available here in the else statement.
             */

            if (e > 1.0f)
            {/* e is the same calculation as the
              * d calculated in the above if()
              * statement. The only difference
              * is that it's calculated in the same
              * scope as the positionAx and positionBx
              * so the variable e is available
              * for both if and else statements
              */
                cubeMaterial.color = Color.green;
            }
        }

        /*
         * Section 4.11.8 What We've Learned
         */
        {
            if (someInt < 10)
            {
                cubeMaterial.color = Color.magenta;
            }

            if (someInt > -10)
            {
                cubeMaterial.color = Color.grey;
            }
        }// shortened.
        {
            bool largerThan = someInt > 10;
            bool lessThan = someInt < -10;
            if (largerThan)
            {
                cubeMaterial.color = Color.magenta;
            }
            if (lessThan)
            {
                cubeMaterial.color = Color.grey;
            }
        }// expanded.
    }
}

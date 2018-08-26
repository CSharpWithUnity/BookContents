/*
 * Chapter 4.8 Scope
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scope : MonoBehaviour
{
    /*
     * Section 4.8.1 Class Scope
     */

    int myInt = 1;
    /* Class Scope
     * Visible to the entire class
     */

    // float myInt = 1; //nope. can't redefine myInt

    void Start()
    {
        /*
         * Section 4.8 Scope
         */

        for (int i = 0; i < 10; i++)
        {
            Debug.Log(i);
        }

        /*
         * Section 4.8.1 Class Scope continued...
         */

        // Debug.Log(myInt);

        /*
         * if the line below is uncommented
         * then the line above works.
         */

        int myInt = 2; // stomps on class scoped myInt
        Debug.Log(myInt);
        /* However, declaring myInt in the Start() function
         * hides the class scoped version of myInt;
         */

        Debug.Log(this.myInt);
        /* Using the this keyword
         * tells C# to look at the class
         * scope to find the variable myInt
         */


        int declaredInStart = 1;
        Debug.Log(declaredInStart);

        /*
         * Section 4.8.1 continued...
         */

        int firstInt = 100;
        int secondInt = 200;
        Debug.Log(firstInt);
        Debug.Log(secondInt);

        int thirdInt = 300;
        Debug.Log(thirdInt);
        int fourthInt = 400;
        Debug.Log(fourthInt);
    }


    void Update ()
    {
        //Debug.Log(declaredInStart);
        /* uncomment the line above to see the error
         */

        Debug.Log(myInt);
	}

    /*
     * Section 4.8.2 Function Scope
     */

    void SomeFunction()
    {
         //public int fifthInt;
         /* Uncomment the line above
          * to see the error that the line
          * produces.
          */
    }

    /*
     * Sectopm 4/8/2 continued...
     * 
     * Scope is how visible an object is
     * so if a class as int i declared
     * all functions in it also get to see
     * i.
     *     Start() doesn't see what
     *     is inside of Update()
     *    ╔══ class ════════════╗╔══ class ════════════╗
     *    ║ ┌─ Start() ───────┐ ║║ ┌─ Start() ───────┐ ║
     *    ║ │  int myInt;     │ ║║ │ ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓ │ ║
     *    ║ └─────────────────┘ ║║ └─────────────────┘ ║
     *    ║ ┌─ Update() ──────┐ ║║ ┌─ Update() ──────┐ ║
     *    ║ │ ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓ │ ║║ │  int myInt;     │ ║
     *    ║ └─────────────────┘ ║║ └─────────────────┘ ║
     *    ╚═════════════════════╝╚═════════════════════╝
     *    Likewise, Update() doesn't
     *    see what's going on in Start()
     *    
     *    ╔══ class ════════════╗
     *    ║          int i;     ║
     *    ║ ┌─ function ─↓────┐ ║
     *    ║ │            i    │ ║
     *    ║ │  function gets  │ ║
     *    ║ │  to see i.      │ ║
     *    ║ └─────────────────┘ ║
     *    ╚═════════════════════╝
     *    variables in the class are visible
     *    to the functions in the class.
     *    ╔══ class ════════════╗
     *    ║ ┌─ function ──────┐ ║
     *    ║ │  int j;         │ ║
     *    ║ └──────▬──────────┘ ║
     *    ║ class doesn't get   ║
     *    ║ to see j declared   ║
     *    ║ in a function.      ║ 
     *    ╚═════════════════════╝
     *    
     *    class Scope
     *    {╔═══════════════════════════════╗
     *     ║ int ClassInt;────────┐        ║
     *     ║ void Start()         │        ║
     *     ║ {╔═══════════════════│══════╗ ║
     *     ║  ║ int myInt;        ↓      ║ ║
     *     ║  ║ while(myInt < ClassInt)) ║ ║
     *     ║  ║ {╔══════════════════╗    ║ ║
     *     ║  ║  ║ Debug.Log(myInt);║    ║ ║
     *     ║  ║  ║ myInt++;         ║    ║ ║
     *     ║  ║ }╚══════════════════╝    ║ ║
     *     ║ }╚══════════════════════════╝ ║
     *     ║ void Update()                 ║
     *     ║ {╔══════════════════════════╗ ║
     *     ║  ║ int myInt; (can also see ║ ║
     *     ║  ║                 ClassInt)║ ║
     *     ║ }╚══════════════════════════╝ ║
     *    }╚═══════════════════════════════╝
     *    
     */

    /*
     * Section 4.8.3 Blank Scope
     */

    void BlankScope()
    {
            int a = 0;
        {
            int b = 1;
            Debug.Log(a);
        }
        //Debug.Log(b);

        /*
         * uncomment the line above
         * to observe the error.
         */

        {
            int b = 0;
            Debug.Log(b);
        }
        {
            int b = 1;
            Debug.Log(b);
            /*
             * int b works
             * since the last
             * declaration of
             * b was in a
             * different blank
             * scope.
             */
        }

        {
            Debug.Log("blank scope...");
        }// put a label of what the code is doing here.
    }
}

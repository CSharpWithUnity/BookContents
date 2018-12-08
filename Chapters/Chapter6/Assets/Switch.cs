/*
 * Chapter 6.7 Switch
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using System;
using UnityEngine;

public class Switch : MonoBehaviour
{
    /*
     * Section 6.7 Switch
     * Here's a bad use case with
     * an If-Else-Ladder
     */

    void UsingASwitchStatement()
    {
        {
            /*
             * Section 6.7 If Else Ladder
             */
            int intValue = 4;
            if (intValue == 0)
            {
                Debug.Log("int is Zero");
            }
            else if (intValue == 1)
            {
                Debug.Log("int is One");
            }
            else if (intValue == 2)
            {
                Debug.Log("int is Two");
            }
            else if (intValue == 3)
            {
                Debug.Log("int is Three");
            }
            else if (intValue == 4)
            {
                Debug.Log("int is Four");
            }
            else
            {
                Debug.Log("int is greater than 4 or less than 0");
            }
        }
        {
            /*
             * Section 6.7 A simple example
             */
            int someVariable = 0;
            switch (someVariable)
            {
            }
        }
        {
            /*
             * Section 6.7 Replace the if-else
             * ladder with a cleaner switch statement
             * 
             */
            int intValue = 1;
            switch (intValue)
            {
                case 0:
                    Debug.Log("int is Zero");
                    break;
                case 1:
                    Debug.Log("int is One");
                    break;
                case 2:
                    Debug.Log("int is Two");
                    break;
                case 3:
                    Debug.Log("int is Three");
                    break;
                case 4:
                    Debug.Log("int is Four");
                    break;
                default:
                    Debug.Log("int is greater than 4 or less than 0");
                    break;
            }

            // just shorter, not faster.
            switch (intValue)
            {
                case 0: Debug.Log("int is Zero"); break;
                case 1: Debug.Log("int is One"); break;
            }
        }
        {
            /*
             * Using a boolean in a switch?
             */

            bool someBool = true;
            switch (someBool)
            {
                case true: Debug.Log("true"); break;
                case false: Debug.Log("false"); break;
            }
        }
        {
            /*
             * What do we do when we get
             * values outside of the expected
             * range that the switch has
             * cases for?
             */
            int intValue = 10;
            switch (intValue)
            {
                case 0:
                    Debug.Log("int is Zero");
                    break;
                case 1:
                    Debug.Log("int is One");
                    break;
                case 2:
                    Debug.Log("int is Two");
                    break;
                case 3:
                    Debug.Log("int is Three");
                    break;
                case 4:
                    Debug.Log("int is Four");
                    break;
                default:
                    Debug.Log("int is greater than 4 or less than 0");
                    break;
            }
        }
        {
            /*
             * Section 6.7.2 Default:
             * You may have noticed the default: at the 
             * end of each statement above. Do you know
             * what that's doing there?
             */
            int i = 3;
            switch (i)
            {
                case 0:
                    Debug.Log("i is Zero");
                    break;
                case 1:
                    Debug.Log("i is One");
                    break;
                case 2:
                    Debug.Log("i is Two");
                    break;
                default:
                    Debug.Log("Every other number");
                    break;
            }
        }
        /*
         * Section 6.7.2 Continued...
         */
        MyCases();
    }
    /*
     * Section 6.7.2 Continued...
     */
    public enum Cases
    {
        First,
        Second,
        Third,
        Fourth,
        Fifth,
        Sixth,
        Seventh
    }
    public Cases MyCase;
    public void MyCases()
    {
        /*
         * Section 6.7.2 Continued...
         */
        switch (MyCase)
        {
            case Cases.First:
                Debug.Log(MyCase);
                break;
            case Cases.Second:
                Debug.Log(MyCase);
                break;
            case Cases.Third:
                Debug.Log(MyCase);
                break;
            case Cases.Fourth:
                Debug.Log(MyCase);
                break;
            case Cases.Fifth:
                Debug.Log(MyCase);
                break;
            case Cases.Sixth:
                Debug.Log(MyCase);
                break;
            case Cases.Seventh:
                Debug.Log(MyCase);
                break;
            default:
                Debug.Log(MyCase);
                break;
        }
    }
    /*
     * Section 6.7.3 More On Cases
     */
    enum MoreCases
    {
        FirstCase,
        SecondCase,
        ThirdCase
    }
    MoreCases ThisCase;

    private void Start()
    {
        UsingASwitchStatement();
        {
            /*
             * Section 6.8.3 More On Cases
             */
            /*
           float f = 2.0f;
           switch (f)
           {
               case f < 1.0f:
                   Debug.Log("less than 1");
                   break;
           }
           */
            /* uncomment the switch statement above
             * to see the error.
             */

            int a = 0;
            int b = 1;
            switch (a)
            {
                case 0:
                    switch (b)
                    {
                        case 1:
                            Debug.Log("might be more confusing...");
                            break;
                    }
                break;
            }

            int c = 0;
            switch (c)
            {
                case 0:
                    ZerothFunction();
                    break;
                case 1:
                    FirstFunction();
                    break;
            }
        }
        {
            /*
             * Section 6.7.3 Continued.
             */
            int a = 0;
            switch (a)
            {
                case 0:
                    a = 1;
                    FirstFunction(a);
                    break;
                case 1:
                    SecondFunction();
                    break;
            }
            /*
             *  a bit more information
             *  on what happened in the
             *  statement above.      
             *                         ┌─────────────────────┐
             *                      ┌──┤ ① variable set to 0 │
             *      int a = 0;──────┘  ├─────────────────────┴───┐
             *      switch(a)──────────┤ ② value 0 enters switch │
             *      {                  └────────┬────────────────┴───────────────────────────┐
             *          case 0:─────────────────┤ ③ case 0: is evalueated                    │
             *              a = 1;──────────────┤ ④ variable a is assigned a new value       │
             *              FirstFunction(a);───┤ ⑤ new value 1 is entered into FirstFunction│
             *              break;──────────────┤ ⑥ case closed.                             │
             *          case 1:                 └─┼──────────────────────────────────────────┘
             *              SecondFunction();     │
             *              break;                │
             *      }                             │
             *        ┌───────────────────────────┘
             *      ┌─┼───────────────────────────────────────────┐
             *      │ ⑦ After the break; we start again down here.│
             *      └─────────────────────────────────────────────┘
             */
            switch (a)
            {
                case 0:
                    FirstFunction(a);
                    //continue;
                    /*
                     * Uncomment the continue; to see
                     * the error.
                     */
                    break;
            }
        }
        {
            /*
             * Section 6.7.4 Fall Through
             *      switch(condition)
             *      {
             *          case firstCondition:
             *              //Do things
             *              break;
             *          case secondCondition:
             *              //Do something else
             *              break;
             *      }
             *      
             *      fall through looks like this:
             *      
             *      switch(condition)
             *      {
             *          case firstCondition:
             *          case secondCondition:
             *              //Do something else
             *              break;
             *      }
             *      
             *      fall through can follow different patterns
             *      
             *      switch(condition)
             *      {
             *          case firstCondition:
             *          case secondCondition:
             *              //Do something else
             *              break;
             *          case thirdCondition:
             *          case fourthCondition:
             *          case fifthCondition:
             *              //Do another thing
             *              break;
             *      }
             *      
             *      you can't weave code into conditions
             *      
             *      switch(condition)
             *      {
             *          case firstCondition:      ┌────────────────────┐
             *              //Do Something ───────┤ not allowed without│
             *          case secondCondition:     │ break; after.      │
             *              //Do something else   └────────────────────┘
             *              break;
             *          case thirdCondition:
             *              //Do another thing
             *              break;
             *      }
             */

            Cases someCases = Cases.First;
            switch (someCases)
            {
                case Cases.First:
                    FirstFunction();
                    goto case Cases.Second; // Jumps to next case
                case Cases.Second:
                    SecondFunction();
                    break;
            }

            /*
             * Things can be used strangely.
             */

            switch (someCases)
            {
                case Cases.First:
                    FirstFunction();
                    goto case Cases.Third;
                case Cases.Second:
                    SecondFunction();
                    break;
                case Cases.Third:
                    ThirdFunction();
                    goto case Cases.Second;
            }
        }
        {
            /*
             * Section 6.7.6 Limitations
             * 
             *  float myFloat = 1f;
             *  switch (myFloat)
             *  {
             *      case 1.0f:
             *          // Do things
             *          break;
             *      case 20.0f:
             *          // Do something else
             *          break;
             *  }
             *  
             *  
             */
            string s = "Some Condition";
            switch (s)
            {
                case "Some Condition":
                    // Do things
                    break;
                case "Other Condition":
                    // Do something else
                    break;
            }
        }
    }

    private void ThirdFunction()
    {
        Debug.Log("Third Function Called.");
    }

    private void SecondFunction()
    {
        Debug.Log("Second Function Called.");
    }

    void FirstFunction(int i)
    {
        switch (i)
        {
            case 0:
                Debug.Log("I won't get called.");
                break;
            case 1:
                Debug.Log("incoming case is 1");
                break;
        }
    }

    void FirstFunction()
    {
        Debug.Log("First Case");
    }

    void ZerothFunction()
    {
        Debug.Log("ZerothCase");
    }

    private void Update()
    {
        /*
         * Section 6.7.7 Finite State Machine
         */

    }
}


/*
 * Chapter 4.11 Logic and Operators
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using System.Collections;
using UnityEngine;

/*
 * Section 4.11.1 Booleans
 */
namespace Chapter4_11
{
    public class LogicAndOperators : MonoBehaviour
    {
        /* This value appears in the Inspector */
        /* panel.                              */
        public bool someBool;

        /*
         * Some plain old data types
         * are always initialized to
         * zero.
         */

        public int Gold;

        /* Uncomment the line above to see
         * what it's default initialization
         * is.
         * 
         * The above gets initialized
         * to 0 even though it's not
         * assigned anything when declared.
         */

        /*
         * Section 4.11.2 Equality Operators
         */
        void UseSomeBools()
        {
            /*
             * value 1 compared to value 1
             * 1 == 1 is true
             */
            someBool = (1 == 1);

            /*
             * The above assigns true
             * to the someBool boolean
             * property.
             */

            someBool = true;
            someBool = false;

            /* 
             * The above is similar
             * only there's no comparison
             * just an assignment.
             */
            {
                /* values in a and b are compared   */
                /* ❶ a is assigned 1                */
                /* ❷ b is assigned 1                */
                int a = 1;/*1 == 1 is true          */
                int b = 1;/*↓    ↓ ❸                */
                someBool = (a == b);
                /*  ↑        true                   */
                /*  └────❹─────┘                    */
                /*  someBool is assigned            */
                /*  true                            */
                Debug.Log("someBool:" + someBool);
                // someBool:True
            }
            {
                /* values in a and b are compared   */
                /* ❶ a is assigned 1                */
                /* ❷ b is assigned 3                */
                int a = 1;/*1 == 3 is false         */
                int b = 3;/*↓    ↓ ❸                */
                someBool = (a == b);
                /*  ↑        false                  */
                /*  └────❹─────┘                    */
                /*  someBool is assigned            */
                /*  false                           */
                Debug.Log("someBool:" + someBool);
                // someBool:False
            }
        }

        /*
         * Section 4.11.3 Logical Not!
         */
        void UseNotBool()
        {
            {
                bool a_IsNot_b;
                /* values in a and b are compared       */
                /* ❶ a is assigned 1                    */
                /* ❷ b is assigned 3                    */
                int a = 1;/* 1 != 3 is true             */
                int b = 3;/* ↓    ↓ ❸                   */
                a_IsNot_b = (a != b);
                /*  ↑         true                      */
                /*  └────❹─────┘                        */
                /*  a_IsNot_b is assigned               */
                /*  true                                */
                Debug.Log("a_IsNot_b:" + a_IsNot_b);
                // a_IsNot_b:True
            }
            {
                /* values in a and b are compared       */
                /* ❶ a is assigned 1                    */
                /* ❷ b is assigned 1                    */
                bool a_IsNot_b;
                int a = 1;/*   1 != 1 is false          */
                int b = 1;/*   ↓    ↓ ❸                 */
                a_IsNot_b = (a != b);
                /*  ↑         false                     */
                /*  └────❹─────┘                        */
                /*  a_IsNot_b is assigned               */
                /*  false                               */
                Debug.Log("a_IsNot_b:" + a_IsNot_b);
                // a_IsNot_b:False
            }
            {
                bool not_a_is_b;
                int a = 1;/*   1 == 1 is true           */
                int b = 1;/*   ↓    ↓                   */
                not_a_is_b = !(a == b);
                /* ❷↑        ↑  true                    */
                /*  └────────❶───┘                      */
                /*  ❶ not true                          */
                /*  ❷ false is assigned                 */
                Debug.Log("not_a_is_b:" + not_a_is_b);
                // not_a_is_b:Talse
            }
            {
                bool not_a_isNot_b;
                int a = 1;/*      1 != 1 is false       */
                int b = 1;/*      ↓    ↓                */
                not_a_isNot_b = !(a != b);
                /* ❷↑           ↑  false                */
                /*  └───────────❶───┘                   */
                /*  ❶ not false                         */
                /*  ❷ true is assigned                  */
                Debug.Log("not_a_isNot_b:" + not_a_isNot_b);
                // not_a_isNot_b:True
            }
        }

        /*
         * Section 4.11.4 Greater or Less than Operators
         */
        void UseGreaterOrLessThan()
        {
            {
                /* this compares the values of numbers  */
                /* -5 -4 -3 -2 -1 ±0 +1 +2 +3 +4 +5     */
                /*├────────────────┼────────┼──────┤    */
                /*                 0        3           */
                bool greaterThan = (3 > 0);
                Debug.Log("greaterThan:" + greaterThan);
                // greaterThan:True
            }

            {
                /* this compares the values of numbers  */
                /* -5 -4 -3 -2 -1 ±0 +1 +2 +3 +4 +5     */
                /*├────────────────┼────────┼──────┤    */
                /*                 0        3           */
                bool greaterThan = (0 > 3);
                Debug.Log("greaterThan:" + greaterThan);
                // greaterThan:False
            }

            {
                /* this compares the values of numbers  */
                /* -5 -4 -3 -2 -1 ±0 +1 +2 +3 +4 +5     */
                /*├────────────────┼────────┼──────┤    */
                /*                 0        3           */
                bool greaterThan = !(0 > 3);
                /*                 ↑ not operator       */
                Debug.Log("greaterThan:" + greaterThan);
                // greaterThan:True
            }

            {
                /* this compares the values of numbers  */
                /* -5 -4 -3 -2 -1 ±0 +1 +2 +3 +4 +5     */
                /*├────────────────┼────────┼──────┤    */
                /*                 0        3           */
                bool lessThan = (0 < 3);
                Debug.Log("lessThan:" + lessThan);
                // lessThan:True
            }

            {
                /* this compares the values of numbers  */
                /* -5 -4 -3 -2 -1 ±0 +1 +2 +3 +4 +5     */
                /*├─────────────────────────┼──────┤    */
                /*                          3 vs 3 ?    */
                bool lessThan = (3 < 3);
                Debug.Log("lessThan:" + lessThan);
                // lessThan:False
                bool greaterThan = (3 > 3);
                Debug.Log("greaterThan:" + greaterThan);
                // greaterThan:False
            }

            {
                /* this compares the values of numbers  */
                /* -5 -4 -3 -2 -1 ±0 +1 +2 +3 +4 +5     */
                /*├─────────────────────────┼──────┤    */
                /*                          3 vs 3 ?    */
                bool lessThanOrEqual = (3 <= 3);
                Debug.Log("lessThanOrEqual:" + lessThanOrEqual);
                // lessThanOrEqual:True
                bool greaterThanOrEqual = (3 >= 3);
                Debug.Log("greaterThanOrEqual:" + greaterThanOrEqual);
                // greaterThanOrEqual:True
            }
        }

        /*
         * Section 4.11.5 Logical And and Or operators
         */
        void UseAndAndOrOperators()
        {
            {
                /* this compares the values of numbers  */
                /* -5 -4 -3 -2 -1 ±0 +1 +2 +3 +4 +5     */
                /*├─────────────────────────┼──────┤    */
                /*                          3 vs 3 ?    */
                bool lessThanOrEqual = (3 < 3 || 3 == 3);
                Debug.Log("lessThanOrEqual:" + lessThanOrEqual);
                // lessThanOrEqual:true
                bool greaterThanOrEqual = (3 > 3 || 3 == 3);
                Debug.Log("greaterThanOrEqual:" + greaterThanOrEqual);
                // greaterThanOrEqual:True
            }

            {
                /* logical || or operator               */
                bool logicalOr = (false || true);
                Debug.Log("logicalOr:" + logicalOr);
                // logicalOr:True
                bool logicalOrs = (false || false || false || true);
                Debug.Log("logicalOrs:" + logicalOrs);
                // logicalOr:True
                bool oneFalse = (false || true || true || true);
                Debug.Log("oneFalse:" + oneFalse);
                // oneFalse:True
            }

            {
                /* logical && and operator               */
                bool falseTrue = (false && true);
                Debug.Log("falseTrue:" + falseTrue);
                // falseTrue:False
                bool falseFalse = (false && false);
                Debug.Log("falseFalse:" + falseFalse);
                // falseFalse:False
                bool trueTrue = (true && true);
                Debug.Log("trueTrue:" + trueTrue);
                // trueTrue:True
                bool notTrueEnough = (false && true && true && true);
                Debug.Log("notTrueEnough:" + notTrueEnough);
                // notTrueEnough:False
            }

            {
                /* this compares the values of numbers  */
                /* -5 -4 -3 -2 -1 ±0 +1 +2 +3 +4 +5     */
                /*├──────────┼───────────┼─────────┤    */
                /*           ├───────────┤              */
                /*        -3 < x       x < 3            */
                int x = -5;
                while (x < 5)
                {
                    bool inRange = (-3 < x && x < 3);
                    Debug.Log(x + " inRange:" + inRange);
                    x++;
                }
                /* -5 inRange:False
                 * -4 inRange:False
                 * -3 inRange:False
                 * -2 inRange:True
                 * -1 inRange:True
                 *  0 inRange:True
                 *  1 inRange:True
                 *  2 inRange:True
                 *  3 inRange:False
                 *  4 inRange:False
                 */
            }
            {
                int x = -5;
                while (x < 5)
                {
                    bool ranges = (x < 3 && -3 < x) &&
                                  (x > -3 && 3 > x) &&
                                  (x > -3 && x < 3) &&
                                  (x < 3 && x > -3);
                    Debug.Log(x + " ranges:" + ranges);
                    x++;
                }
                /* -5 inRange:False
                 * -4 inRange:False
                 * -3 inRange:False
                 * -2 inRange:True
                 * -1 inRange:True
                 *  0 inRange:True
                 *  1 inRange:True
                 *  2 inRange:True
                 *  3 inRange:False
                 *  4 inRange:False
                 */
            }
        }

        void UseIfAndBranching()
        {
            if(true)
            {
                Debug.Log("Do the thing!");
            }

            if(false)
            {
                // unreachable code.
                Debug.Log("Won't do a thing.");
            }

            {
                // make a bunch of cubes.
                // we'll get into loops like this
                // in the next chapter.
                for(int x = 0; x < 10; x++)
                {
                    for(int z = 0; z < 10; z++)
                    {
                        GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        box.transform.position = new Vector3()
                        {
                            x = x - 5,
                            z = z - 5
                        };
                    }
                }
                IEnumerator updateColors()
                {

                }
            }
        }

        void Start()
        {
            /*
             * Section 4.11.2 Logic and Operators
             * uncomment or comment the line below to see the code in action!
             */
            UseSomeBools();

            /*
             * Section 4.11.3 Not!
             * uncomment or comment the line below to see the code in action!
             */
            UseNotBool();

            /*
             * Section 4.11.4 Greater or Less than operators
             * uncomment or comment the line below to see the code in action!
             */
            UseGreaterOrLessThan();

            /*
             * Section 4.11.5 Logical And and Or operators
             * uncomment or comment the line below to see the code in action!
             */
            UseAndAndOrOperators();

            /*
             * Section 4.11.6 If and Branching
             * uncomment or comment the line below to see the code in action!
             */
            UseIfAndBranching();
        }


        void Update()
        {

        }
    }
}
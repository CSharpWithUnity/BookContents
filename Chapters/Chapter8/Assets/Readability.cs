/*
 * Chapter 8.3 Readability
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

namespace Chapter8_3
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Readability : MonoBehaviour
    {
        /*
         * Section 8.3.1 ?: Ternary Conditional Operator
         */
        void UseTernaryConditionalOperator()
        {
            {
                string result;
                bool condition = true;
                if (condition)
                {
                    result = "True";
                }
                else
                {
                    result = "False";
                }
                Debug.Log("Result of condition = " + result);
                // Result of condition = True
            }

            {
                bool condition = true;
                /*       └──────────┐                       */
                /*                  ↓                       */
                string result = condition ? "True" : "False";
                /*       ↑                 ①──┬───   ②──┬──         */
                /*       │            ┌───────┴─────────┴──────────┐*/
                /*       │            │first statement returned    │*/
                /*       └───────────←┤if condition is true else   │*/
                /*                    │second statement is returned│*/
                /*                    └────────────────────────────┘*/
                Debug.Log("Result of condition = " + result);
                // Result of condition = True
            }

            {
                int greaterThan(int a, int b)
                {
                    return a > b ? a : b;
                }
                Debug.Log("Greater:" + greaterThan(5, 7));
                // Greater:7
            }

            {
                int greaterThan(int a, int b, int c)
                {
                    return (a > b) ? ((a > c) ? a : c) : ((b > c) ? b : c);
                }
                Debug.Log("Greater:" + greaterThan(5, 7, 11));
                // Greater:11
            }

            {
                int greaterThan(int a, int b, int c)
                {
                    return a > b ? a > c ? a : c : b > c ? b : c;
                }
                Debug.Log("Greater:" + greaterThan(5, 7, 11));
                // Greater:11
            }
        }

        /*
         * 8.3.2 If
         */
        void UseIf()
        {

        }


        // Start is called before the first frame update
        void Start()
        {
            /*
             * Section 8.3.1 ?: Ternary Conditional Operator
             */
            UseTernaryConditionalOperator();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

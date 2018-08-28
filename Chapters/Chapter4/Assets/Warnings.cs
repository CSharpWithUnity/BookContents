/*
 * Chapter 4.14 Warnings
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using System.Collections;
using UnityEngine;

public class Warnings : MonoBehaviour
{
    void Function()
    {
        /*
         * Section 4.14.1 Warnings
         */
        int i = 0; // unused, so maybe comment it till it's needed?

        /*
         * Section 4.14.2 Errors
         */

        //float f = 1.0;
        
        /*
         * uncomment the line above to see
         * the error.
         */

        float f = 1.0f;
        
        /* the 1.0f changes
         * the literal into a
         * matching type for f
         */
    }

    void Start()
    {
        {
            /*
             * Section 4.14.3 Understanding the Debugger
             */
            int a, b = 0;
            //Debug.Log(a);

            /* Uncomment the line above to see the error
             * 
             * The variable b was assigned a value
             * a isn't assigned anything.
             */
        }
        {
            /*The break point on the following line
             *will only highlight the a = 0
             * and not the b = 0
             */
            int a = 0, b = 0;
            Debug.Log(a + b);
        }
        {
            /* Try to make things as easy to debug
             * as possible.
             * keep things on different lines
             * just to help spread out where the
             * code is executed.
             */
            int a = 0;
            int b = 0;
            Debug.Log(a + b);

            int c = a; int d = b;
            /* it's hard to read and
             * hard to debug and
             * Don't make things harder
             * on yourself than necessary.
             * break things up on different
             * lines
             */
        }
        {
            ArrayList list = new ArrayList();
            list.Add(1);
            list.Add(1.0f);
            list.Add(1.0);
            list.Add("1");
            /* Lists can have pretty much anything
             * added to them. The foreach loop
             * doesn't know what is in the list.
             */
            foreach (int i in list)
            {
                Debug.Log(i);
            }
        }
    }
}

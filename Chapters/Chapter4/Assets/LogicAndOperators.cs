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



    /*
     * Section 4.11.2 Equality Operators
     */

    void Start()
    {
        /*
         * Section 4.11.2.1
         */

        someBool = (1 == 1);

        int a = 1;
        int b = 1;
        someBool = (a == b);

        int c = 1;
        int d = 3;
        someBool = (c == d);

    }
}

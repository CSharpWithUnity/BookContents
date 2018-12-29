/*
 * Chapter 5.2 Review
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

using UnityEngine;

public class Review : MonoBehaviour
{
    #region Chapter 5.2 Review
    /* * * * * * * * * * * * * * * * * * * * * * *
     * Section 5.2 Review                        *
     * * * * * * * * * * * * * * * * * * * * * * */

    /* Section 5.2 Review                        *
     *                                           *
     * int a = 10;                               *
     * Pretty familiar with the above by now.    *
     *                                           *
     * local a = 10                              *
     * the same thing, but in lua                *
     *                                           *
     * var a = 10;                               *
     * javascript shares the ; separator         *
     * but uses var as a generic variable        *
     * storage keyword.                          */

    void Function()
    {
        for (int i = 0; i < 10; i++)
        {
            // Code Here
        }
        /*
         * for i = 0, 10, i++
         * do
         *     // Code Here
         * end
         * 
         * Lua omits many of the separators
         * that are used by many other languages
         * C# included.
         */
    }

    void UseSomeNewClass()
    {
        /*
         * Section 5.2 continued... in SomeNewClass
         */
        SomeNewClass newClass = (SomeNewClass)FindObjectOfType(typeof(SomeNewClass));
        Debug.Log(newClass.MyFunction(11));
    }

    /* Here we can look for the SomeNewClass in the scene   *
     * and use one of it's functions.                       */
    #endregion

    private void Start()
    {
        /* * * * * * * * * * * * * * * * * * * * * * *
         * Section 5.2 Review                        *
         * * * * * * * * * * * * * * * * * * * * * * */
        UseSomeNewClass();
    }
}


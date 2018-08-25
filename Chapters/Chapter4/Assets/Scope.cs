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

	void Start ()
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

        Debug.Log(this.myInt);
        int myInt = 2; // stomps on class scoped myInt
        Debug.Log(myInt);

        /* However, declaring myInt in the Start() function
         * hides the class scoped version of myInt;
         */
	}

	void Update ()
    {
        Debug.Log(myInt);
	}
}

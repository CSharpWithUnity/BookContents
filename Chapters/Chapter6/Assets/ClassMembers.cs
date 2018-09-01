/*
 * Chapter 6.3 Class Members
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using UnityEngine;

public class ClassMembers : MonoBehaviour
{
    /*
     * Section 6.3.2 Class Members
     */

    /*
     * Section 6.3.2.1 Class Members - A Basic Example
     */
    public class Members
    {
        public void FirstFunction()
        {
            Debug.Log("FirstFunction");
        }
    }

    void Start()
    {
        Members m = new Members();
        m.FirstFunction();
    }
}


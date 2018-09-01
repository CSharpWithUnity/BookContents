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
        /*
         * Some public function in Members
         */
        public void FirstFunction()
        {
            Debug.Log("FirstFunction");
        }
    }

    void Start()
    {
        // Make a members object
        Members m = new Members();
        // Call on Members' FirstFunction();
        m.FirstFunction();
        position = transform.position;
        /*
         * Section 6.3.3.1 Return - A Basic Example
         */
        Debug.Log(ImANumber());
        Debug.Log(ImANumber() + ImANumber());
    }
    
    int ImANumber()
    {
        return 3;
    }

    public Vector3 position;
    void Update()
    {
        /*
         * Section 6.3.2.2 Thinking like a programmer
         */
        bool AKey = Input.GetKey(KeyCode.A);
        bool WKey = Input.GetKey(KeyCode.W);
        bool SKey = Input.GetKey(KeyCode.S);
        bool DKey = Input.GetKey(KeyCode.D);
        Debug.Log(AKey);
        if (AKey)
        {
            position.x = position.x - 0.1f;
        }
        if (DKey)
        {
            position.x = position.x + 0.1f;
        }
        if (WKey)
        {
            position.z = position.z + 0.1f;
        }
        if (SKey)
        {
            position.z = position.z - 0.1f;
        }
        transform.position = position;

    }

}


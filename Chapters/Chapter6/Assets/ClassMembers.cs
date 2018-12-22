/*
 * Chapter 6.2.1 Class Members
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using UnityEngine;

public class ClassMembers : MonoBehaviour
{
    #region Chapter 6.2.1
    /*
     * Section 6.2.1 Class Members
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

    void UseClassMembers()
    {
        // Make a members object
        Members m = new Members();
        // Call on Members' FirstFunction();
        m.FirstFunction();
        position = transform.position;
    }
    #endregion

    #region Chapter 6.2.2 Return
    /*
     * Section 6.2.2.1 Return - A Basic Example
     */
    void UseReturn()
    {
        Debug.Log(ImANumber());
        Debug.Log(ImANumber() + ImANumber());

        //ImANumber() = 7;
        /*
         * Uncomment the line above to
         * see the error.
         */
    }

    /*
     * Section 6.3.4 continued...
     */
    int ImANumber()
    {
        return 3;
    }

    int INeedANumber(int number)
    {
        return number;
    }

    int INeedANumberPlusOne(int number)
    {
        return number + 1;
    }
    #endregion

    #region Chapter 6.2.3 
    /*
     * Section 6.3.4 Arguments aka Args (Not Related to Pirates)
     */
    void UseArgs()
    {
        Debug.Log(INeedANumber(1));

        int val = INeedANumber(3) + INeedANumber(7);
        Debug.Log(val);
    }
    #endregion

    void Start()
    {
        /*
         * Section 6.2.1 Class Members
         */
        UseClassMembers();
        /*
         * Section 6.2.2 Return
         */
        UseReturn();

        /*
         * Section 6.3.4 Arguments aka Args (Not Related to Pirates)
         */
        UseArgs();

        {
            /*
             * Section 6.3.4.2 Multiple Args
             */
            Debug.Log(INeedTwoNumbers(7, 10));
        }
    }

    /*
     * Section 6.3.4.2 Multiple Args
     */
    int INeedTwoNumbers(int a, int b)
    {
        return a + b;
    }

    int INeedTwoNumbersOfDifferentTypes(int a, float b)
    {
        return a + (int)b;
    }

    bool NumbersAreTheSame(int a, int b)
    {
        bool returnValue;
        if (a == b)
        {
            returnValue = true;
        }
        else
        {
            returnValue = false;
        }
        return returnValue;
    }

    bool NumbersAreTheSameSimple(int a, int b)
    {
        if (a == b)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool NumbersAreTheSameMostSimple(int a, int b)
    {
        return a == b;
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

        // transform.position = position;
        /* uncomment to see the position
         * update from the above functions
         */

        /*
         * 6.3.4.3 Using Args continued...
         */

        //transform.position += Movement(0.2f);
        /*
         * Uncomment the line above
         * to see how the code works with
         * a hard coded value.
         */

        transform.position += Movement(Speed);

        /*
         * Section 6.3.5 Assignment Operators
         */
        UpdateAssignmentOperators();
    }

    /*
     * Section 6.3.4.3 Using Args
     */
    
    Vector3 Movement(float dist)
    {
        Vector3 vector = Vector3.zero;
        if (Input.GetKey(KeyCode.A))
        {
            vector.x -= dist;
        }
        if (Input.GetKey(KeyCode.D))
        {
            vector.x += dist;
        }
        if (Input.GetKey(KeyCode.W))
        {
            vector.z += dist;
        }
        if (Input.GetKey(KeyCode.S))
        {
            vector.z -= dist;
        }
        return vector;
    }
    public float Speed;

    /*
     * Section 6.3.5 Assignment Operator
     */
    float f = 0;
    void UpdateAssignmentOperators()
    {
        //transform.position += new Vector3(0.1f, 0, 0);
        /*
         * Uncomment the line above to see a constant movement
         * on x.
         */

        /*
         * Section 6.3.5.1 Assignment Operators - A Basic Example.
         */

        f += 0.25f;
        Debug.Log(f);

        transform.position += Offset();
        
    }

    Vector3 Offset()
    {
        return new Vector3(0.1f, 0.2f, 0.3f);
    }
}


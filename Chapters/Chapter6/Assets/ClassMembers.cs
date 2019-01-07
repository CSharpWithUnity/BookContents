/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 6.2.1 Class Members                                       *
 *                                                                   *
 * Copyright © 2018 Alex Okita                                       *
 *                                                                   *
 * This software may be modified and distributed under the terms     *
 * of the MIT license.  See the LICENSE file for details.            *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
namespace Chapter6_2
{
    using UnityEngine;
    public class ClassMembers : MonoBehaviour
    {
        #region Chapter 6.2.1 Class Members
        /* * * * * * * * * * * * * * * *
         * Section 6.2.1 Class Members *
         * * * * * * * * * * * * * * * */
        #region Chapter 6.2.1.1 Class Members - A Basic Example
        /* * * * * * * * * * * * * * * * * * * * * * * * * * *
         * Section 6.3.2.1 Class Members - A Basic Example   *
         * * * * * * * * * * * * * * * * * * * * * * * * * * */
        public class Members
        {
            /* Some public function in Members */
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
        }
        #endregion
        #region Chapter 6.2.1.2 Thinking Like a Programmer
        public Vector3 position;
        void UseKeys()
        {
            {
                /* * * * * * * * * * * * * * * * * * * * * * * *
                 * Section 6.2.1.2 Thinking Like a Programmer  *
                 * * * * * * * * * * * * * * * * * * * * * * * */
                bool AKey = Input.GetKey(KeyCode.A);
                Debug.Log(AKey);
            }
            {
                bool AKey = Input.GetKey(KeyCode.A);
                bool WKey = Input.GetKey(KeyCode.W);
                bool SKey = Input.GetKey(KeyCode.S);
                bool DKey = Input.GetKey(KeyCode.D);
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
            }
        }
        #endregion
        #endregion

        #region Chapter 6.2.2 Return
        void UseReturn()
        {
            #region Chapter 6.2.2.1 Return - A Basic Example
            /* * * * * * * * * * * * * * * * * * * * * * *
             * Section 6.2.2.1 Return - A Basic Example  *
             * * * * * * * * * * * * * * * * * * * * * * */
            int ImANumber()
            {
                return 3;
            }
            Debug.Log(ImANumber());
            Debug.Log(ImANumber() + ImANumber());
            //ImANumber() = 7;
            /* Uncomment the line above to  *
             * see the error.               */
            #endregion
        }
        /* * * * * * * * * * * * * * * * *
         * Section 6.3.4 continued...    *
         * * * * * * * * * * * * * * * * */


        int INeedANumberPlusOne(int number)
        {
            return number + 1;
        }
        #endregion

        #region Chapter 6.2.3 Arguments aka "Args" (Not Related to Pirates)
        void UseArguments()
        {
            #region Chapter 6.2.3.1 Arguments - A Basic Example
            /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
             * Section 6.3.4 Arguments aka "Args" (Not Related to Pirates) *
             * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
            int INeedANumber(int number)
            {
                return number;
            }
            Debug.Log(INeedANumber(1));
            // 1

            int val = INeedANumber(3) + INeedANumber(7);
            Debug.Log(val);
            // 10
            #endregion
            
            #region Chapter 6.2.3.2 Multiple Arguments
            /* * * * * * * * * * * * * * * * *
             * Section 6.3.4.2 Multiple Args *
             * * * * * * * * * * * * * * * * */
            int INeedTwoNumbers(int a, int b)
            {
                return a + b;
            }
            Debug.Log(INeedTwoNumbers(7, 10));
            // 17

            int INeedTwoNumbersOfDifferentTypes(int a, float b)
            {
                return a + (int)b;
            }
            Debug.Log(INeedTwoNumbersOfDifferentTypes(7, 10f));
            // 17

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
            Debug.Log(NumbersAreTheSame(7, 10));
            // false

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
            Debug.Log(NumbersAreTheSameSimple(7, 10));
            // false


            bool NumbersAreTheSameMostSimple(int a, int b)
            {
                return a == b;
            }
            Debug.Log(NumbersAreTheSameMostSimple(7, 10));
            // false

            #endregion

        }
        #region Chapter 6.2.3.3 Using Args
        public float Speed;
        void UseArgs()
        {
            /* * * * * * * * * * * * * * * *
             * Section 6.2.3.3 Using Args  *
             * * * * * * * * * * * * * * * */

            //Debug.Log(Input.GetKey(KeyCode.A));
            /* Uncomment the line above to see the output */

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
            
            // transform.position += Movement(0.2f);
            /* Uncomment the line above to see the movement *
             * at a set speed.                              */

            transform.position += Movement(Speed);
        }
        #endregion
        #endregion

        #region Chapter 6.2.4 Assignment Operators
        /* * * * * * * * * * * * * * * * * * * *
         * Section 6.2.4 Assignment Operators  *
         * * * * * * * * * * * * * * * * * * * */
        float f = 0;
        void UpdateAssignmentOperators()
        {
            //transform.position += new Vector3(0.1f, 0, 0);
            /* Uncomment the line above to      *
             * see a constant movement on x.    */

            f += 0.25f;
            Debug.Log(f);
            transform.position += Offset();
        }

        Vector3 Offset()
        {
            return new Vector3(0.1f, 0.2f, 0.3f);
        }

        #endregion

        void Start()
        {
            /* * * * * * * * * * * * * * * *
             * Section 6.2.1 Class Members *
             * * * * * * * * * * * * * * * */
            UseClassMembers();

            /* * * * * * * * * * * * *
             * Section 6.2.2 Return  *
             * * * * * * * * * * * * */
            UseReturn();

            /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
             * Section 6.2.3 Arguments aka Args (Not Related to Pirates) *
             * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
            UseArguments();
        }

        void Update()
        {
            /* * * * * * * * * * * * * * * *
             * Section 6.2.3.3 Using Args  *
             * * * * * * * * * * * * * * * */
            UseArgs();

            /* * * * * * * * * * * * * * * * * * * * * * * *
             * Section 6.2.3.3 Thinking like a programmer  *
             * * * * * * * * * * * * * * * * * * * * * * * */
            UseKeys();

            /* * * * * * * * * * * * * * * * * * * *
             * Section 6.2.4 Assignment Operators  *
             * * * * * * * * * * * * * * * * * * * */
            UpdateAssignmentOperators();
        }
    }
}

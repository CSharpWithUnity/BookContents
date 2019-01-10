/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 5.5 Static                                                *
 *                                                                   *
 * Copyright © 2018 Alex Okita                                       *
 *                                                                   *
 * This software may be modified and distributed under the terms     *
 * of the MIT license.  See the LICENSE file for details.            *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
namespace Chapter5_5
{
    using Chapter5_5_2_1;
    using UnityEngine;

    public class Static : MonoBehaviour
    {
        #region Chapter 5.5.1 A Basic Example
        /* * * * * * * * * * * * * * * * * *
         * Section 5.5.1 A Basic Example   *
         * * * * * * * * * * * * * * * * * */
        void UseAKey()
        {
            bool aKey = Input.GetKey(KeyCode.A);
            if (aKey)
            {
                Debug.Log("aKey");
            }

            /*
             * Section 5.5.1 continued...
             */
            Input input = new Input();
            //bool aKey = input.GetKey(KeyCode.A);
            /*
             * Uncomment the line above to see the error
             */
        }
        #endregion

        #region Chapter 5.5.2 Static Variables
        /* * * * * * * * * * * * * * * * * *
         * Section 5.5.2 Static Variables  *
         * * * * * * * * * * * * * * * * * */
        void UseStaticVariables()
        {
            for (int i = 0; i < 10; i++)
            {
                Debug.Log(i); // prints 1 to 10
                              //uncomment the line above to see the numbers
            }
            // i no longer exists.
            // Debug.Log(i); //i is undefined.
        }
        #endregion

        #region Chapter 5.5.3 Static Functions
        /* * * * * * * * * * * * * * * * * *
         * Section 5.5.3 Static Functions  *
         * * * * * * * * * * * * * * * * * */
        void UseStaticFunctions()
        {
            bool aKey = Input.GetKey(KeyCode.A);
            if (aKey)
            {
                Zombie.CountZombies();
            }
            /* The call to the Zombie static function */
        }
        #endregion

        void Update()
        {
            /* * * * * * * * * * * * * * * * * *
             * Section 5.5.1 A Basic Example   *
             * * * * * * * * * * * * * * * * * */
            UseAKey();

            /* * * * * * * * * * * * * * * * * *
             * Section 5.5.2 Static Variables  *
             * * * * * * * * * * * * * * * * * */
            UseStaticVariables();

            /* * * * * * * * * * * * * * * * * *
             * Section 5.5.3 Static Functions  *
             * * * * * * * * * * * * * * * * * */
            UseStaticFunctions();
        }
    }
}


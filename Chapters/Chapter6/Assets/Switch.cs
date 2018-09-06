/*
 * Chapter 6.6 Switch
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using UnityEngine;

public class Switch : MonoBehaviour
{
    /*
     * Section 6.7 Switch
     * Here's a bad use case with
     * an If-Else-Ladder
     */

    void UsingASwitchStatement()
    {
        {
            /*
             * Section 6.7 If Else Ladder
             */
            int intValue = 4;
            if (intValue == 0)
            {
                Debug.Log("int is Zero");
            }
            else if (intValue == 1)
            {
                Debug.Log("int is One");
            }
            else if (intValue == 2)
            {
                Debug.Log("int is Two");
            }
            else if (intValue == 3)
            {
                Debug.Log("int is Three");
            }
            else if (intValue == 4)
            {
                Debug.Log("int is Four");
            }
            else
            {
                Debug.Log("int is greater than 4 or less than 0");
            }
        }
        {
            /*
             * Section 6.7 A simple example
             */
            int someVariable = 0;
            switch (someVariable)
            {
            }
        }
        {
            /*
             * Section 6.7 Replace the if-else
             * ladder with a cleaner switch statement
             * 
             */
            int intValue = 1;
            switch (intValue)
            {
                case 0:
                    Debug.Log("int is Zero");
                    break;
                case 1:
                    Debug.Log("int is One");
                    break;
                case 2:
                    Debug.Log("int is Two");
                    break;
                case 3:
                    Debug.Log("int is Three");
                    break;
                case 4:
                    Debug.Log("int is Four");
                    break;
                default:
                    Debug.Log("int is greater than 4 or less than 0");
                    break;
            }

            // just shorter, not faster.
            switch (intValue)
            {
                case 0: Debug.Log("int is Zero"); break;
                case 1: Debug.Log("int is One"); break;
            }
        }
        {
            /*
             * Using a boolean in a switch?
             */

            bool someBool = true;
            switch (someBool)
            {
                case true: Debug.Log("true"); break;
                case false: Debug.Log("false"); break;
            }
        }
        {
            /*
             * What do we do when we get
             * values outside of the expected
             * range that the switch has
             * cases for?
             */
            int intValue = 10;
            switch (intValue)
            {
                case 0:
                    Debug.Log("int is Zero");
                    break;
                case 1:
                    Debug.Log("int is One");
                    break;
                case 2:
                    Debug.Log("int is Two");
                    break;
                case 3:
                    Debug.Log("int is Three");
                    break;
                case 4:
                    Debug.Log("int is Four");
                    break;
                default:
                    Debug.Log("int is greater than 4 or less than 0");
                    break;
            }

        }

    }

    private void Start()
    {
        UsingASwitchStatement();
    }
}


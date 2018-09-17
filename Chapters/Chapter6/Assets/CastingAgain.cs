/*
 * Chapter 6.14 Type Casting Again
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using UnityEngine;

public class CastingAgain : MonoBehaviour
{
    /*
     * Section 6.14 Type Casting Again
     */
    enum SimpleEnums
    {
        FirstValue,
        SecondValue,
        ThirdValue
    }

    void Start()
    {
        SimpleEnums simpleEnum = SimpleEnums.SecondValue;
        int convertedEnum = simpleEnum as int;
        /* Uncomment the line above ↑ to see the error
         */

    }
}


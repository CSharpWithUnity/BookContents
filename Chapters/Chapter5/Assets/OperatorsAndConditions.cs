/*
 * Chapter 5.8 Operators and Conditions
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

using UnityEngine;

public class OperatorsAndConditions : MonoBehaviour
{
    /*
     * Section 5.8 Operators and Conditions
     */
    private void Start()
    {
        float temp = 90f;
        bool sunny = true;
        if (temp > 70f && sunny)
        {
            Debug.Log("Time to go swimming!");
        }
    }
}


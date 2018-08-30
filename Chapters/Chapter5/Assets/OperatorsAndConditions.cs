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

    private void Start()
    {
        /*
         * Section 5.8 Operators and Conditions
         */
        float temp = 90f;
        bool sunny = true;
        if (temp > 70f && sunny)
        {
            Debug.Log("Time to go swimming!");
        }
        /*
         * Section 5.8.1.1 A Basic Example
         */
        if (true)
        {
            if (true)
            {
                Debug.Log("this could be more simple.");
            }
        }

        if (true && true)
        {
            Debug.Log("Both sides of && are true");
        }

        if (false && true)
        {
            Debug.Log("I won't print.");
        }

        if (true && false)
        {
            Debug.Log("I won't print either.");
        }

        if (true && true && true)
        {
            Debug.Log("I'll print!");
        }

        if (true && true && true && true && true && true && true && true && false)
        {
            Debug.Log("Nope, one case is false!");
        }
        /*
         * or is the double || called a double bar.
         * this key is usually over the the \ key
         * near the far right of the keyboard after
         * the { and } keys.
         */
        if (false || false)
        {
            Debug.Log("I won't print.");
        }

        if (true || false)
        {
            Debug.Log("I'll print!");
        }

        if (false || false || true)
        {
            Debug.Log("I will print, at least one case is true.");
        }

        if (false || false || false || false || false || false || false || true)
        {
            Debug.Log("it just takes one case to be true to print me.");
        }
        /*
         * Mixing between || and &&
         * can get a bit more confusing.
         */


        if (false || true && true)
        {
            Debug.Log("yes, i'll print.");
        }
        /*
         * this statement is equivalent to the above
         * but the () makes it a bit more clear.
         * 
         * (false || true) = true;
         * so thus
         * (true) && true = true;
         * 
         */
        if ((false || true) && true)
        {
            Debug.Log("I'll print.");
        }
        {
            /*
             * doing some basic logic
             */
            int enemyHealth = 10;
            int myHealth = 1;
            bool ImStronger = myHealth > enemyHealth;
            if (ImStronger)
            {
                Debug.Log("I can win!");
            }
        }
        {
            /*
             * a case for or ||
             */
            int enemyHealth = 10;
            int myHealth = 1;
            bool ImStronger = myHealth > enemyHealth;
            int enemyBullets = 0;
            int myBullets = 11;
            bool ImArmed = myBullets > enemyBullets;
            if (ImStronger || ImArmed)
            {
                Debug.Log("I can win!");
            }
        }
    }
    GameObject target;
    void Update()
    {
        {
            /*
             * Section 5.8.2 What We've Learned
             */
            bool isAbove = target.transform.position.y > transform.position.y;
        }
        {
            /*
             * Section 5.8.2 continued...
             */
            bool isAbove = target.transform.position.y > transform.position.y;
            bool isInfront = target.transform.position.z > transform.position.z;
            bool isInfrontAndAbove = isAbove && isInfront;
        }
        {
            /*
             * Section 5.8.2 continued again...
             */
            bool isAbove = target.transform.position.y > transform.position.y;
            bool isInfront = target.transform.position.z > transform.position.z;
            bool isInfrontAndAbove = isAbove && isInfront;
            bool isLeft = target.transform.position.x < transform.position.x;
            bool isInfrontAndAboveAndLeft = isInfrontAndAbove && isLeft;
            bool isInfrontAndAboveAndRight = isInfrontAndAbove && !isLeft;

        }
        {
            bool isInfrontAndAboveAndRight = target.transform.position.y >
            transform.position.y && target.transform.position.z > transform.position.z &&
            !(target.transform.position.x < transform.position.x);
        }
    }
}


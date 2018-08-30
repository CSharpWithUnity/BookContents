/*
 * Chapter 5.7 Jump Statements
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

 using UnityEngine;

public class JumpStatements : MonoBehaviour
{
    /*
     * Section 5.7.1 Return
     * void is like a return type
     * only, it's used to return
     * nothing.
     */
    void Function()
    {
    }

    void MyFunction()
    {
        // code here...
        return;
    }

    /*
     * the int is the return type
     * for this function
     */
    int MyIntFunction()
    {
        //return 1.0f;
        return 1; // 1 is an int
    }

    /*
     * Section 5.7.1.1 A Basic Example.
     * 
     * rather than void you use the
     * return type.
     */
    int MyNumber()
    {
        return 7;
    }

    /*
     * arguments turn into
     * values to use
     * in the return.
     */
    int MyAdd(int a, int b)
    {
        return a + b;
    }

    void Start()
    {
        {
            int a = MyNumber();
            Debug.Log(a);

            int add = MyAdd(6, 7);
            Debug.Log(add);

            // or even shorter...
            Debug.Log(MyAdd(11, 12));
        }
        {
            /*
             * Section 5.7.2 Returning Objects continued...
             */
            myZombie = GetZombie();
            Debug.Log(myZombie);
        }
    }

    /*
     * Section 5.7.2 Returning Objects
     */
    public Zombie myZombie;
    Zombie GetZombie()
    {
        return (Zombie)FindObjectOfType(typeof(Zombie));
    }

    void Update()
    {
        /* First method to draw a line to a zombie.
         */

        //Debug.DrawLine(transform.position, myZombie.transform.position);

        /*
         * A Slightly more interesting way to draw a line to a zombie.
         */
        if (Zombie.numZombies > 0)
        {

            Debug.DrawLine(transform.position, GetZombie().transform.position);
        }

        /*
         * we can add a null check to
         * see if the zombie exists
         */
        Zombie target = GetZombie();
        if (target != null)
            Debug.Log(target);
    }
}
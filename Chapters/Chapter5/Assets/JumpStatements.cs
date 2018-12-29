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
    #region Chapter 5.7.1 Return
    /* * * * * * * * * * * * * * * * * * * * *
     * Section 5.7.1 Return                  *
     * * * * * * * * * * * * * * * * * * * * */

    /* void is like a return type            *
     * only, it's used to return             *
     * nothing.                              */
    void Function()
    {
    }

    void MyFunction()
    {
        // code here...
        return;
    }

    /* the int is the return type           *
     * for this function                    */
    int MyIntFunction()
    {
        //return 1.0f;
        return 1; // 1 is an int
    }

    void UseReturn()
    {
        int a = MyNumber();
        Debug.Log(a);

        int add = MyAdd(6, 7);
        Debug.Log(add);

        // or even shorter...
        Debug.Log(MyAdd(11, 12));
    }
    #endregion

    #region Chapter 5.7.1.1 A Basic Example
    /* * * * * * * * * * * * * * * * * * * * *
     * Section 5.7.1.1 A Basic Example.      *
     * * * * * * * * * * * * * * * * * * * * */

    /* rather than void you use the          *
     * return type.                          */
    int MyNumber()
    {
        return 7;
    }

    /* arguments turn into                   *
     * values to use                         *
     * in the return.                        */
    int MyAdd(int a, int b)
    {
        return a + b;
    }
    #endregion

    #region Chapter 5.7.2 Returning Objects
    /* * * * * * * * * * * * * * * * * * * * *
     * Section 5.7.2 Returning Objects       *
     * * * * * * * * * * * * * * * * * * * * */
    public Zombie myZombie;
    Zombie GetZombie()
    {
        return (Zombie)FindObjectOfType(typeof(Zombie));
    }

    void UseReturnZombie()
    {
        myZombie = GetZombie();
        Debug.Log(myZombie);
    }
    #endregion

    #region Chapter 5.7.4 Tuples
    /* * * * * * * * * * * * * * * * * * * * *
     * Section 5.7.4 Tuples                  *
     * * * * * * * * * * * * * * * * * * * * */

    /* lua could return more than one value            *
     *                                                 *
     * function ReturnsMultipleValues()                *
     *  return "SomeString", 1 end                     *
     *                                                 *
     * the Lua above would return a string and an int! */

    struct ZombieNumber
    {
        public Zombie Zombie;
        public int SomeNumber;
    }
    /* one way to return a complex data type            *
     * is to return a struct                            */
    ZombieNumber RetrunsZombieAndNumber()
    {
        ZombieNumber zombieNumber = new ZombieNumber();
        zombieNumber.Zombie = (Zombie)FindObjectOfType(typeof(Zombie));
        zombieNumber.SomeNumber = 1;
        return zombieNumber;
    }

    void UseRetrunsZombieAndNumber()
    {
        ZombieNumber zn = RetrunsZombieAndNumber();
        Debug.Log("Zombie: " + zn.Zombie + " Num:" + zn.SomeNumber);
        // Zombie: ZombiePrimitive (Zombie) Num:1

        /* This does return more than one type but it's bundled  *
         * in a struct                                           */
    }

    /* a more compact method to return a complex data type is    *
     * by declaring a tuple with the leading                     *
     * ( type identifier, type identifier)                       *
     * return value                                              */
    (Zombie zombie, int number) ReturnsTuple()
    {
        Zombie z = (Zombie)FindObjectOfType(typeof(Zombie));
        int n = 1;
        var zombieNumber = (zombie: z, number: n);
        return zombieNumber;
    }

    void UseReturnsTuple()
    {
        var zn = ReturnsTuple();
        Debug.Log("Zombie:" + zn.zombie + " Num:" + zn.number);
        // Zombie: ZombiePrimitive (Zombie) Num:1

        /* accomplishes the same as a struct but without        *
         * creating a new data type                             */
    }

    (string outString, int outInt, float outFloat ) ReturnsStringIntFloat()
    {
        return (outString: "SomeString", outInt: 1, outFloat: 1f);
    }

    void UseReturnsStringIntFloat()
    {
        Debug.Log(ReturnsStringIntFloat());
        // (SomeString, 1, 1)
    }
    #endregion

    void Start()
    {
        /* * * * * * * * * * * * * * * * * * * * *
         * Section 5.7.1 Return                  *
         * * * * * * * * * * * * * * * * * * * * */
        UseReturn();

        /* * * * * * * * * * * * * * * * * * * * * * * * 
         * Section 5.7.2 Returning Objects continued...*
         * * * * * * * * * * * * * * * * * * * * * * * */
        UseReturnZombie();

        /* * * * * * * * * * * * * * * * * * * * *
         * Section 5.7.4 Tuples                  *
         * * * * * * * * * * * * * * * * * * * * */
        UseRetrunsZombieAndNumber();
        UseReturnsTuple();
        UseReturnsStringIntFloat();
    }

    void Update()
    {
        /* First method to draw a line to a zombie. */
        //Debug.DrawLine(transform.position, myZombie.transform.position);

        /* A Slightly more interesting way          *
         * to draw a line to a zombie.              */
        if (Zombie.numZombies > 0)
        {
            Debug.DrawLine(transform.position, GetZombie().transform.position);
        }

        /* we can add a null check to  *
         * see if the zombie exists    */
        Zombie target = GetZombie();
        if (target != null)
            Debug.Log(target);
    }
}
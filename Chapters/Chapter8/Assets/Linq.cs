/*
 * Chapter 8.8 LINQ
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Linq : MonoBehaviour
{
    /*
     * Section 8.8.1 Lambdas and Arrays
     * 
     * Observe above in the header we
     * include 'using System.Linq;'
     * this adds some new keywords!
     */
    void UseLinqOnArray()
    {
        int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var evenNums = from n in numbers
                       where (n % 2) == 0
                       select n;
        // Linq adds the keywords, from
        // where and select.
        foreach (int n in evenNums)
        {
            Debug.Log(n);
        }
        // 0
        // 2
        // 4
        // 6
        // 8
        // 10
    }

    /*
     * Section 8.8.2 Var
     */
    void UseVar()
    {
        var aThingHere = 7;
        var anotherThingThere = (object)19;
        var aDifferetThing = (float)23;

        System.Type firstType = aThingHere.GetType();
        System.Type secondType = anotherThingThere.GetType();
        System.Type thirdType = aDifferetThing.GetType();

        Debug.Log(firstType);
        // System.Int32
        Debug.Log(secondType);
        // System.Int32
        Debug.Log(thirdType);
        // System.Single

        var someThing = 1;
        var anotherThing = new GameObject();
        Debug.Log(someThing.GetType());
        /* uncomment the line below to see the */
        /* error from the assignment.          */
        //someThing = anotherThing;
    }

    /*
     * Section 8.8.3 Linq From
     */
    class Zombie
    {
        public int hitPoints;
        public Zombie()
        {
            hitPoints = UnityEngine.Random.Range(1, 100);
        }
    }

    void UseFindZombies()
    {
        // make a bunch of zombies
        Zombie[] zombieArray = new Zombie[100];
        for (int i = 0; i < 100; i++)
        {
            zombieArray[i] = new Zombie();
        }

        // select weak zombies;
        var weakZombies = from z in zombieArray
                          where z.hitPoints < 50
                          select z;

        foreach (Zombie z in weakZombies)
        {
            Debug.Log(z.hitPoints);
        }
        // a bunch of numbers < 50!
    }

    /*
     * Section 8.8.4 Strange Behavior in Linq
     */
    void UseStrangeBehaviour()
    {
        //declare an array
        int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var divisibleByThree = from n in numbers 
                   /*  └───┐ */where (n % 3) == 0
                   /*      │ */select n;
        numbers[0] = 1;/*  │ */
        numbers[3] = 1;/*  │  changes made to numbers not to         */
        numbers[6] = 30;/* │  divisibleByThree but divisibleByThree  */
        numbers[9] = 300;/*↓  still knows it's function              */
        foreach (int i in divisibleByThree)
        {
            Debug.Log(i);
        }
        // 30
        // 300

        /* the updated values
         * are captured in the
         * Debug even after the
         * Linq operation was
         * invoked on the numbers
         */
        numbers[0] = 3000;
        numbers[1] = 30000;
        Debug.Log("look again!");
        foreach (int i in divisibleByThree)
        {
            Debug.Log(i);
        }
        // 3000
        // 30000
        // 30
        // 300
    }

    /*
     * Section 8.8.5 Linq on Lists
     */
    void UseLinqOnLists()
    {
        {
            int[] setA = { 1, 2, 3, 4 };
            int[] setB = setA.Where(x => x % 2 == 0).ToArray();
            foreach (int i in setB)
            {
                Debug.Log(i);
            }
            // 2
            // 4
        }
        {
            int[] setA = { 1, 2, 3, 4 };
            
            // Lambda
            Func<int, bool> even = (x) => { return x % 2 == 0; };
            
            int[] setB = setA.Where(even).ToArray();
            foreach (int i in setB)
            {
                Debug.Log(i);
            }
            // 2
            // 4
        }

        {
            int[] setA = { 1, 1, 2, 2, 3, 3, 4, 4 };
            List<int> setB = setA.Distinct().ToList();
            // Distinct removes repeated values
            foreach (int i in setB)
            {
                Debug.Log(i);
            }
            // 1
            // 2
            // 3
            // 4
        }
        {
            int[] setA = { 1, 2, 3, 4 };
            int[] setB = { 3, 4, 5, 6 };
            int[] setC = setA.Union(setB).Distinct().ToArray();
            foreach (int i in setC)
            {
                Debug.Log(i);
            }
            // 1
            // 2
            // 3
            // 4
            // 5
            // 6
        }
        {
            int[] setA = { 1, 2, 3, 4 };
            int[] setB = { 3, 4, 5, 6 };
            int[] setC = setA.Except(setB).Distinct().ToArray();
            foreach (int i in setC)
            {
                Debug.Log(i);
            }
            // 1
            // 2
            int[] setD = setB.Except(setA).Distinct().ToArray();
            foreach (int i in setD)
            {
                Debug.Log(i);
            }
            // 5
            // 6
        }
    }

    void Start()
    {
        /*
         * Section 8.8.1 Lambdas and Arrays
         * 
         * uncomment the line below to see
         * the function in action.
         */
        //UseLinqOnArray();

        /*
         * Section 8.8.2 Var
         * 
         * uncomment the line below to see
         * the function in action.
         */
        //UseVar();

        /*
         * Section 8.8.2 Var
         * 
         * uncomment the line below to see
         * the function in action.
         */
        //UseFindZombies();

        /*
         * Section 8.8.2 Var
         * 
         * uncomment the line below to see
         * the function in action.
         */
        //UseStrangeBehaviour();

        /*
         * Section 8.8.2 Var
         * 
         * uncomment the line below to see
         * the function in action.
         */
        UseLinqOnLists();
    }
}

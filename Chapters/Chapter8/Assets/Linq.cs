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
            // Distinct removes repeated values
            List<int> setB = setA.Distinct().ToList();
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

            // union merges the two lists together
            // distinct removes duplicates
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
            
            // only shows things unique to setA
            int[] setC = setA.Except(setB).Distinct().ToArray();
            foreach (int i in setC)
            {
                Debug.Log(i);
            }
            // 1
            // 2

            // only shows objects unique to setB
            int[] setD = setB.Except(setA).Distinct().ToArray();
            foreach (int i in setD)
            {
                Debug.Log(i);
            }
            // 5
            // 6
        }
    }
    
    public enum Alignments
    {
        Good,
        Neutral,
        Evil
    }

    class Monster
    {
        public string Name;
        public int HP;
        public Alignments Alignment;
        public Vector3 Position;
        public Monster()
        {
            string[] nameParts = { "Ba", "Ga", "Da", "Wa", "Pa", "Na", "La", "Ta", "Fa" };
            Name = "";
            for (int i = 0; i < 2; i++)
            {
                int p = UnityEngine.Random.Range(0, nameParts.Length);
                Name += nameParts[p];
            }
            Alignment = (Alignments)UnityEngine.Random.Range(0, 3);
            HP = UnityEngine.Random.Range(1, 11);
        }
    }

    class MonsterNameComparer : IEqualityComparer<Monster>
    {
        public bool Equals(Monster x, Monster y)
        {
            return x.Name.Equals(y.Name);
        }

        public int GetHashCode(Monster obj)
        {
            return obj.Name.GetHashCode();
        }
    }

    class MonsterAlignmentComparer : IEqualityComparer<Monster>
    {
        public bool Equals(Monster x, Monster y)
        {
            return x.Alignment == y.Alignment;
        }

        public int GetHashCode(Monster obj)
        {
            return obj.Alignment.GetHashCode();
        }
    }
    class MonsterNameAlignmentComparer : IEqualityComparer<Monster>
    {
        public bool Equals(Monster x, Monster y)
        {
            return x.Name.Equals(y.Name) && x.Alignment == y.Alignment;
        }

        public int GetHashCode(Monster obj)
        {
            return obj.Name.GetHashCode() + obj.Alignment.GetHashCode();
        }
    }

    void UseComparer()
    {
        int numMonsters = 100;
        Monster[] monsters = new Monster[numMonsters];
        for (int i = 0; i < numMonsters; i++)
        {
            monsters[i] = new Monster(); 
        }
        {
            /* This produces a list of all 100 monsters
             * they are grouped together based on their
             * names and alignments. */

            Monster[] sorted = monsters.OrderBy(m => m.Alignment.GetHashCode() + m.Name.GetHashCode()).ToArray();
            string log = "";
            int count = 1;
            foreach (Monster m in sorted)
            {
                log += count++ + ") name: " + m.Name + " " + m.Alignment + "\n";
            }
            Debug.Log(log);
            {
                Monster[] strongMonsters = monsters.Where(x => x.HP > 9 ).ToArray();
                string l = "strongMonsters: \n";
                count = 1;
                foreach (Monster m in strongMonsters)
                {
                    l += count++ + ") " + m.Name + " " + m.HP + "\n";
                }
                Debug.Log(l);
            }
            {
                var strongMonsters = from monster in monsters
                           where monster.HP > 9
                           select monster;

                string l = "strongMonsters: \n";
                count = 1;
                foreach (Monster m in strongMonsters)
                {
                    l += count++ + ") " + m.Name + " " + m.HP + "\n";
                }
                Debug.Log(l);
            }
        }


        {
            /* this will use the Name Comparer to filter out    */
            /* monsters with the same name                      */
            Monster[] unique = monsters.Distinct(new MonsterNameComparer()).ToArray();

            //about a third of the names will be removed.
            string log = "";
            int count = 1;
            foreach (Monster m in unique)
            {
                log += count++ + ") name: " + m.Name + " " + m.Alignment + "\n";
            }
            Debug.Log(log);
        }

        {   /* this will use the Name Comparer to filter out    */
            /* monsters with the same name                      */
            Monster[] unique = monsters.Distinct(new MonsterNameComparer()).OrderBy(x => x.Name.GetHashCode() ^ x.HP).ToArray();

            //about a third of the names will be removed.
            string log = "";
            int count = 1;
            foreach (Monster m in unique)
            {
                log += count++ + ") name: " + m.Name + " " + m.Alignment + "\n";
            }
            Debug.Log(log);
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
        //UseLinqOnLists();
        UseComparer();
    }
}

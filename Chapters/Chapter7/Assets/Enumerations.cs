/*
 * Chapter 7.13 Enumerations
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

using UnityEngine;
using System.Collections;

public class Enumerations : MonoBehaviour
{
    /*
     * Section 7.13.1 Enumerators: a basic Example
     * observe using System.Collections;
     * in the header preceeding the class declaration
     * this includes the Enumerator type.
     */
    int[] intArray = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
    void UseIntEnumerator()
    {
        IEnumerator intEnumerator = intArray.GetEnumerator();
        while (intEnumerator.MoveNext())
        {
            Debug.Log("Current int: " + intEnumerator.Current);
        }
        // Current int: 10
        // Current int: 20
        // Current int: 30
        // Current int: 40
        // Current int: 50
        // Current int: 60
        // Current int: 70
        // Current int: 80
        // Current int: 90
        // Current int: 100
    }

    void UseWithoutLoop()
    {
        IEnumerator intEnumerator = intArray.GetEnumerator();

        intEnumerator.MoveNext();
        Debug.Log("Current int: " + intEnumerator.Current);
        // Current int: 10

        intEnumerator.MoveNext();
        Debug.Log("Current int: " + intEnumerator.Current);
        // Current int: 20

        intEnumerator.MoveNext();
        Debug.Log("Current int: " + intEnumerator.Current);
        // Current int: 30
        
        intEnumerator.MoveNext();
        Debug.Log("Current int: " + intEnumerator.Current);
        // Current int: 40
    }

    void UseIfToIterate()
    {
        int[] someInts = new int[] { 1, 3, 7 };
        IEnumerator intEnumerator = someInts.GetEnumerator();
        if (intEnumerator.MoveNext())
        {
            Debug.Log("Current int: " + intEnumerator.Current);
        }
        if (intEnumerator.MoveNext())
        {
            Debug.Log("Current int: " + intEnumerator.Current);
        }
        if (intEnumerator.MoveNext())
        {
            Debug.Log("Current int: " + intEnumerator.Current);
        }
        if (intEnumerator.MoveNext())
        {
            Debug.Log("I won't get called.");
        }
    }
    /*
     * Section 7.13.1.2 What doesn't work
     */
    void UseStringArray()
    {
        string[] strings = new string[] { "A", "B", "C" };
        IEnumerator strEnumerator = strings.GetEnumerator();
        //foreach (string s in strEnumerator)
        //{
        //    Debug.Log(s);
        //}
        /* uncomment the above to see the error */

        string[] stringsB = new string[] { "A", "B", "C" };
        IEnumerator strBEnumerator = stringsB.GetEnumerator();
        //Debvug.Log(strBEnumerator.Current);
    }

    /*
     * Section 7.13.2 Implementing an IEnumerator
     */
    class IZombieEnumerator : IEnumerator
    {
        private string[] Minions;
        private int NextMinion;
        public object Current
        {
            get
            {
                return Minions[NextMinion];
            }
        }
        public bool MoveNext()
        {
            NextMinion++;
            return NextMinion >= Minions.Length;
        }

        public void Reset()
        {
            NextMinion = -1;
        }
    }

    class EnumerableZombie : IEnumerable
    {
        public IZombieEnumerator Enumerator;
        public string Name;
        public EnumerableZombie(string name)
        {
            Name = name;
            Enumerator = new IZombieEnumerator();
        }
        public IEnumerator GetEnumerator()
        {
            return Enumerator;
        }
    }


    void Start()
    {
        //UseIntEnumerator();
        //UseWithoutLoop();
        //UseIfToIterate();
        UseStringArray();
    }

}

/*
 * Chapter 4.6 Functions
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functions : MonoBehaviour
{
    /* * * * * * * * * * * * * * * * * * *
     * Section 4.6.1 What Are Functions? *
     * * * * * * * * * * * * * * * * * * */

    void Wash()
    {
    }
    void Rinse()
    {
    }
    void Repeat()
    {
    }

    int myNumber;
    public void PrintMyNumber()
    {
        Debug.Log(myNumber);
    }

	// Use this for initialization
	void Start ()
    {
        /* * * * * * * * * * * * * * * *
         * Section 4.6.1 continued...  *
         * * * * * * * * * * * * * * * */

        Wash();
        Rinse();
        Repeat();

        /* * * * * * * * * * * * * * * *
         * Section 4.6.2 Entry Points  *
         * * * * * * * * * * * * * * * */

        Debug.Log("Start");

        // from Section 4.6.3
        CheckOnA();
	}

    /* * * * * * * * * * * * * * * * * * *
     * Section 4.6.3 Writing a Function  *
     * * * * * * * * * * * * * * * * * * */

    void MyFunction()
    {
    }

    /* A function that this class can call */

    public void MyPublicFunction()
    {
    }

    /* A function this class and others can call */

    public int MyIntFunction()
    {
        return 1;
    }

    /* A function that can give you a number */

    public void MyArgFunction(int i)
    {
    }

    void SimpleFunction()
    {
        Debug.Log("Simple function called.");
    }

	// Update is called once per frame
	void Update ()
    {
        SimpleFunction();
        ATimesA();
	}

    /* * * * * * * * * * * * * * * *
     * Section 4.6.3 continued...  *
     * * * * * * * * * * * * * * * */

    int a = 0;

    void SetAToThree()
    {
        a = 3;
    }

    void CheckOnA()
    {
        Debug.Log(a);
        SetAToThree();
        Debug.Log(a);
    }

    /* * * * * * * * * * * * * * * * * * *
     * Section 4.6.4 More on White Space *
     * * * * * * * * * * * * * * * * * * */

    void MoreTabs()
    {
        //tabbed over once!
        int i = 0;
        //while statement tabbed over as well
        while (i < 10)
        {
            //tabbed over even more
            Debug.Log(i);
            i++;
        }
    }

    void ATimesA()
    {
        a = a * a;
    }
}

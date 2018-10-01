/*
 * Chapter 6.19 Ref Parameter
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using UnityEngine;

public class RefParameter : MonoBehaviour
{   /*
     * Section 6.19 Ref Parameter
     */
    void ValueAssignments()
    {
        int x = 1; /* Initial assignment of the value 1 is put into x  */
        /*  └─1→┐     the value of x is 1                              */
        int y = x; /* the value 1 in x is copied into y                */
        /*  └←1─┘     y is assigned 1, the value from x                */
        /* no link to x has been made.                                 */
            y = 3; /* y is assigned 3, x is still 1                    */
        /*  └←3─┘                                                      */
        Debug.Log("x: " + x); // "x: 1"
        Debug.Log("y: " + y); // "y: 3"
    }


    /*
     * Section 6.19.1 Ref Parameter, A Basic Example.
     */
    void UseRefManipulateValue()
    {
        int x = 3;/* ══════════╗                            */
        int y = 3;/*           ║                            */
                  /*           ║                            */
        RefManipulateValue(ref x, y);
                  /*           ╚═══════════════╗            */
        Debug.Log("UsingRefManipulation: x:" + x + " y:" + y);
        /* "UsingRefManipulation: x: 4 y: 3                 */
    }
    void RefManipulateValue(ref int refValue, int notRefValue)
    {              /* linked to x      ║              │      */
        refValue++;/*↔ ════════════════╝  just value  │      */
        notRefValue++;/*← ────────────────────────────┘      */
    }
    void UseRefAndOut()
    {
        int x = 3;
        int y = 3;
        RefAndOut(ref x, out y);
        Debug.Log("UsingRefAndOut: x:" + x + " y:" + y);
        /* "UsingRefAndOut: x: 4 y: 1                 */

    }
    void RefAndOut(ref int refValue, out int outValue)
    {/*                      ↓ ↑               ↑    */
     /*  ┌───────────────────┘ │               │    */
     /*  ↓                     │               │    */
        refValue++;/*          │               │    */
     /*  ↓                     │               │    */
     /*  └─────────────────────┘               │    */
        outValue = 0;/* new value created      │    */
        outValue++;  /*────────────────────────┘    */
    }

    void UseRefAndInAndOut()
    {
        int x = 1;
        int y = 1;
        int z = 1;
        RefAndInAndOut(ref x, y, out z);
        Debug.Log("UsingRefAndInAndOut: x:" + x + " y:" + y + " z:" + z );
        /*"UsingRefAndInAndOut x: 2 y: 1 z: 2"                    */
    }
    void RefAndInAndOut(ref int refValue, int value, out int outValue)
    {/*                            ↕            ↓               ↑ */
     /*    ┌───────────────────────┘            │               │ */
        refValue++;/*                           │               │ */
        /*           ┌──────────────────────────┘               │ */
        outValue = value + 1;/*                                 │ */
    }/*    └────────────────────────────────────────────────────┘ */
    
    /*
     * Section 6.19.2 Code Portability, Side Effects
     */
    public int publicX;/*←┐                        */
    void IncrementX()  /* │ directly manipulate    */
    {                  /* │ class wide variable.   */
        publicX += 1;  /*←┘                        */
    }
    /*
     * code copied from OutParameter, and using ref.
     */
    bool SortDistanceFromObject(GameObject target, ref GameObject[] sortableObjects)
    {
        int len = sortableObjects.Length;
        for (int i = 0; i < len; i++)
        {
            int restLen = len - i - 1;
            /* start at the beginning of the array */
            for (int j = 0; j < restLen; j++)
            {
                /* then compare everyone against every other one */
                /* get positions of an object in the array  */
                /* and the following one.                   */
                Vector3 posA = sortableObjects[j].transform.position;
                Vector3 posB = sortableObjects[j + 1].transform.position;

                /* get the distance of each object from the target */
                float distA = (posA - target.transform.position).magnitude;
                float distB = (posB - target.transform.position).magnitude;

                /* compare distances */
                if(distA > distB)
                {
                    /* if B is further than A then swap them */
                    GameObject temp = sortableObjects[j];
                    sortableObjects[j] = sortableObjects[j + 1];
                    sortableObjects[j + 1] = temp;
                }
            }
        }
        return sortableObjects.Length > 0;
    }

    /*
     * Section 6.19.3 What we've learned
     */
    void OutFunction(out int outValue)
    {
        // outValue++;
        /* the above doesn't work since */
        /* it assumes outValue already  */
        /* has a value.                 */
        outValue = 7;
    }
    void UsingOutFunction()
    {
        int localInt;
        /*      └───────────┐                */
        /*                  ↓ unassigned int */
        OutFunction(out localInt);
        /*                  └────────┐       */
        /*          assigned value 7 ↓       */
        Debug.Log("localInt: " + localInt);
    }
    
    void RefFunction(ref int refValue)
    {
        refValue++;
    }
    void UsingRefFunction()
    {
        int localInt = 0;
        RefFunction(ref localInt);
        Debug.Log("UsingRefFunction: " + localInt);
    }
    void Start()
    {
        /*
         * Section 6.19 Ref Parameter
         */
        ValueAssignments();
        /*
         * Section 6.19.1 Ref Parameter, A Basic Example.
         */
        UseRefManipulateValue();
        UseRefAndOut();
        UseRefAndInAndOut();
        /*
         * Section 6.19.2 Code Portability, Side Effects
         */
        Debug.Log(publicX); // "0"
        IncrementX();
        Debug.Log(publicX); // "1"
        /*
         * Section 6.19.3 What We've Learned
         */
         int noValue;
         //noValue++;
         /* uncomment the line above to see the error */
         /* works the same way, you can't             */
         /* increment an int that has no value        */
         /* assigned yet.                             */
         /*                                           */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

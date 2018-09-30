/*
 * Chapter 6.18 Out Parameter
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using System.Collections;
using UnityEngine;

public class OutParameter : MonoBehaviour
{
    public GameObject AimPoint;
    int GetSeven()
    {
        return 7;
    }

    void GettingSeven()
    {
        int Seven = GetSeven();
    }

    ArrayList GetSevenEleven()
    {
        ArrayList list = new ArrayList();
        list.Add(7);

        list.Add(11);
        //list.Add("Eleven");//not an int?

        /* Switch the commented lines above
         * to see the error when the Start
         * function is called in Unity
         */
        return list;
    }

    void GettingSevenEleven()
    {
        ArrayList list = GetSevenEleven();
        int seven = (int)list[0];
        int eleven = (int)list[1];
    }


    /*
     * Section 6.18.1 Out Parameter, A Basic Example.
     */
    void GetSevenOut(out int seven)
    {/*  ┌←❶─────────────────←┘ ↑         */
        seven = 7; /*           │         */
    }/*  └→❷─────────────────→──┘         */
     /* ❶ seven comes in, gets assigned 7 */
     /* ❷ then is sent back out           */

    void GetThreeValuesOut(out int first, out int second, out int third)
    {/*   ┌←❶──────────────────────←┘ ↑            │ ↑             │ ↑  */
        first = 1;/* assigned 1       │            │ │             │ │  */
     /*   └→❷──────────────────────→──┘            │ │             │ │  */
     /*   ┌←❶──────────────────────←───────────────┘ │             │ │  */
        second = 2;/* assigned 2                     │             │ │  */
     /*   └→❷──────────────────────→─────────────────┘             │ │  */
     /*   ┌←❶──────────────────────←───────────────────────────────┘ │  */
        third = 3;/*  assigned 3                                     │  */
     /*   └→❷──────────────────────→─────────────────────────────────┘  */
    }


    void GoingInAndOut(int inValue, out int outValue)
    {/*              ┌←❶────←┘                 ↑    */
        outValue = inValue * 2;/*              │    */
     /*    └→❷────────────────────────────────→┘    */
    }/*  outValue is set to inValue multiplied by 2 */

    void Start()
    {
        {
            /*
             * Section 6.18 OutParameter
             */
            GettingSevenEleven();
            /* Showing various simple ways to get values from functions */
        }
        {
            /*
             * Section 6.18.1 Out Parameter, A Basic Example continued...
             */

            int i = 0;/* int i goes in as 0    */
            /*  └❶→─────────┐  i = 0           */
            GetSevenOut(out i);
            /*        ┌←❷───┘  i = 7           */
            Debug.Log(i);/* comes out as 7     */
        }
        {
            /* this works with multiple values               */
            int i, j, k;
            /*  │  │  └❶→───────────────────────┐            */
            /*  │  └❶→───────────────────┐      │            */
            /*  └❶→───────────────┐i = 0 │j = 0 │k = 0       */
            GetThreeValuesOut(out i, out j, out k);
            /*                ┌───┘i = 1 │j = 2 │k = 3       */
            /*                │          └─┐    └───────┐    */
            /*                ❷            ❷            ❷    */
            /*                ↓            ↓            ↓    */
            Debug.Log("i: " + i + " j: " + j + " k: " + k);
        }
        {
            int i = 0;
            /*  └❶→──────────────┐  i = 0           */
            GoingInAndOut(6, out i);
            /*        ┌←❷────────┘  i = 12          */
            Debug.Log(i);/* comes out as 12         */
        }
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit raycastHit;
            /*             └❶→────────────┐                                                   */
            if(Physics.Raycast( ray, out raycastHit))                     
            {/*       ↓                   │   hit value has a point                           */
             /* conditional statement     │   in the world where it hit something...          */
             /* if there's anything       │               ❷             ❸  and orientation of */
             /* actually hit by the ray   └───────────────┬─────────────┐  the surface it hit */
                AimPoint.transform.position = raycastHit.point;/*       ↓ */
                Quaternion normal = Quaternion.LookRotation(raycastHit.normal, AimPoint.transform.up);
                AimPoint.transform.rotation = normal;
            }
        }
    }
}

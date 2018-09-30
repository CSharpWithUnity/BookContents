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
            int i;
            GetSevenOut(out i);
            Debug.Log(i);
        }
    }
}

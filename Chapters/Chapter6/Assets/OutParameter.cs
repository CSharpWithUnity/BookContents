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
    {/*                        ↑          */
        seven = 7; /*          │          */
    }/*  └→❶─────────────────→─┘          */
     /* ❶ variable given to seven         */
     /*   gets assigned 7                 */

    void GetThreeValuesOut(out int first, out int second, out int third)
    {/*                              ↑              ↑               ↑   */
        first = 1;/* assigned 1      │              │               │   */
     /*   └→❷──────────────────────→─┘              │               │   */
     /*                                             │               │   */
        second = 2;/* assigned 2                    │               │   */
     /*   └→❷──────────────────────→────────────────┘               │   */
     /*                                                             │   */
        third = 3;/*  assigned 3                                    │   */
     /*   └→❷──────────────────────→────────────────────────────────┘   */
    }


    void GoingInAndOut(int inValue, out int outValue)
    {/*              ┌←❶────←┘                 ↑    */
        outValue = inValue * 2;/*              │    */
     /*    └→❷────────────────────────────────→┘    */
    }/*  outValue is set to inValue multiplied by 2 */
    
    /*
     * Section 6.18.2 Simple Sorting (Bubble Sort)
     */ 
    bool SortDistanceFromObject(GameObject target, GameObject[] unsorted, out GameObject[] sorted)
    {
        int len = unsorted.Length;
        for (int i = 0; i < len; i++)
        {
            /* start at the beginning of the array */
            for (int j = 0; j < len - i - 1; j++)
            {
                /* then compare everyone against every other one */
                /* get positions of an object in the array  */
                /* and the following one.                   */
                Vector3 posA = unsorted[j].transform.position;
                Vector3 posB = unsorted[j + 1].transform.position;

                /* get the distance of each object from the target */
                float distA = (posA - target.transform.position).magnitude;
                float distB = (posB - target.transform.position).magnitude;

                /* compare distances */
                if(distA > distB)
                {
                    /* if B is further than A then swap them */
                    GameObject temp = unsorted[j];
                    unsorted[j] = unsorted[j + 1];
                    unsorted[j + 1] = temp;
                }
            }
        }
        sorted = unsorted;
        return sorted.Length > 0;
    }
    /* first iteration on 5 items                   */
    /* a↔b means a compared to b                    */
    /* { a, b, c, d, e } len = 5                    */
    /*                                              */
    /*                   ┌─────────────────┐        */
    /*  i=0 j=[0..4]     │e gets calculated│        */
    /*  a↔b b↔c c↔d d↔e←─┤because its in   │        */
    /*                   │position [j+1]   │        */
    /*  i=1 j=[0..3]     └─────────────────┘        */
    /*  iteration 2                                 */
    /*  a↔b b↔c c↔d    ┌─────────────────────┐      */
    /*                 │   indicies compared:│      */
    /*  i=2 j=[0..2]   │ ❶ 0↔1 1↔2 2↔3 3↔4   │      */
    /*  iteration 3    │ ❷ 0↔1 1↔2 2↔3       │      */
    /*  a↔b b↔c        │ ❸ 0↔1 1↔2           │      */
    /*                 │ ❹ 0↔1               │      */
    /*  i=3 j=[0..1]   └─────────────────────┘      */
    /*  iteration 3                                 */
    /*  a↔b                                         */
    /*                                              */
    /*  i=4 j=[0..0]                                */
    /*  ...                                         */
    /*                                              */

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
        {
            (int a, int b, int c) GetThreeValuesOut()
            {
                return (a: 1, b: 2, c: 3);
            }
            /*                                                          */
            /*   ┌←❶───┐ a var gets assigned the tuple                  */
            var abc = GetThreeValuesOut();
            /*   │       one value contains all three members           */
            /*   └❷→───────────┬────────────────┬────────────────┐      */
            /*                 ↓                ↓                ↓      */
            Debug.Log("a: " + abc.a + " b: " + abc.b + " c: " + abc.c);
        }
    }

    private void Update()
    {
        /*
         * Section 6.18.2 Simple Sort (Bubble Sort)
         */

        /* make an array to sort */
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        ArrayList sphereList = new ArrayList();
        foreach(GameObject go in allObjects)
        {
            bool isSphere = go.name.Contains("Sphere");
            if(isSphere)
            {
                sphereList.Add(go);
            }
        }

        /* now we have some objects to sort*/
        GameObject[] spheres = new GameObject[sphereList.Count];
        /* copy the list to the array */
        sphereList.CopyTo(spheres);

        /* now send the unsorted array to the function, then get a sorted array out */
        if(SortDistanceFromObject(gameObject, spheres, out spheres))
        {
            int lineHeight = 1;
            foreach(GameObject go in spheres)
            {
                Vector3 up = new Vector3(){ y = lineHeight++ * 0.5f};
                Debug.DrawRay(go.transform.position, up, Color.red);
            }
        }
    }
}

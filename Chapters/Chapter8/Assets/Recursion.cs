/*
 * Chapter 8.6 Recursion
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recursion : MonoBehaviour
{
    /*
     * Section 8.6 Recursion
     */
    void UseLoops()
    {
        {   //for loop
            for (int i = 0; i < 10; i++)
            {
                Debug.Log("for:" + i);
            }
        }

        {   // while loop
            int i = 0;
            while (i < 10)
            {
                Debug.Log("while:" + i);
                i++;
            }
        }

        {   // do loop
            int i = 0;
            do
            {
                Debug.Log("do:" + i);
                i++;
            } while (i < 10);
        }

        {   // foreach loop
            int[] ints = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach (int i in ints)
            {
                Debug.Log("foreach:" + i);
            }
        }

        {   // enumerator
            int[] ints = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            IEnumerator enumerator = ints.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Debug.Log("enumerator:" + enumerator.Current);
            }
        }

        {   // goto
            int i = 0;
        BEGIN:
            if (i < 10)
            {
                Debug.Log("goto:" + i);
                i++;
                goto BEGIN;
            }
        }
    }

    /*
     * Section 8.6.1 Recursion : A Basic Example
     */
    void UseRecursion()
    {
        // begin function  /*                               */
        recurse(0);        /* ↓ start recurse               */
        void recurse(int i)/* ← ────────────┐               */
        {                  /*               │               */
            if (i < 10)    /* ↓ check i     │ ┌──────────┐  */
            {              /*               ├─┤start over│  */
                Debug.Log("recurse:" + i);/*│ └──────────┘  */
                i++;       /* ↓ iterate i   │               */
                recurse(i);/* → ────────────┘               */
            }              /*                               */
        }                  /*                               */
    }

    /*
     * Section 8.6.2 Understanding Recursion
     */
    void UseUnderstandingRecursion()
    {
        {
            int i = 11;

            if (i > 10)
            {
                Debug.Log(i);
                i++;
                // code isn't
                // reached.
            }
        }
        {
            CountDownRecursion(10);

            void CountDownRecursion(int i)
            {
                Debug.Log(i);
                if (i > 0)
                {
                    i--;
                    // Only called when
                    // the if statement
                    // is true.
                    CountDownRecursion(i);
                }
            }
        }
    }

    /*
     * Section 8.6.3 In Practice
     */
    void UseHierarchy()
    {
        GameObject top = new GameObject("6_0");
        CreateHierarchy(top, 5);
        void CreateHierarchy(GameObject parent, int a)
        {
            GameObject[] subObjs = new GameObject[a];
            int b = 0;
            while (b < a)
            {
                subObjs[b] = new GameObject(a + "_" + b);
                subObjs[b].transform.SetParent(parent.transform);
                b++;
            }

            // decrease the iterations
            a--;
            foreach (GameObject sub in subObjs)
            {
                CreateHierarchy(sub, a);
            }
        }

        LogObjects(top.transform);
        void LogObjects(Transform a)
        {
            Debug.Log(a.gameObject.name);
            foreach (Transform b in a)
            {
                LogObjects(b);
            }
        }
    }

    GameObject hub;
    void UseObjectHieararchy()
    {
        hub = new GameObject("hub");
        CreateHierarchy(hub, 5);
        void CreateHierarchy(GameObject parent, int a)
        {
            GameObject[] subObjs = new GameObject[a];
            int b = 0;
            while (b < a)
            {
                subObjs[b] = GameObject.CreatePrimitive(PrimitiveType.Cube);
                subObjs[b].name = a + "_" + b;
                subObjs[b].transform.SetParent(parent.transform);
                subObjs[b].transform.localEulerAngles = new Vector3()
                {
                    x = 0,
                    y = (360 / a) * b,
                    z = 0
                };
                subObjs[b].transform.localPosition = new Vector3()
                {
                    x = 1 * a + b,
                };
                b++;
            }

            // decrease the iterations
            a--;
            foreach (GameObject sub in subObjs)
            {
                CreateHierarchy(sub, a);
            }
        }
    }

    void RotateHierarchy(Transform a)
    {
        a.transform.Rotate(new Vector3()
        {
            y = 0.5f
        });
        foreach (Transform b in a)
        {
            RotateHierarchy(b);
        }
    }

    /*
     * Section 8.6.4 Recursion Types
     * 
     * this will produce a list of 326 objects
     * if the UseObjectHieararchy() is called
     * just before the list is built.
     */

    void UseListBuilder()
    {
        ArrayList GetList(GameObject go)
        {
            ArrayList list = new ArrayList();
            BuildList(go, list);
            return list;
        }

        void BuildList(GameObject go, ArrayList list)
        {
            list.Add(go);
            foreach (Transform t in go.transform)
            {
                BuildList(t.gameObject, list);
            }
        }

        ArrayList arrayList = GetList(hub);
        Debug.Log(arrayList.Count);
        foreach (GameObject g in arrayList)
        {
            Debug.Log(g);
        }
    }
    void Start()
    {
        /*
         * Section 8.6 Recursion
         * 
         * Uncomment the line below to see the
         * process in action.
         */
        //UseLoops();

        /*
         * Section 8.6.1 Recursion : A Basic Example
         * 
         * Uncomment the line below to see the
         * process in action.
         */
        //UseRecursion();

        /*
         * Section 8.6.2 Understanding Recursion
         * 
         * Uncomment the line below to see the
         * process in action.
         */
        //UseUnderstandingRecursion();

        /*
         * Section 8.6.3 In Practice
         * 
         * Uncomment the line below to see the
         * process in action.
         */
        //UseHierarchy();
        UseObjectHieararchy();

        /*
         * Section 8.6.4 Recursion Types
         * 
         * Uncomment the line below to see the
         * process in action.
         * 
         * use this function after
         * the UseObjectHierarchy()
         * function has been called.
         * and the list generated
         * will be populated with
         * the objects in the hierarchy
         */
        UseListBuilder();
    }

    void Update()
    {
        /*
         * Section 8.6.3 In Practice
         * 
         * Uncomment the line below to see the
         * process in action.
         */
        RotateHierarchy(hub.transform);
    }
}

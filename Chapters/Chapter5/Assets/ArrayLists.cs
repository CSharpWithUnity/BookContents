/*
 * Chapter 5.12 ArrayLists
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using System.Collections;
using UnityEngine;

public class ArrayLists : MonoBehaviour
{
    public GameObject[] gameObjects;
    public GameObject specificObject;
    public int[] messyInts = new int[] { 12, 14, 6, 1, 0, 123, 92, 8 };
    private void Start()
    {
        {
            /*
             * Section 5.12 ArrayList
             */
            ArrayList arrayList = new ArrayList();
            int[] primeNumbers = new int[] { 1, 3, 5, 7, 11, 13, 17 };
            int i = 3;
            arrayList.Add(i);
            Debug.Log(arrayList[0]);
        }

        {
            /*
             * Section 5.12.1 A Basic Example
             */
            ArrayList arrayList = new ArrayList();
            Object[] allObjects = FindObjectsOfType(typeof(Object));
            foreach (Object o in allObjects)
            {
                Debug.Log(o);
                //arrayList.Add(o);
            }
            foreach (Object o in allObjects)
            {
                GameObject go = o as GameObject;
                if (go != null)
                {
                    arrayList.Add(go);
                }
            }

            //initialize GameObjects Array
            //GameObject[] gameObjects = new GameObject[arrayList.Count];

            /* don't use a type definition
             * if there's a use of the name
             * gameObjects defined as a public
             * GameObjects[] that will show
             * up in the Inspector panel.
             */
            gameObjects = new GameObject[arrayList.Count];
            // copy the list to the array
            arrayList.CopyTo(gameObjects);
            foreach (GameObject go in gameObjects)
            {
                Debug.Log(go.name);
            }
            /*
             * Section 5.12.2 ArrayList.Contains();
             */
            if (arrayList.Contains(specificObject))
            {
                Debug.Log("SpecificObject:");
                Debug.Log(specificObject);
                Debug.Log("is in arrayList at index ");
                Debug.Log(arrayList.IndexOf(specificObject));

            }
            /*
             * Section 5.12.3 Remove
             */
            if (arrayList.Contains(specificObject))
            {
                arrayList.Remove(specificObject);
                //now update the list in the inspector panel
                gameObjects = new GameObject[arrayList.Count];
                arrayList.CopyTo(gameObjects);
            }
        }
        {
            /*
             * Section 5.12.4 Sort and Reverse
             */
            
            ArrayList sorted = new ArrayList();
            sorted.AddRange(messyInts);
            sorted.Sort();
            sorted.CopyTo(messyInts);

            sorted.Reverse();
            sorted.CopyTo(messyInts);
        }
        {
            /*
             * Section 5.12.5 What We've Learned
             */
            ArrayList arrayList = new ArrayList();
            arrayList.Add(123);
            arrayList.Add("strings");
        }
    }
}


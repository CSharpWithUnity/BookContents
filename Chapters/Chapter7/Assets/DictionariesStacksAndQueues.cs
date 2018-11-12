/*
 * Chapter 7.19 Dictionaries Stacks and Queues
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionariesStacksAndQueues: MonoBehaviour
{
    /*
     * Section 7.19.1 Dictionaries Stacks and Queues : A Basic Example
     */
    void UseDictionary()
    {
        Dictionary<string, int> MyDictionary = new Dictionary<string, int>();
        MyDictionary.Add("Zombies", 10);
        Debug.Log(MyDictionary["Zombies"]);
        // 10

        int[] UnnamedInts = new int[1] { 10 };
        Debug.Log(UnnamedInts[0]);
        // 10

        /*
         * This givex you an error!
         */
        //MyDictionary.Add("Zombies", 7);
        /* uncomment the line above to see the error below */
        // ArgumentException: An item with the same key has already been added. Key: Zombies

        {
            /*
             * Find all objects
             */
            Dictionary<int, UnityEngine.Object> intObjectPair = new Dictionary<int, UnityEngine.Object>();
            UnityEngine.Object[] allObjects = FindObjectsOfType<UnityEngine.Object>();
            for (int i = 0; i < allObjects.Length; i++)
            {
                intObjectPair.Add(i, allObjects[i]);
            }

            foreach (int i in intObjectPair.Keys)
            {
               Debug.Log("Number:" + i + " is " + intObjectPair[i]);
            }
            // finds 22 objects in the scene.

            Debug.Log(intObjectPair[0]);
            // NavMeshSettings (UnityEngine.NavMeshSettings)
            Debug.Log(intObjectPair[8]);
            // DictionariesStacksAndQueues (DictionariesStacksAndQueues)
            Debug.Log(intObjectPair[13]);
            // Directional Light (UnityEngine.GameObject)
        }

        {
            /*
             * Section 7.19.2 ContainsKey
             */

            Dictionary<string, int> objectIntPair = new Dictionary<string, int>();
            GameObject[] allObjects = FindObjectsOfType<GameObject>();
            for (int i = 0; i < allObjects.Length; i++)
            {
                // get the name of the object
                string name = allObjects[i].name;

                // check if we have a key with matching name
                if (objectIntPair.ContainsKey(name))
                {
                    // found another, add 1
                    objectIntPair[name]++;
                }
                else
                {
                    // found at least 1
                    objectIntPair.Add(name, 1);
                }
            }

            foreach (string name in objectIntPair.Keys)
            {
                Debug.Log(name + " count:" + objectIntPair[name]);
            }
            // Cube count:5
            // DictionariesStacksAndQueues count:1
            // Directional Light count:1
            // Main Camera count:1
        }
    }

    /*
     * Section 7.19.3 Stacks
     */
    void UseStacks()
    {
        /*
         * Section 7.19.3.1 Stacks : A Basic Example
         */
        Stack stack = new Stack();
        stack.Push("First"); /* "First"┐           ┌──────────────┐  */
        stack.Push("Second");/*       [↓]          │pushes "First"│  */
        stack.Push("Third"); /*      ❶["First"]←❶──┤into the top  │  */
                             /*                    │of the stack  │  */
                             /*                    └──────────────┘  */
                             /*"Second"┐           ┌───────────────┐ */
                             /*       [↓]          │"Second" pushes│ */
                             /*      ❶["Second"]←❷─┤"First" down   │ */
                             /*      ❷["First"]    │into the Stack │ */
                             /*                    └───────────────┘ */
                             /* "Third"┐           ┌───────────────┐ */
                             /*       [↓]          │"Third" pushes │ */
                             /*  ┌──←❶["Third"]←❸──┤"Second" down  │ */
                             /*  │   ❷["Second"]   │into the Stack │ */
                             /*  │   ❸["First"]    └───────────────┘ */
                             /*  ↓                                   */
        object peeked = stack.Peek();/* ┌──────────────┐             */
        /*       ↑ ┌───────┐     ↓      │Peek returns  │             */
        /*       └←┤"Third"├←────┴──────┤what is on top│             */
        /*         └───────┘            │of the stack  │             */
        Debug.Log(peeked);/*            └──────────────┘             */
        // Third

        object popped = stack.Pop();
        /*     ↑ ┌───────┐     ↓  ┌───────────────┐                  */
        /*     └←┤"Third"├←────┴──┤Pop() pulls the│                  */
        /*       └───────┘        │top off of the │                  */
        /*       [↑]              │the Stack      │                  */
        /*      ❶["Second"]→──┐   └───────────────┘                  */
        /*      ❷["First"]    │  ┌────────────────┐                  */
        /*                    ├──┤"Second" is now │                  */
        Debug.Log(popped);/*  │  │top of the stack│                  */
        // Third          /*  ↓  └────────────────┘                  */
        object secondPeek = stack.Peek();
        Debug.Log(secondPeek);
        // Second
    }

    /*
     * 7.19.4 Using A Stack
     */

    public enum Moves
    {
        None,
        Left,
        Right,
        Forward,
        Backward
    }

    void UseMovementStack()
    {
        GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        MoveStack mover = capsule.AddComponent<MoveStack>();
        mover.AddMove(Moves.None);
        mover.AddMove(Moves.Forward);
        mover.AddMove(Moves.None);
        mover.AddMove(Moves.None);
        mover.AddMove(Moves.Right);
        mover.AddMove(Moves.None);
        mover.AddMove(Moves.Right);
        mover.Move();
    }

    class MoveStack : MonoBehaviour
    {
        private Stack<IEnumerator> Movements;

        public void AddMove(Moves move)
        {
            if (Movements == null)
                Movements = new Stack<IEnumerator>();
            
            switch (move)
            {
                case Moves.None:
                    Movements.Push(MoveTo(Vector3.zero));
                    break;
                case Moves.Left:
                    Movements.Push(MoveTo(Vector3.left));
                    break;
                case Moves.Right:
                    Movements.Push(MoveTo(Vector3.right));
                    break;
                case Moves.Forward:
                    Movements.Push(MoveTo(Vector3.forward));
                    break;
                case Moves.Backward:
                    Movements.Push(MoveTo(Vector3.back));
                    break;
            }
        }
        
        public void Move()
        {
            if (Movements.Count > 0)
            {
                StartCoroutine(Movements.Pop());
            }
        }

        private IEnumerator MoveTo(Vector3 direction)
        {
            Vector3 start = transform.position;
            Vector3 finish = transform.position + direction;
            float t = 0;
            while (t < 1)
            {
                transform.position = Vector3.Lerp(start, finish, t);
                t += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            Move();
        }
    }

    private void Start()
    {
        /*
         * Section 7.19.1 Dictionaries Stacks and Queues : A Basic Example
         */
        //UseDictionary();

        /*
         * Section 7.19.3 Stacks
         */
        //UseStacks();

        /*
         * 7.19.4 Using A Stack
         */
        UseMovementStack();
    }
}

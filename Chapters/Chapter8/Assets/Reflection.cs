/*
 * Chapter 8.4 Reflection
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Reflection : MonoBehaviour
{
    /*
     * Section 8.4.1 Reflection : A Basic Example
     */
    class Person : MonoBehaviour
    {
        public Queue<Delegate> ThingsToDo;
        private void Awake()
        {
            ThingsToDo = new Queue<Delegate>();
        }

        void DoAThing(string thing)
        {
            
            IEnumerator DoesTheThing()
            {
                Debug.Log("Starting " + thing);
                yield return new WaitForSeconds(1f);
                Debug.Log("Done with " + thing);
            }
            StartCoroutine(DoesTheThing());
        }

        bool MoveToPosition(Vector3 position)
        {
            bool done = false;
            IEnumerator MovesTo(Vector3 pos)
            {
                float t = 0;
                while (t < 1)
                {
                    transform.position = Vector3.Lerp(transform.position, pos, t);
                    t += Time.deltaTime;
                    yield return new WaitForEndOfFrame();
                }
                done = true;
                Debug.Log("Done moving.");
            }
            StartCoroutine(MovesTo(position));
            return done;
        }
    }

    void UseReflectOnPerson()
    {
        GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        Person bob = capsule.AddComponent<Person>();
        Action a = () => { Debug.Log("Doing a thing"); };

        bob.ThingsToDo.Enqueue(a);
        Delegate d = bob.ThingsToDo.Dequeue();
        d.DynamicInvoke();
    }

    void Thing()
    {
        Debug.Log("Doing the thing.");
    }

    delegate void mDelegate();
    mDelegate theDelegated;
    void UseReflection()
    {
        theDelegated = Thing;

        void HealTheWizard(int mp)
        {
            Debug.Log("healing the wizard!" + mp);
        }
        
        Queue<Delegate> delegateQueue = new Queue<Delegate>();
        delegateQueue.Enqueue(theDelegated);

        Action<int, int> a = (hitPoints, magicPoints) => Debug.Log(hitPoints + magicPoints);
        delegateQueue.Enqueue(a);
        
        Action<int> b = (fireballDamage) => Debug.Log(fireballDamage);
        delegateQueue.Enqueue(b);
        
        Func<int, int> c = (needsOne) => needsOne + 1;
        delegateQueue.Enqueue(c);
        
        Action<int> healWizard = (mPoints) => HealTheWizard(mPoints);
        delegateQueue.Enqueue(healWizard);
        
        while (delegateQueue.Count > 0)
        {
            Delegate d = delegateQueue.Dequeue();
            MethodInfo info = d.GetMethodInfo();
            MethodAttributes attributes = d.Method.Attributes;
            string name = d.Method.Name;
            ParameterInfo[] parInfo = d.Method.GetParameters();
            foreach (ParameterInfo pi in parInfo)
            {
                Debug.Log(pi.Name);
            }
            Debug.Log(info + " " + attributes + " " + name);
            switch (name)
            {
                case "Thing":
                    Debug.Log("Do the thing.");
                    d.DynamicInvoke();
                    break;
                default:
                    Debug.Log("unknown");
                    break;
            }
        }
    }

    private void Start()
    {
        UseReflectOnPerson();
        //UseReflection();
    }

}

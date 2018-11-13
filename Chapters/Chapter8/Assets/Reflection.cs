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
    #region 8.7
    /*
     * Section 8.7 Reflection
     */
    
    #endregion
    #region 8.7.1 A Basic Example
    /*
     * Section 8.4.1 Reflection : A Basic Example
     */
    class Person : MonoBehaviour
    {
        public Queue<Delegate> ThingsToDo;
        public int Life = 0;
        public int Money = 0;
        private void Awake()
        {
            ThingsToDo = new Queue<Delegate>();
        }

        public void DoTheThings()
        {
            IEnumerator DoesThings()
            {
                while (ThingsToDo.Count > 0)
                {
                    Delegate thing = ThingsToDo.Dequeue();
                    string thingName = thing.Method.Name;
                    // figure out which function is in the Queue.
                    // cast to expected signature
                    switch (thingName)
                    {
                        case "BeBorn":
                            Func<int> born = (Func<int>)thing;
                            Life = born.Invoke();
                            break;
                        case "GoToWork":
                            Func<int> gotoWork = (Func<int>)thing;
                            Money = gotoWork.Invoke();
                            break;
                        case "PayTaxes":
                            Func<int, int> payTaxes = (Func<int, int>)thing;
                            Money = payTaxes.Invoke(Money);
                            break;
                        case "Die":
                            Action<GameObject> die = (Action<GameObject>)thing;
                            die(this.gameObject);
                            break;
                    }
                    Debug.Log("Did " + thingName);
                    yield return new WaitForSeconds(1f);
                }
            }
            StartCoroutine(DoesThings());
        }
    }

    // named functions we should be able to recognize
    int BeBorn()
    {
        Debug.Log("You've got one life...");
        return 1;
    }

    int GoToWork()
    {
        Debug.Log("You're Welcome.");
        return 10;
    }
    
    int PayTaxes(int tax)
    {
        Debug.Log("Thankyou come again.");
        return tax / 2;
    }

    void Die(GameObject gameObject)
    {
        Debug.Log("Goodbye.");
        Destroy(gameObject);
    }

    void UseReflectOnPerson()
    {
        GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        Person bob = capsule.AddComponent<Person>();
        Func<int> born = BeBorn;
        Func<int> work = GoToWork;
        Func<int, int> taxes = PayTaxes;
        Action<GameObject> die = Die;
        bob.ThingsToDo.Enqueue(born);
        bob.ThingsToDo.Enqueue(work);
        bob.ThingsToDo.Enqueue(taxes);
        bob.ThingsToDo.Enqueue(die);
        bob.DoTheThings();
    }
    #endregion

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

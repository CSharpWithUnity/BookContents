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
    #region 8.7 Reflection
    /*
     * Section 8.7 Reflection
     */
    class Stuff
    {
        public float PubFloat = 1;
        public int PubInt = 1;
        public void AFunction()
        {
        }
        public int IntFunction()
        {
            return 1;
        }
    }

    void UseReflectClass()
    {
        Stuff stuff = new Stuff();
        Type type = stuff.GetType();
        foreach (MemberInfo member in type.GetMembers())
        {

            Debug.Log(member);
        }
    }
    #endregion

    #region 8.7.1 A Basic Example
    /*
     * Section 8.4.1 Reflection : A Basic Example
     */

    class HasAFunction
    {
        public void TheFunction()
        {
            Debug.Log("You found me");
        }
    }
    void UseHasAFunction()
    {
        Type hasAFunctionType = typeof(HasAFunction);
        HasAFunction hasAFunction = new HasAFunction();
        foreach (MemberInfo info in hasAFunctionType.GetMembers())
        {
            if (info.Name.Equals("TheFunction"))
            {
                hasAFunction.TheFunction();
            }
        }
    }
    #endregion

    #region 8.7.2 Reflection MethodInfo
    /*
     * Section 8.7.2 Reflection Method Info
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
                    MethodInfo methodInfo = thing.GetMethodInfo();

                    // read the name of the incoming parameter
                    ParameterInfo[] paramInfos = methodInfo.GetParameters();
                    switch (paramInfos[0].Name)
                    {
                        case "life":
                            Func<int, int> life = (Func<int, int>)thing;
                            Life = life.Invoke(Life);
                            break;
                        case "money":
                            Func<int, int> money = (Func<int, int>)thing;
                            Money = money.Invoke(Money);
                            break;
                    }

                    Debug.Log("Did " + thingName + " Life:" + Life + " Money:" + Money);
                    yield return new WaitForSeconds(1f);
                    if (Life <= 0)
                        Destroy(this.gameObject);
                }
            }
            StartCoroutine(DoesThings());
        }
    }

    int BeBorn(int life)
    {
        Debug.Log("You've got one life...");
        return life + 10;
    }

    int GoToWork(int money)
    {
        Debug.Log("You're Welcome.");
        return money + 10;
    }

    int Accident(int life)
    {
        Debug.Log("Oops.");
        return life - 5;
    }

    int PayTaxes(int money)
    {
        Debug.Log("Thankyou come again.");
        return money / 2;
    }

    int Die(int life)
    {
        return life - life;
    }

    void LifeInMoneyOut(int life, out int outMoney)
    {
        outMoney = life * 2;
    }

    delegate void InOutDelegate<T, U>(T input, out U output);
    InOutDelegate<int, int> lifeInMoneyOut;

    void UseReflectOnPerson()
    {
        GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        Person bob = capsule.AddComponent<Person>();
        Func<int, int> born = BeBorn;
        Func<int, int> work = GoToWork;
        Func<int, int> accident = Accident;
        Func<int, int> taxes = PayTaxes;
        Func<int, int> death = Die;
        //lifeInMoneyOut = LifeInMoneyOut;
        bob.ThingsToDo.Enqueue(born);
        bob.ThingsToDo.Enqueue(work);
        bob.ThingsToDo.Enqueue(accident);
        bob.ThingsToDo.Enqueue(taxes);
        bob.ThingsToDo.Enqueue(death);
        //bob.ThingsToDo.Enqueue(lifeInMoneyOut);
        bob.DoTheThings();
    }
    #endregion

    #region 8.7.3 What We've Learned
    /*
     * Section 8.7.3 What We've Learned
     * 
     */
    class HasStuff
    {
        public int number;
        public Vector3 position;
        public GameObject gameObject;

        delegate void ThreeInputs<T, U, V>(T A, U B, V C);
        ThreeInputs<int, Vector3, GameObject> GiveThreeInputs;
        void TheThreeThings(int number, Vector3 position, GameObject gameObject)
        {
            Debug.Log("Got called!");
            Debug.Log(number + " " + position + " " + gameObject);
        }

        public void CheckOnStuff()
        {
            GiveThreeInputs = TheThreeThings;
            Delegate threeIns = GiveThreeInputs;

            var delegateMethodInfo = threeIns.GetMethodInfo().GetParameters();
            var myFields = this.GetType().GetFields();
            object[] pars = new object[delegateMethodInfo.Length];

            for (int i = 0; i < delegateMethodInfo.Length; i++)
            {
                for (int j = 0; j < myFields.Length; j++)
                {
                    if (delegateMethodInfo[i].Name.Equals(myFields[j].Name))
                    {
                        pars[i] = myFields[i].GetValue(this);
                    }
                }
            }

            threeIns.DynamicInvoke(pars);
        }
    }

    void UseWhatWeveLearned()
    {
        HasStuff hasStuff = new HasStuff();
        hasStuff.number = 42;
        hasStuff.position = new Vector3(3, 5, 7);
        hasStuff.gameObject = new GameObject("magic");
        hasStuff.CheckOnStuff();
    }

    #endregion
    private void Start()
    {
        /*
         * Section 8.7.1 Reflection
         * Uncomment the line below to see the
         * process in action.
         */
        //UseReflectClass();

        /*
         * Section 8.7.1.1 A Basic Example
         * Uncomment the line below to see the
         * process in action.
         */
        //UseHasAFunction();

        /*
         * Section 8.7.2 Reflection MethodInfo
         * Uncomment the line below to see the
         * process in action.
         */
        //UseReflectOnPerson();

        /*
         * Section 8.7.2 Reflection MethodInfo
         * Uncomment the line below to see the
         * process in action.
         */
        UseWhatWeveLearned();
    }

}

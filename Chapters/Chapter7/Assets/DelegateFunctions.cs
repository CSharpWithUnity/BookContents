/*
 * Chapter 7.8 Delegate Functions
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using System;
using UnityEngine;

public class DelegateFunctions : MonoBehaviour
{
    /*
     * Section 7.8.1.1 Delegates : A Basic Example
     */
    delegate void MyDelegate();

    void FirstDelegate()
    {
        Debug.Log("First Delegate Called.");
    }

    void SecondDelegate()
    {
        Debug.Log("Second Delegate Called.");
    }

    void UseDelegates()
    {
        // create and assign a delegate to call on a function
        MyDelegate myDelegate = new MyDelegate(FirstDelegate);

        //call on function assigned to delegate
        myDelegate();
        // "First Delegate Called."
        
        // reassign who is assigned to myDelegate
        myDelegate = SecondDelegate;

        // call on function assigned to delegate
        myDelegate();
        // "Second Delegate Called."
    }

    /*
     * Section 7.8.2 Delegate Signatures
     */
    delegate int OtherDelegate(int a, int b);

    public int ThirdDelegate(int a, int b)
    {
        return a + b;
    }

    public int FourthDelegate(int a, int b)
    {
        return a - b;
    }
    
    void UseDelegatesAgain()
    {
        OtherDelegate myDelegate = new OtherDelegate(ThirdDelegate);
        int added = myDelegate(1, 2);
        Debug.Log("added: " + added);
        // "added: 3"

        myDelegate = FourthDelegate;
        int subtracted = myDelegate(5, 6);
        Debug.Log("subtracted: " + subtracted);
        // "subtracted: -1"
    }

    delegate void StackedDelegates(int i);
    StackedDelegates stacked;

    void FifthDelegate(int i)
    {
        Debug.Log("FifthDelegate: " + i);
    }

    void SixthDelegate(int i)
    {
        Debug.Log("SixthDelegate: " + i);
    }

    void UseStackedDelegates()
    {
        stacked = FifthDelegate;
        stacked += FifthDelegate;
        stacked(5);
        // "FifthDelegate: 5"
        // "FifthDelegate: 5"
        stacked += SixthDelegate;
        stacked += SixthDelegate;
        stacked(6);
        // "FifthDelegate: 6"
        // "FifthDelegate: 6"
        // "SixthDelegate: 6"
        // "SixthDelegate: 6"
    }

    /*
     * Section 7.8.4 Using Delegates
     */
    
    //created a delegate that returns a value
    delegate int IntDelegate();
    int GetSeven()
    {
        return 7;
    }
    int GetThree()
    {
        return 3;
    }
    
    void UseDelegate(IntDelegate intDelegate)
    {
        IntDelegate intFromDelegate = intDelegate;
        int i = intFromDelegate();
        Debug.Log("int from intDelegate: " + i);
    }

    void UseIntDelegates()
    {
        UseDelegate(GetSeven);
        UseDelegate(GetThree);
    }

    /*
     * Section 7.8.5 Updating Delegates
     */

    class Counter
    {
        private int Count;
        private int Limit;
        public Counter(int countLimit)
        {
            Limit = countLimit;
        }

        public void UpdateCount()
        {
            if(Count < Limit)
                Count++;
            if (Count >= Limit)
                ReportCount();
        }

        void ReportCount()
        {
            Debug.Log("Counts: " + Count + " Limit: " + Limit);
        }
    }

    bool CountersInitalized = false;
    Counter[] Counters = new Counter[10];
    delegate void UpdateCounters();
    UpdateCounters CounterUpdate;
    void CreateAndUpdateCounters()
    {
        if (!CountersInitalized)
        {
            for (int i = 0; i < 10; i++)
            {
                Counters[i] = new Counter(UnityEngine.Random.Range(10, 30));
                CounterUpdate += Counters[i].UpdateCount;
            }
            CountersInitalized = true;
        }
        CounterUpdate();
    }

    //Less effecive method for updates
    void UpdateForEach()
    {
        foreach (Counter c in Counters)
        {
            c.UpdateCount();
        }
    }

    void Update()
    {
        CreateAndUpdateCounters();
    }

    void Start()
    {
        UseDelegates();
        UseDelegatesAgain();
        UseStackedDelegates();
        UseIntDelegates();
    }
}

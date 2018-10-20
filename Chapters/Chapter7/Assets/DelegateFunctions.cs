/*
 * Chapter 7.8 Delegate Functions
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
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

    delegate void StartTimer();
    
    class DelegateTimer
    {
        float StartTime;
        float PassedTime;
        float EndTime;
        public delegate void ReportTicks(int tick);
        ReportTicks tickReporter;
        int ticks;
        public void AssignDelegate(ReportTicks reporter)
        {
            tickReporter = reporter;
        }
        
        void TimeStarted()
        {
            StartTime = Time.time;
            Debug.Log("Beginning wait.");
        }
        
        void CheckExpiration()
        {
            ticks++;

            if (Time.time >= EndTime)
                TimeExpired();
        }

        void TimeExpired()
        {
            EndTime = Time.time;
            PassedTime = EndTime - StartTime;
            Debug.Log("The time has come!");
        }

        void TimeReport()
        {
            tickReporter(ticks);
            Debug.Log("Start: " + StartTime + " End: " + EndTime + " Passed: " + PassedTime);
        }
    }

    DelegateTimer[] timers;
    void CreateAndStartTimers()
    {
        
    }
    
    void Start()
    {
        UseDelegates();
        UseDelegatesAgain();
        UseStackedDelegates();
        UseIntDelegates();
        CreateAndStartTimers();
    }

    DelegateTimer timer;
    MyDelegate myDelegate;
    void Update()
    {
        if (timer == null)
        {
            timer = new DelegateTimer();
            timer.AssignDelegate(CountTicks);

        }
    }

    void CountTicks(int ticks)
    {
        Debug.Log("Ticks counted: " + ticks);
    }
}

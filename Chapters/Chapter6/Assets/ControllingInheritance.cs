/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 6.23 Controlling Inheritance                              *
 *                                                                   *
 * Copyright © 2018 Alex Okita                                       *
 *                                                                   *
 * This software may be modified and distributed under the terms     *
 * of the MIT license.  See the LICENSE file for details.            *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
using UnityEngine;

/* * * * * * * * * * * * * * * * * *
 * Section 6.23.1.1 Sealed         *
 * * * * * * * * * * * * * * * * * */
sealed class FinalizedObject
{
}

//class InheritFromSealed : FinalizedObject
//{
//}
/* cannot derive from sealed type 'ControllingInheritance.FinalizedObject' */

/*
 * Section 6.23.2 Extension Functions
 * 
 */
static class FinalizedObjectExtension
{
    public static void ExtensionFunction(this FinalizedObject finalObj)
    {
        Debug.Log("Extending the finalizedObject.");
    }

    public static void AnotherExtension(this FinalizedObject finalObj, int someArg)
    {
        Debug.Log("AnotherExtension: " + someArg);
    }

    public static void AnotherExtension(this AnotherSealedClass anotherClass, int anotherArg)
    {
        anotherClass.SealedFunction(anotherArg);
    }
}

sealed class AnotherSealedClass
{
    public void SealedFunction(int sealedArg)
    {
        Debug.Log("SealedFunctions's sealedArg:" + sealedArg);
    }
}

public class ControllingInheritance : MonoBehaviour
{
    void UseControllingInheritance()
    {
        FinalizedObject finalizedObject = new FinalizedObject();
        /*                                              │                 */
        finalizedObject.ExtensionFunction();//←─────────┘
        /*                      ↑                                         */
        /*            ┌─────────┴──────────────────────┐                  */
        /*            │function not actually written in│                  */
        /*            │the FinalizedObject class.      │                  */
        /*            └────────────────────────────────┘                  */

        finalizedObject.AnotherExtension(7);
        // AnotherExtension: 7

        AnotherSealedClass another = new AnotherSealedClass();
        another.AnotherExtension(3);
        //SealedFunctions's sealedArg:3
    }


    /*
     * Section 6.32 Abstraction
     */

    abstract class BaseCounter
    {/*  ↑                      ┌───────────┐   */
     /*  └────────────────────┐ │abstract   │   */
        public int Counter;/* ├─┤declaration│   */
        /*        ┌───────────┘ └───────────┘   */
        /*        ↓                             */
        public abstract void IncrementCounter();
    }

    sealed class ImplementsCounter : BaseCounter
    {
        public override void IncrementCounter()
        {
            Counter++;
            Debug.Log("Counter: " + Counter);
        }
    }

    class DecrementCounter : BaseCounter
    {
        public override void IncrementCounter()
        {
            Counter--;
            Debug.Log("Counter: " + Counter);
        }
    }

    void UseCounter()
    {
        ImplementsCounter counter = new ImplementsCounter();
        counter.IncrementCounter();
        counter.IncrementCounter();
        counter.IncrementCounter();
        counter.IncrementCounter();
        counter.IncrementCounter();
    }

    /*
     * Section 6.23.3 Abstract : Abstract
     */
    abstract class BaseLimitCounter : BaseCounter
    {
        public int Limit;
        public abstract bool AtLimit();
        public abstract void SetLimit(int l);
        public override void IncrementCounter()
        {
            Counter++;
            Debug.Log("Counter: " + Counter);
        }
    }

    class LimitCounter : BaseLimitCounter
    {
        public override bool AtLimit()
        {
            return Counter >= Limit;
        }

        public override void SetLimit(int l)
        {
            Limit = l;
        }
    }

    void UseLimitCounter()
    {
        LimitCounter limitCounter = new LimitCounter();
        limitCounter.SetLimit(3);
        Debug.Log("at limit: " + limitCounter.AtLimit());
        // "at limit: False"
        limitCounter.IncrementCounter();//already implemented in BaseLimitCounter
        // "Counter: 1"
        limitCounter.IncrementCounter();
        // "Counter: 2"
        limitCounter.IncrementCounter();
        // "Counter: 3"
        Debug.Log("at limit: " + limitCounter.AtLimit());
        // "at limit: True"
    }

    /*
     * Section 6.23.4 Controlling Inheritance: Putting it together
     */
    abstract class BaseTimer
    {
        public float EndTime;
        public float Timer;
        public abstract void SetTime(float time);
        public abstract void BeginTimer();
        public abstract bool Ended();
    }

    class GameTimer : BaseTimer
    {
        public override void SetTime(float time)
        {
            Timer = time;
            Debug.Log("GameTimer set for: " + Timer + " seconds.");
        }

        public override void BeginTimer()
        {
            EndTime = Time.fixedTime + Timer;
            Debug.Log("GameTimer EndTime: " + EndTime);
        }

        public override bool Ended()
        {
            return Time.fixedTime >= EndTime;
        }
    }

    GameTimer gameTimer;
    NotGameTimer notGameTimer;
    void UseGameTimer()
    {
        gameTimer = new GameTimer();
        gameTimer.SetTime(3);
        gameTimer.BeginTimer();

        notGameTimer = new NotGameTimer();
        notGameTimer.SetTime(3);
        notGameTimer.BeginTimer();
    }

    void Update()
    {
        if (gameTimer.Ended())
        {
            Debug.Log("GameTimer Ended.");
        }

        if (notGameTimer.Ended())
        {
            Debug.Log("NotGameTimer has not Ended");
        }
    }

    /*
     * Section 6.23.5 Controlling Inheritance : What We've Learned.
     */
    class NotGameTimer : GameTimer
    {
        public override bool Ended()
        {
            return !(Time.fixedTime >= EndTime);
        }
    }

    void Start()
    {
        UseControllingInheritance();
        UseCounter();
        UseLimitCounter();
        UseGameTimer();
    }
}

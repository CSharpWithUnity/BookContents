/*
 * Chapter 7.20 Lambda Expressions
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using System;
using System.Collections;
using UnityEngine;

public class LambdaExpressions : MonoBehaviour
{
    /*
     * Section 7.20.1 Anonymous Expressions
     */

    /* Lambda in Calculus (x) → x * x
     * x becomes x times x.
     * 
     */

    void UseFunctionInAFunction()
    {
        /* this function is hidden outside    */
        /* of this function.                  */
        void FunctionInAFunction()
        {
            Debug.Log("Im a function in a function.");
        };
        FunctionInAFunction();
        // Im a function in a function.
    }

    delegate void SomeDelegate();
    void NamedExpression()
    {
        Debug.Log("Named Expression called.");
    }
    void UseAnonymousExpression()
    {
        // un named function assigned to SomeDelegate();
        SomeDelegate del = () => Debug.Log("Anonymous Expression called.");
        del += NamedExpression;
        del.Invoke();
        // Anonymous Expression called.
        // Named Expression called.
    }

    delegate int Multiply(int a, int b);
    void UseAnotherAnonymousExpression()
    {
        Multiply m = (a, b) => a * b;
        Debug.Log("m = " + m.Invoke(5, 6));
        // m = 30

        m = (a, b) => a / b;
        Debug.Log("m = " + m.Invoke(50, 5));
        // m = 10

        /*              ┌────────────────┐  */
        /*              │input parameters│  */
        /*              └───┬────────────┘  */
        /*                 ┌┴┐              */
        SomeDelegate del = () => { };
        /*                       └┬┘        */
        /*             ┌──────────┴──────┐  */
        /*             │lambda expression│  */
        /*             └─────────────────┘  */

        /*             ┌────────────────┐   */
        /*             │input parameters│   */
        /*             └───┬────────────┘   */
        /*              ┌──┴─┐              */
        Multiply mult = (a, b) => a + b;
        /*                       └──┬──┘    */
        /*             ┌────────────┴────┐  */
        /*             │lambda expression│  */
        /*             └─────────────────┘  */
    }

    /*
     * Section 7.20.1.1 Anonymous Expressions : A Basic Example
     * Action Func and Expression
     */
    
    class DoesThings : MonoBehaviour
    {
        public delegate void ThingToDo();
        public event ThingToDo FirstThingDone, 
                               SecondThingDone,
                               ThirdThingDone;
        private int thing = 0;
        Coroutine doerOfThings;

        public void StartDoingThings()
        {
            doerOfThings = StartCoroutine(DoSomeThings());
        }

        public void StopDoingThings()
        {
            StopCoroutine(doerOfThings);
        }

        private IEnumerator DoSomeThings()
        {
            while (true)
            {
                switch (thing)
                {
                    case 0:
                        FirstThingDone?.Invoke();
                        break;
                    case 1:
                        SecondThingDone?.Invoke();
                        break;
                    case 2:
                        ThirdThingDone?.Invoke();
                        break;
                }
                yield return new WaitForSeconds(1);
                thing = UnityEngine.Random.Range(0, 3);
            }
        }
    }

    void UseLambdaExpressions()
    {
        GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        DoesThings doer = capsule.AddComponent<DoesThings>();

        Action<int, DoesThings> Stopper = (i, dt) =>
        {
            if (i > 10)
            {
                Debug.Log("Doer has done 10 things, that's enough.");
                dt.StopDoingThings();
                Destroy(dt.gameObject);
            }
        };

        doer.StartDoingThings();

        int thingsCounted = 0;
        doer.FirstThingDone += () =>
        {
            Debug.Log("Doer has done its first thing");
            thingsCounted++;
            Stopper(thingsCounted, doer);
        };
        doer.SecondThingDone += () =>
        {
            Debug.Log("Doer has done its second thing");
            thingsCounted++;
            Stopper(thingsCounted, doer);
        };
        doer.ThirdThingDone += () =>
        {
            Debug.Log("Doer has done its third thing");
            thingsCounted++;
            Stopper(thingsCounted, doer);
        };

    }

    void UseOthers()
    {
            // Actions using one line
            Action oneLineAction = () => Debug.Log("One Line Action.");
        oneLineAction();

        // One Line Action.
        Action actionWithCurlyBraces = () =>
        {
            Debug.Log("First Action.");
            Debug.Log("Second Action.");
        };
        actionWithCurlyBraces();
        // First Action.
        // Second Action.

        System.Threading.Thread t = new System.Threading.Thread(() => { Debug.Log("Treading...");});
        t.Start();
        
        Delegate dAction = oneLineAction;
        dAction.DynamicInvoke();
        // Action

        void InnerFunc()
        {
            Debug.Log("InnerFunc");
        };
        InnerFunc();
        // InnerFunc

        Func<int> twentyOne = () => 21;
        Debug.Log(twentyOne());
        // 21

        Delegate InnerFunc2(Action a)
        {
            a();
            return a;
        }
        
        int x = 1;

        InnerFunc2(delegate
        {
            Debug.Log("what? " + x);
        });
        // what? 1

        InnerFunc2(oneLineAction);
        // Action

        Delegate d = InnerFunc2(InnerFunc);
        d.DynamicInvoke();
        //InnerFunc
        //InnerFunc
        IEnumerator enumerator()
        {
            int v = 10;
            Debug.Log("waiting...");
            yield return new WaitUntil(() => v-- < 0);
            Debug.Log(v);
            InnerFunc2(delegate
            {
                Debug.Log("Boom!");
            });
        }
        StartCoroutine(enumerator());
    }

    void Start()
    {
        /*
         * Section 7.20.1 Anonymous Expressions
         */
        UseFunctionInAFunction();
        UseAnonymousExpression();
        UseAnotherAnonymousExpression();
        
        /*
         * Section 7.20.1.1 Anonymous Expressions : A Basic Example
         */
        UseLambdaExpressions();
    }

}

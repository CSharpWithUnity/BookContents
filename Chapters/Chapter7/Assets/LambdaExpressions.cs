/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 7.20 Lambda Expressions                                   *
 *                                                                   *
 * Copyright © 2018 Alex Okita                                       *
 *                                                                   *
 * This software may be modified and distributed under the terms     *
 * of the MIT license.  See the LICENSE file for details.            *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
namespace Chapter7_20
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class LambdaExpressions : MonoBehaviour
    {
        #region Chapter 7.20.1 Anonymous Expressions
        /* * * * * * * * * * * * * * * * * * * * *
         * Section 7.20.1 Anonymous Expressions  *
         * * * * * * * * * * * * * * * * * * * * */

        /* Lambda in Calculus (x) → x * x  *
         * x becomes x times x.            */

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
        void UseAction()
        {
            IEnumerator delayedCall(Action del)
            {
                Debug.Log("Delayed Call Started.");
                yield return new WaitForSeconds(3f);
                Debug.Log("Delayed Call Finished.");
                del.DynamicInvoke();
            }
            StartCoroutine(delayedCall(() => Debug.Log("A Basic Action.")));
            // Delayed Call Started.
            // (3 seconds)
            // Delayed Call Finished.
            // A Basic Action.
        }

        void UseMoreActions()
        {
            int delay = 0;
            IEnumerator delayedCall(Action<int, int> action, int a, int b, float delayTime)
            {
                yield return new WaitForSeconds(delayTime);
                action.DynamicInvoke(a, b);
            }
            Action<int, int> mult = (a, b) =>
            {
                Debug.Log("a * b = " + (a * b));
            };
            Action<int, int> add = (a, b) =>
            {
                Debug.Log("a + b = " + (a + b));
            };
            Action<int, int> sub = (a, b) =>
            {
                Debug.Log("a - b = " + (a - b));
            };

            StartCoroutine(delayedCall((a, b) => Debug.Log("a:" + a + " b:" + b), 2, 3, delay++));
            // a: 2 b: 3
            StartCoroutine(delayedCall(mult, 3, 5, delay++));
            // a * b = 15
            StartCoroutine(delayedCall(add, 7, 13, delay++));
            // a + b = 20
            StartCoroutine(delayedCall(sub, 23, 7, delay++));
            // a - b = 16
        }

        void UseFunc()
        {
            Func<int, int> intOutFunc = (x) => x * x;
            int result = intOutFunc(3);
            Debug.Log(result);
            // 9
        }
        #endregion

        #region Chapter 7.20.2 Lambda Expressions
        /* * * * * * * * * * * * * * * * * * * *
         * Section 7.20.2 Lambda Expressions   *
         * * * * * * * * * * * * * * * * * * * */
        class DoesThings : MonoBehaviour
        {
            // stored list of Delegates
            public Queue<Delegate> ThingsToDo;

            /* a single function to start       */
            /* and execute the generate         */
            /* task list.                       */
            public void StartDoingThings()
            {
                IEnumerator DoSomeThings()
                {
                    int thing = 0;
                    while (ThingsToDo.Count > 0)
                    {
                        yield return new WaitForSeconds(1);
                        ThingsToDo.Dequeue().DynamicInvoke(thing++);
                    }
                    Debug.Log("Done doing things.");
                }
                StartCoroutine(DoSomeThings());
            }
        }

        void UseLambdaExpressions()
        {
            GameObject capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            DoesThings doerOfThings = capsule.AddComponent<DoesThings>();

            // assign procedural task list
            doerOfThings.ThingsToDo = new Queue<Delegate>();
            for (int i = 0; i < 7; i++)
            {
                // Delegate functions generated
                Action<int> action = (x) =>
                {
                    Debug.Log("doing #" + x);
                };
                // assign them to the MonoBehaviour
                doerOfThings.ThingsToDo.Enqueue(action);
            }
            // start the task list
            doerOfThings.StartDoingThings();
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

            System.Threading.Thread t = new System.Threading.Thread(() => { Debug.Log("Treading..."); });
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
        #endregion

        void Start()
        {
            /* * * * * * * * * * * * * * * * * * * * *
             * Section 7.20.1 Anonymous Expressions  *
             * * * * * * * * * * * * * * * * * * * * */
            //UseFunctionInAFunction();
            //UseAnonymousExpression();
            //UseAnotherAnonymousExpression();

            /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
             * Section 7.20.1.1 Anonymous Expressions : A Basic Example  *
             * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
            /* Action Func and Expression */
            //UseAction();
            //UseMoreActions();
            //UseFunc();

            /* * * * * * * * * * * * * * * * * * * *
             * Section 7.20.3 Lambda Expressions   *
             * * * * * * * * * * * * * * * * * * * */
            UseLambdaExpressions();
        }
    }
}


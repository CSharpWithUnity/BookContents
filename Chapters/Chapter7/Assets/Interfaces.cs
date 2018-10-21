/*
 * Chapter 7.8 Delegate Functions
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using UnityEngine;

public class Interfaces : MonoBehaviour
{
    /*
     * Section 7.9 Interfaces
     */

    abstract class ThisClass
    {
        public abstract void DoAThing();
    }

    abstract class ThatClass
    {
        public abstract void DoAThing();
    }

    class ThisClassesClass : ThisClass //,ThatClass?
    {
        public override void DoAThing()
        {
            Debug.Log("Doing ThisClasses thing.");
        }
    }

    /*
     * Section 7.9.1.1 Interfaces: A Basic Example
     */
    interface IThis
    {
        //string ThisName
        //{
        //    get;
        //    set;
        //}
        
        string ThisName { get; set; }
        
        void ThisFunction();
    }

    class ImplementsThis : IThis
    {
        private string thisName;
        public string ThisName
        {
            get
            {
                return thisName;
            }
            set
            {
                thisName = value;
            }
        }

        public void ThisFunction()
        {
            Debug.Log("Hello, my name is " + thisName);
        }
    }

    /*
     * Section 7.9.1.2 Using Accessors
     */
    class Toaster : IThis
    {
        private string toasterName;
        public string ThisName
        {
            get
            {
                return toasterName;
            }
            set
            {
                toasterName = value;
            }
        }

        public void ThisFunction()
        {
            Debug.Log("Howdy, my name is " + toasterName);
        }
    }

    /*
     *  Section 7.9.2 Multiple Interfaces
     */
    interface FirstInterface
    {
        string FirstString { get;set; }
        void FirstFunction();
        void SameFunction();
    }

    interface SecondInterface
    {
        string SecondString { get; set; }
        void SecondFunction();
        void SameFunction();
    }

    class ImplementsFirstAndSecond : FirstInterface, SecondInterface
    {
        private string firstString;
        public string FirstString
        {
            get { return firstString; }
            set { firstString = value; }
        }

        public void FirstFunction()
        {
            Debug.Log("First Function Called");
        }
        private string secondString;
        public string SecondString
        {
            get { return secondString; }
            set { secondString = value; }
        }

        public void SecondFunction()
        {
            Debug.Log("Second Function Called");
        }

        public virtual void SameFunction()
        {
            Debug.Log("Which version is Called?");
            ((FirstInterface)this).SameFunction();
            ((SecondInterface)this).SameFunction();
            /*      ↑           ↑        ↑             */
            /*      │           │        │             */
            /*      │ ┌─────────┴──────┐ │             */
            /*      │ │reference       │ │             */
            /*      │ │to this class   │ │             */
            /*      │ │which implements│ │             */
            /*      │ │the interfaces  │ │             */
            /*      │ └────────────────┘ │             */
            /*┌─────┴──────────┐   ┌─────┴──────────┐  */
            /*│the interface to│   │the function in │  */
            /*│cast into from  │   │the interface   │  */
            /*│this class      │   │to call         │  */
            /*└────────────────┘   └────────────────┘  */
        }

        void FirstInterface.SameFunction()
        {
            Debug.Log("First SameFunction Called.");
        }
        void SecondInterface.SameFunction()
        {
            Debug.Log("Second SameFunction Called.");
        }
    }

    class ImplementsBoth : ImplementsFirstAndSecond
    {
        public override void SameFunction()
        {
            base.SameFunction();
        }
    }

    void UsingMultipleInterfaces()
    {
        ImplementsBoth fromBoth = new ImplementsBoth();
        fromBoth.SameFunction();
    }

    void Start()
    {
        UsingMultipleInterfaces();
    }
}

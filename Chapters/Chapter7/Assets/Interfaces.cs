/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 7.9 Delegate Functions                                    *
 *                                                                   *
 * Copyright © 2018 Alex Okita                                       *
 *                                                                   *
 * This software may be modified and distributed under the terms     *
 * of the MIT license.  See the LICENSE file for details.            *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
namespace Chapter7_9
{
    using System.Collections;
    using UnityEngine;

    public class Interfaces : MonoBehaviour
    {
        #region Chapter 7.9 Interfaces
        /* * * * * * * * * * * * * *
         * Section 7.9 Interfaces  *
         * * * * * * * * * * * * * */
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

        /* * * * * * * * * * * * * * * * * * * * * * * *
         * Section 7.9.1.1 Interfaces: A Basic Example *
         * * * * * * * * * * * * * * * * * * * * * * * */
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

        /* * * * * * * * * * * * * * * * * *
         * Section 7.9.1.2 Using Accessors *
         * * * * * * * * * * * * * * * * * */
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

        /* * * * * * * * * * * * * * * * * * * *
         *  Section 7.9.1.2 Using Accessors    *
         * * * * * * * * * * * * * * * * * * * */
        void UseToaster()
        {
            Toaster toaster = new Toaster();
            toaster.ThisName = "Talkie";
            toaster.ThisFunction();
            // Howdy, my name is Talkie
        }

        class Zombie : MonoBehaviour, IThis
        {
            private string ZombieName;
            public string ThisName
            {
                get { return ZombieName; }
                set { ZombieName = value; }
            }

            public void ThisFunction()
            {
                Debug.Log("mmmmuh name is " + ZombieName);
            }
        }

        void UseZombie()
        {
            //Zombie zombie = new Zombie();
            Zombie zombie = gameObject.AddComponent<Zombie>();
        }

        #endregion

        #region Chapter 7.9.2 Multiple Interfaces
        /* * * * * * * * * * * * * * * * * * * *
         *  Section 7.9.2 Multiple Interfaces  *
         * * * * * * * * * * * * * * * * * * * */
        interface FirstInterface
        {
            string FirstString { get; set; }
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
                /*       ↑           ↑        ↑             */
                /*       │           │        │             */
                /*       │ ┌─────────┴──────┐ │             */
                /*       │ │reference       │ │             */
                /*       │ │to this class   │ │             */
                /*       │ │which implements│ │             */
                /*       │ │the interfaces  │ │             */
                /*       │ └────────────────┘ │             */
                /* ┌─────┴──────────┐   ┌─────┴──────────┐  */
                /* │the interface to│   │the function in │  */
                /* │cast into from  │   │the interface   │  */
                /* │this class      │   │to call         │  */
                /* └────────────────┘   └────────────────┘  */
            }

            /*  ┌──────────────────┐  */
            /*  │the interface to  │  */
            /*  │identify where the│  */
            /*  │function is from  │  */
            /*  └───────┬──────────┘  */
            /*          ↓             */
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

        void UseMultipleInterfaces()
        {
            ImplementsBoth fromBoth = new ImplementsBoth();
            fromBoth.SameFunction();
        }
        #endregion

        #region Chapter 7.9.4 IComparer
        /* * * * * * * * * * * * * * *
         * Section 7.9.4 IComparer   *
         * * * * * * * * * * * * * * */

        void UseIComparer()
        {
            ArrayList numberList = new ArrayList();
            for (int i = 0; i < 100; i++)
            {
                numberList.Add(UnityEngine.Random.Range(0, 1000));
            }

            Debug.Log("Unsorted list.");
            foreach (int i in numberList)
            {
                // show list as generated by
                // a random number generator
                Debug.Log(i);
            }

            numberList.Sort();
            Debug.Log("Sorted list.");
            foreach (int i in numberList)
            {
                // show list sorted
                Debug.Log(i);
            }
            // shows numbers starting from lowest to highest
        }

        class DistanceComparer : IComparer
        {
            public object Target;
            public int Compare(object x, object y)
            {
                GameObject xObj = (GameObject)x;
                GameObject yObj = (GameObject)y;
                GameObject target = (GameObject)Target;
                Vector3 tPos = target.transform.position;
                Vector3 xPos = xObj.transform.position;
                Vector3 yPos = yObj.transform.position;
                float distanceX = (tPos - xPos).magnitude;
                float distanceY = (tPos - yPos).magnitude;
                if (distanceX > distanceY)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }

        public GameObject[] SortedByDistance;
        void UseCompareDistance()
        {
            GameObject[] allObjects = FindObjectsOfType<GameObject>();
            //get all game objects in the scene

            ArrayList objectList = new ArrayList();
            //make an arrayList to copy all of the game objects to

            foreach (GameObject go in allObjects)
            {
                objectList.Add(go);
            }

            DistanceComparer comparer = new DistanceComparer();
            // create a distance comparer

            comparer.Target = this.gameObject;
            // assign the comparer a target

            objectList.Sort(comparer);
            // sort the list with the comparer

            SortedByDistance = new GameObject[objectList.Count];
            objectList.CopyTo(SortedByDistance, 0);
            // copy to Array we can observe in the Editor.
        }
        #endregion

        void Start()
        {
            /* * * * * * * * * * * * * * * * * * * *
             *  Section 7.9.1.2 Using Accessors    *
             * * * * * * * * * * * * * * * * * * * */
            UseToaster();
            UseZombie();

            /* * * * * * * * * * * * * * * * * * * *
             *  Section 7.9.2 Multiple Interfaces  *
             * * * * * * * * * * * * * * * * * * * */
            UseMultipleInterfaces();


            /* * * * * * * * * * * * * * *
             * Section 7.9.4 IComparer   *
             * * * * * * * * * * * * * * */
            UseIComparer();
        }

        void Update()
        {
            /* * * * * * * * * * * * * * *
             * Section 7.9.4 IComparer   *
             * * * * * * * * * * * * * * */
            UseCompareDistance();
        }
    }
}


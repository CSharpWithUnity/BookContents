/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 7.13 Enumerations                                         *
 *                                                                   *
 * Copyright © 2018 Alex Okita                                       *
 *                                                                   *
 * This software may be modified and distributed under the terms     *
 * of the MIT license.  See the LICENSE file for details.            *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
namespace Chapter7_13
{
    using System.Collections;
    using UnityEngine;

    public class Enumerations : MonoBehaviour
    {
        #region Chapter 7.13.1 Enumerators: A Basic Example
        /* * * * * * * * * * * * * * * * * * * * * * * *
         * Section 7.13.1 Enumerators: a basic Example *
         * * * * * * * * * * * * * * * * * * * * * * * */

        /* observe using System.Collections;                *
         * in the header preceeding the class declaration   *
         * this includes the Enumerator type.               */
        int[] intArray = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
        void UseIntEnumerator()
        {
            IEnumerator intEnumerator = intArray.GetEnumerator();
            while (intEnumerator.MoveNext())
            {
                Debug.Log("Current int: " + intEnumerator.Current);
            }
            // Current int: 10
            // Current int: 20
            // Current int: 30
            // Current int: 40
            // Current int: 50
            // Current int: 60
            // Current int: 70
            // Current int: 80
            // Current int: 90
            // Current int: 100
        }

        void UseWithoutLoop()
        {
            IEnumerator intEnumerator = intArray.GetEnumerator();

            intEnumerator.MoveNext();
            Debug.Log("Current int: " + intEnumerator.Current);
            // Current int: 10

            intEnumerator.MoveNext();
            Debug.Log("Current int: " + intEnumerator.Current);
            // Current int: 20

            intEnumerator.MoveNext();
            Debug.Log("Current int: " + intEnumerator.Current);
            // Current int: 30

            intEnumerator.MoveNext();
            Debug.Log("Current int: " + intEnumerator.Current);
            // Current int: 40
        }

        void UseIfToIterate()
        {
            int[] someInts = new int[] { 1, 3, 7 };
            IEnumerator intEnumerator = someInts.GetEnumerator();
            if (intEnumerator.MoveNext())
            {
                Debug.Log("Current int: " + intEnumerator.Current);
            }
            if (intEnumerator.MoveNext())
            {
                Debug.Log("Current int: " + intEnumerator.Current);
            }
            if (intEnumerator.MoveNext())
            {
                Debug.Log("Current int: " + intEnumerator.Current);
            }
            if (intEnumerator.MoveNext())
            {
                Debug.Log("I won't get called.");
            }
        }
        #endregion

        #region Chapter 7.13.1.2 What Doesn't Work
        /* * * * * * * * * * * * * * * * * * * *
         * Section 7.13.1.2 What doesn't work  *
         * * * * * * * * * * * * * * * * * * * */
        void UseStringArray()
        {
            string[] strings = new string[] { "A", "B", "C" };
            IEnumerator strEnumerator = strings.GetEnumerator();
            //foreach (string s in strEnumerator)
            //{
            //    Debug.Log(s);
            //}
            /* uncomment the above to see the error */

            string[] stringsB = new string[] { "A", "B", "C" };
            IEnumerator strBEnumerator = stringsB.GetEnumerator();
            //Debvug.Log(strBEnumerator.Current);
        }
        #endregion

        #region Chapter 7.13.2 Implementing an IEnumerator
        /* * * * * * * * * * * * * * * * * * * * * * * *
         * Section 7.13.2 Implementing an IEnumerator  *
         * * * * * * * * * * * * * * * * * * * * * * * */

        /* Enumerations are made of three parts.       */
        /* Starting with the object that's going       */
        /* to be iterated through                      */
        class AZombie
        {
            public string Name;
            public AZombie(string name)
            {
                Name = name;
            }
        }

        class ZombieEnumerator : IEnumerator
        {
            private AZombie[] AZombieArray;
            private int index;

            /* constructor saves the incoming array    */
            public ZombieEnumerator(AZombie[] zombieArray)
            {
                AZombieArray = zombieArray;
            }

            /* MoveNext increments the locally stored  */
            /* index of the array and returns true     */
            /* so long as the index doesn't exceed     */
            /* the length of the stored array          */
            public bool MoveNext()
            {
                index++;
                return index >= AZombieArray.Length;
            }

            /* put the array index back ahead of 0      */
            public void Reset()
            {
                index = -1;
            }

            /* return the object from the array at the  */
            /* index                                    */
            object IEnumerator.Current
            {
                get
                {
                    return AZombieArray[index];
                }
            }
        }

        /* you then make an IEnumerable object where    */
        /* an array of the enumerated object lives.     */
        class Zombies : IEnumerable
        {
            // the array to iterate through.
            private AZombie[] AZombieArray;

            // constructor to assign to the new Enumerator
            public Zombies(AZombie[] zombieArray)
            {
                AZombieArray = zombieArray;
            }

            // the explicit method which returns the IEnumerator
            // object to start enumeration
            IEnumerator IEnumerable.GetEnumerator() /*→┐❶   */
            {                                       /* │    */
                return (IEnumerator)GetEnumerator();/*←┘❷   */
            }                      /*      │                */
                                   /*      ↓❸               */
            public ZombieEnumerator GetEnumerator()
            {
                return new ZombieEnumerator(AZombieArray);
            }                      /*←❹ returned            */
                                   /* after initalized      */
        }

        void UseEnumerableZombie()
        {
            AZombie Stubbs = new AZombie("Stubbs");
            AZombie Bob = new AZombie("Bob");
            AZombie Rob = new AZombie("Rob");
            AZombie Freddy = new AZombie("Freddy");
            AZombie Jason = new AZombie("Jason");
            AZombie[] zombies = new AZombie[] { Stubbs, Bob, Rob, Freddy, Jason };
            IEnumerator zombieEnumerator = zombies.GetEnumerator();

            while (zombieEnumerator.MoveNext())
            {
                Debug.Log(zombieEnumerator.Current);
            }
            // Enumerations+AZombie
            // Enumerations+AZombie
            // Enumerations+AZombie
            // Enumerations+AZombie
            // Enumerations+AZombie
            // Enumerations+AZombie

            // reset the enumerator after you've used it
            zombieEnumerator.Reset();

            while (zombieEnumerator.MoveNext())
            {
                // don't forget to cast!
                AZombie z = (AZombie)zombieEnumerator.Current;
                Debug.Log(z.Name);
            }
            // Stubbs
            // Bob
            // Rob
            // Freddy
            // Jason
        }
        #endregion

        void Start()
        {
            /* * * * * * * * * * * * * * * * * * * * * * * *
             * Section 7.13.1 Enumerators: a basic Example *
             * * * * * * * * * * * * * * * * * * * * * * * */
            UseIntEnumerator();
            UseWithoutLoop();
            UseIfToIterate();

            /* * * * * * * * * * * * * * * * * * * * * * * *
             * Section 7.13.2 Implementing an IEnumerator  *
             * * * * * * * * * * * * * * * * * * * * * * * */
            UseEnumerableZombie();
        }
    }
}


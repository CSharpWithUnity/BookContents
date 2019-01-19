/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 7.14 Generics                                             *
 *                                                                   *
 * Copyright © 2018 Alex Okita                                       *
 *                                                                   *
 * This software may be modified and distributed under the terms     *
 * of the MIT license.  See the LICENSE file for details.            *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
namespace Chapter7_14
{
    using System;
    using UnityEngine;

    public class Generics : MonoBehaviour
    {
        #region Chapter 7.14.1 Generics
        /* * * * * * * * * * * * * *
         * Section 7.14.1 Generics *
         * * * * * * * * * * * * * */

        void UseCastTypes()
        {
            float f = (float)1.0d;
            Debug.Log(f);
            // 1
        }

        /* * * * * * * * * * * * * * * * * * * * * * * * *
         *  Section 7.14.1.1 Generics : A Basic Example  *
         * * * * * * * * * * * * * * * * * * * * * * * * */

        /*   ┌─────────────────────┐ */
        /*   │ the "generic"       │ */
        /*   │ type is indicated   │ */
        /*   │ starting with <T>   │ */
        /*   │ which is used again │ */
        /*   │ in the parameter    │ */
        /*   └─────┬───────────────┘ */
        /*       ┌─┴┐                */
        /*       ↓  ↓                */
        void Log<T>(T thing)
        {
            string s = "thing is: " + thing.ToString();
            s += " type: " + thing.GetType().ToString();
            Debug.Log(s);
        }

        void UseLog()
        {
            Log(9);
            // thing is: 9 type: System.Int32
            Log(new GameObject("Zombie"));
            // thing is: Zombie (UnityEngine.GameObject) type: UnityEngine.GameObject
            Log(new Vector3());
            // thing is: (0.0, 0.0, 0.0) type: UnityEngine.Vector3
        }

        void LogInt(int i)
        {
            string s = "int is: " + i.ToString();
            Debug.Log(s);
        }

        void UseLogInt()
        {
            LogInt(13);
            //LogInt(new GameObject("Zombie"));
            //LogInt((int)new GameObject("Zombie"));
            /* uncomment the lines above to see the error */
        }
        #endregion

        #region Chapter 7.14.1.2 Why T?
        /* * * * * * * * * * * * * *
         * Section 7.14.1.2 Why T? *
         * * * * * * * * * * * * * */

        void LogCat<LOL>(LOL cat)
        {
            Debug.Log("I can has " + cat.GetType().ToString());
        }

        void UseLogCat()
        {
            LogCat(new GameObject("GameObject"));
            // I can has UnityEngine.GameObject
        }
        #endregion

        #region Chapter 7.14.2 Making Use of Generic Functions
        /* * * * * * * * * * * * * * * * * * * * * * * * * *
         * Section 7.14.2 Making Use of Generic Functions  *
         * * * * * * * * * * * * * * * * * * * * * * * * * */

        void Swap<T>(ref T first, ref T second)
        {
            T temp = second;
            second = first;
            first = temp;
        }

        void UseSwap()
        {
            int[] ints = new int[] { 7, 13 };
            foreach (int i in ints)
                Log(i);
            //thing is: 7 type: System.Int32
            //thing is: 13 type: System.Int32
            Swap(ref ints[0], ref ints[1]);
            foreach (int i in ints)
                Log(i);
            //thing is: 13 type: System.Int32
            //thing is: 7 type: System.Int32

            string[] strings = new string[] { "First", "Second" };
            foreach (string s in strings)
                Log(s);
            //thing is: First type: System.String
            //thing is: Second type: System.String
            Swap(ref strings[0], ref strings[1]);
            foreach (string s in strings)
                Log(s);
            //thing is: Second type: System.String
            //thing is: First type: System.String
        }

        class GenericHumanoid
        {
            public string Name;
            public GenericHumanoid(string name)
            {
                Name = name;
            }
        }

        class GenericZombie : GenericHumanoid
        {
            public GenericZombie(string name) : base(name)
            {
            }

            public override string ToString()
            {
                return "A Zombie named " + Name;
            }
        }
        class GenericVampire : GenericHumanoid
        {
            public GenericVampire(string name) : base(name)
            {
            }

            public override string ToString()
            {
                return "A Vampire named " + Name;
            }
        }

        void UseSwapGenerics()
        {
            GenericHumanoid[] humanoids = new GenericHumanoid[2];
            humanoids[0] = new GenericZombie("Stubbs");
            humanoids[1] = new GenericVampire("D");
            Swap(ref humanoids[0], ref humanoids[1]);
            foreach (GenericHumanoid humanoid in humanoids)
                Debug.Log(humanoid);
            // A Vampire named D
            // A Zombie named Stubbs

            GenericZombie first = new GenericZombie("Rob");
            string second = "Jackson";
            Debug.Log(first + " " + second);
            //Swap(ref first, ref second);
            /* uncomment the line above to see the error */
            // Error CS0411 
            // The type arguments for method 'Generics.Swap<T>(ref T, ref T)'
            // cannot be inferred from the usage.
            // Try specifying the type arguments explicitly.
        }
        #endregion

        #region Chapter 7.14.3 Generic Types
        /* * * * * * * * * * * * * * * * *
         * Section 7.14.3 Generic Types  *
         * * * * * * * * * * * * * * * * */

        class ThreeThings<T>
        {
            public T FirstThing;
            public T SecondThing;
            public T ThirdThing;
            public ThreeThings(T first, T second, T third)
            {
                FirstThing = first;
                SecondThing = second;
                ThirdThing = third;
            }
            public override string ToString()
            {
                return "1:" + FirstThing + " 2:" + SecondThing + " 3:" + ThirdThing;
            }
        }

        void UseThings()
        {
            //ThreeThings things = new ThreeThings(
            /* uncomment the line above to see the error */
            //Using the generic type 'Generics.ThreeThings<T>' requires 1 type arguments

            ThreeThings<GenericZombie> things = new ThreeThings<GenericZombie>(
            new GenericZombie("Bob"),
            new GenericZombie("Rob"),
            new GenericZombie("White"));
            Debug.Log(things.ToString());
            // 1:A Zombie named Bob 2:A Zombie named Rob 3:A Zombie named White
        }
        #endregion

        #region Chapter 7.14.4 Var
        /* * * * * * * * * * * *
         * Section 7.14.4 Var  *
         * * * * * * * * * * * */
        void UseVar()
        {
            GenericZombie first = new GenericZombie("Stubbs");
            GenericZombie second = new GenericZombie("Frankenstein");
            GenericZombie third = new GenericZombie("Michael");
            /*  ┌─────────────────────────────────┐  */
            /*┌─┤ Assumes the type after assigned │  */
            /*↓ └─────────────────────────────────┘  */
            var someThings = new ThreeThings<GenericZombie>(first, second, third);
            Debug.Log(someThings);
            // 1:A Zombie named Stubbs 2:A Zombie named Frankenstein 3:A Zombie named Michael

            var whatAmI = 1;
            Debug.Log(whatAmI.GetType());
            // System.Int32

            Debug.Log(someThings.GetType());
            // Generics+ThreeThings`1[Generics+GenericZombie]
        }

        int TellMeLies(float f)
        {
            return (int)f;
        }

        void UseTellMeLies()
        {
            var imAFloat = TellMeLies(11.8f);
            Debug.Log(imAFloat);
            // 11
        }

        class Stuff<T>
        {
            T thing;
            public void AssignThing(T something)
            {
                thing = something;
            }
        }

        void UseStuff()
        {
            var what = new Stuff<int>();
            //what.AssignThing(1.0f);
            /* uncomment the line above to see the error */
            // cannot convert from 'float' to 'int'
        }
        #endregion

        #region Chapter 7.14.5 Multiple Generic Values
        /* * * * * * * * * * * * * * * * * * * * * *
         * Section 7.14.5 Multiple Generic Values  *
         * * * * * * * * * * * * * * * * * * * * * */

        class TwoThings<T, U>
        {
            public T FirstThing;
            public U SecondThing;
            public void AssignThings(T first, U second)
            {
                FirstThing = first;
                SecondThing = second;
            }
        }

        void UseTwoThings()
        {
            var twoThings = new TwoThings<int, double>();
            twoThings.AssignThings(3, 30.0);
            var differetThings = new TwoThings<GenericZombie, float>();
            differetThings.AssignThings(new GenericZombie("Stubbs"), 1.0f);
        }

        void LogTwoThings<T, U>(T firstThing, U secondThing)
        {
            string log = "FirstThing is a " + firstThing.GetType();
            log += " SecondThing is a " + secondThing.GetType();
            Debug.Log(log);
        }

        void UseLogTwoThings()
        {
            LogTwoThings(3, new GenericVampire("Vlad"));
            // FirstThing is a System.Int32 SecondThing is a Generics+GenericVampire
        }

        class GetTwoThings<T, U> : TwoThings<T, U>
        {
            public T GetFirstThing()
            {
                return FirstThing;
            }

            public U GetSecondThing()
            {
                return SecondThing;
            }
        }

        void UseGetTwoThings()
        {
            var gotTwoThings = new GetTwoThings<GenericZombie, float>();
            gotTwoThings.AssignThings(new GenericZombie("White"), 3.0f);
            LogTwoThings(gotTwoThings.GetFirstThing(), gotTwoThings.GetSecondThing());
            // FirstThing is a Generics+GenericZombie SecondThing is a System.Single
        }

        //var ReturnAVar()
        //{
        //    return new GetTwoThings<GenericZombie, float>();
        //}
        /* Uncomment the function above to see the error */

        #endregion

        #region Chapter 7.14.6 Anonymous Objects
        /* * * * * * * * * * * * * * * * * * *
         * Section 7.14.6 Anonymous Objects  *
         * * * * * * * * * * * * * * * * * * */
        private void UseAnonymousObjects()
        {
            var things = new { someInt = 3, someClass = this };
            Debug.Log("What is things?" + things);
            // What is things?{ someInt = 3, someClass = Generics (Chapter7_14.Generics) }

            var moreThings = new
            {
                someIntArray = new int[] { 1, 2, 3 },
                someZombie = new GenericZombie("Stubbs"),
                someQueue = new System.Collections.Queue()
            };
            Debug.Log("MoreThings: " + moreThings);
            // MoreThings: { someIntArray = System.Int32[],
            // someZombie = A Zombie named Stubbs,
            // someQueue = System.Collections.Queue }


            void acceptAThing(object thing)
            {
                Debug.Log(thing);
            }

            acceptAThing(new { things, moreThings });

            /* formatted for readability:
             * 
             * { things = {
             *   someInt = 3,
             *   someClass = Generics(Chapter7_14.Generics)
             *  },
             *  moreThings = {
             *   someIntArray = System.Int32[],
             *   someZombie = A Zombie named Stubbs,
             *   someQueue = System.Collections.Queue
             *  }
             * }
             */

            object returnsAThing()
            {
                return new { things, moreThings };
            }

            Debug.Log("Can't use var, so lets try object:" + returnsAThing());
            /* formatted for readability:
             * "Can't use var, so lets try object:"
             * { things = {
             *   someInt = 3,
             *   someClass = Generics(Chapter7_14.Generics)
             *  },
             *  moreThings = {
             *   someIntArray = System.Int32[],
             *   someZombie = A Zombie named Stubbs,
             *   someQueue = System.Collections.Queue
             *  }
             * }
             */

            /* uncomment the line below to see the error */
            //things.someInt++;
            // properties of the anonymous object are
            // read only.

            moreThings.someQueue.Enqueue(30);
            moreThings.someQueue.Enqueue(20);
            moreThings.someQueue.Enqueue(10);
            Debug.Log(moreThings.someQueue.Peek());
            // 30
            moreThings.someQueue.Dequeue();
            Debug.Log(moreThings.someQueue.Peek());
            // 20
            moreThings.someQueue.Dequeue();
            Debug.Log(moreThings.someQueue.Peek());
            // 10

            things.someClass.LogInt(10);
            // int is: 10

            var readOnlyThings = new { floatThing = 1.0f, intThing = 1 };
            /* uncomment the line below to see the error */
            //readOnlyThings.floatThing = 10f;
            /* uncomment the line below to see the error */
            //readOnlyThings.intThing = 10;
        }

        #endregion

        #region Chapter 7.14.7 What We've Learned
        /* * * * * * * * * * * * * * * * * * *
         * Section 7.14.7 What We've Learned *
         * * * * * * * * * * * * * * * * * * */
        void UseGetComponent()
        {
            var t = GetComponent<Transform>();
            if (t is Transform)
            {
                t.localPosition = new Vector3(1, 0, 0);
            }
        }
        #endregion

        private void Start()
        {
            /* * * * * * * * * * * * * *
            * Section 7.14.1 Generics *
            * * * * * * * * * * * * * */
            UseCastTypes();

            /* * * * * * * * * * * * * *
             * Section 7.14.1.2 Why T? *
             * * * * * * * * * * * * * */
            UseLog();
            UseLogCat();

            /* * * * * * * * * * * * * * * * * * * * * * * * * *
             * Section 7.14.2 Making Use of Generic Functions  *
             * * * * * * * * * * * * * * * * * * * * * * * * * */
            UseSwap();
            UseSwapGenerics();

            /* * * * * * * * * * * * * * * * *
             * Section 7.14.3 Generic Types  *
             * * * * * * * * * * * * * * * * */
            UseThings();

            /* * * * * * * * * * * *
             * Section 7.14.4 Var  *
             * * * * * * * * * * * */
            UseVar();
            UseTellMeLies();

            /* * * * * * * * * * * * * * * * * * * * * *
             * Section 7.14.5 Multiple Generic Values  *
             * * * * * * * * * * * * * * * * * * * * * */
            UseTwoThings();
            UseLogTwoThings();
            UseGetTwoThings();

            /* * * * * * * * * * * * * * * * * * *
             * Section 7.14.6 Anonymous Objects  *
             * * * * * * * * * * * * * * * * * * */
            UseAnonymousObjects();

            /* * * * * * * * * * * * * * * * * * *
             * Section 7.14.7 What We've Learned *
             * * * * * * * * * * * * * * * * * * */
            UseGetComponent();
        }
    }
}
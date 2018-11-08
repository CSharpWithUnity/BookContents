/*
 * Chapter 7.17 Destructors
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
namespace Destroyers
{
    using UnityEngine;

    /*
     * Section 7.17.1 Destructors: A Basic Example
     */

    public class SelfDestructor : Object
    {
        string Name;

        // Constructor
        public SelfDestructor(string name)
        {
            Name = name;
            Debug.Log(Name + " says hello.");
        }

        // Destructor
        ~SelfDestructor()
        {
            Debug.Log(Name + " says goodbye.");
        }
    }
}
namespace UseDestructors
{
    using UnityEngine;
    using Destroyers;
    using System;
    public class Destructors : MonoBehaviour
    {
        /*
         * Section 7.17.1 A Basic Example
         */
        void UseSelfDestructor()
        {
            SelfDestructor bomb = new SelfDestructor("Bob-omb");
            // Bob-omb says hello.
            // after ~5 seconds
            // Bob-omb says goodbye.
        }

        private UnityEngine.Object Bomber;
        // private SelfDestructor Bomber;
        /* switch which line above is commented */
        /* to see the weird mysterious hello    */
        /* and goodbye from the unnamed object  */
        void UseDestroyBomber()
        {
            Bomber = new SelfDestructor("Bomber");
            do
            {
                Bomber = null;
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true);
            }
            while (Bomber != null);
        }

        class EventDispatcher
        {
            public EventDispatcher()
            {
                Debug.Log("Hello! from dispatcher");
            }

            public delegate void SomeDelegate();
            public event SomeDelegate SomeEvent;
            public void CallSomeEvent()
            {
                SomeEvent?.Invoke();
            }

            ~EventDispatcher()
            {
                Debug.Log("Goodbye from dispatcher");
            }
        }

        class SelfCleaning
        {
            public int CountDown = 3;
            private EventDispatcher Dispatcher;
            public SelfCleaning(EventDispatcher dispatcher)
            {
                Dispatcher = dispatcher;
                Dispatcher.SomeEvent += OnSomeEvent;
                Debug.Log("Hello!, connecting to dispatcher");
            }

            public void OnSomeEvent()
            {
                Debug.Log("I should be destroyed in " + CountDown--);
            }
            
            ~SelfCleaning()
            {
                Dispatcher.SomeEvent -= OnSomeEvent;
                Debug.Log("Goodbye!, cleaning up dispatcher");
            }
        }

        SelfCleaning Cleaner;
        void UseDispatcherAndSelfCleaner()
        {
            EventDispatcher dispatcher = new EventDispatcher();
            Cleaner = new SelfCleaning(dispatcher);
            while (Cleaner.CountDown > 0)
            {
                dispatcher.CallSomeEvent();
            }
            Cleaner = null;
        }

        /*
         * Section 7.17.3 OnDestroy
         */
        class DestroyMe : MonoBehaviour
        {
            private void OnDestroy()
            {
                Debug.Log("I've been destroyed.");
            }
        }

        void DestroyDestroyMe()
        {
            DestroyMe destroyMe = gameObject.AddComponent<DestroyMe>();
            Destroy(destroyMe);
        }

        class UsesOnDestroy : MonoBehaviour
        {
            DestroyEventDispatcher Dispatcher;
            private int CountDown = 3;
            public void AssignListenerUpdater(DestroyEventDispatcher dispatcher)
            {
                Dispatcher = dispatcher;
                Dispatcher.UpdateListenerEvent += OnUpdateListener;
            }

            public void OnUpdateListener()
            {
                Debug.Log("Got Updated");
                gameObject.transform.localScale = Vector3.one * CountDown;
                if (CountDown-- < 0)
                {
                    Debug.Log("CountDown less than 0");
                    Destroy(this);
                }
            }

            // One of the built-in MonoBehaviour functions
            private void OnDestroy()
            {
                Debug.Log("OnDestroy Called.");
                // similar to ~Destroy() function.
               Dispatcher.UpdateListenerEvent -= OnUpdateListener;
            }
        }

        class DestroyEventDispatcher
        {
            public delegate void UpdateListeners();
            public event UpdateListeners UpdateListenerEvent;

            public void CallUpdateListenerEvent()
            {
                int count = 0;
                while(count++ < 5)
                {
                    UpdateListenerEvent?.Invoke();
                }
            }

            public void CallUpdateListenerEventTooManyTimes()
            {
                int count = 0;
                while (count++ < 100)
                {
                    Debug.Log("Calling Update Event.");
                    UpdateListenerEvent?.Invoke();
                }
            }
        }


        void UseDestroyForMonoBehaviours()
        {
            // cube primitive is created.
            GameObject gameCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            // the MonoBehaviour that scales the cube when the event is called
            // then destroys itself once countdown is less than 0
            UsesOnDestroy monoDestroyer = gameCube.AddComponent<UsesOnDestroy>();

            // dispatcher will call the event that the self destroying MonoBehaviour
            // is listening to.
            DestroyEventDispatcher destroyDispatcher = new DestroyEventDispatcher();
            // the event dispatcher is assigned to the MonoBehaviour 
            monoDestroyer.AssignListenerUpdater(destroyDispatcher);

            // there will be a cube for a moment after start
            // but it's destroyed almost right away.
            destroyDispatcher.CallUpdateListenerEvent();
        }

        /*
         * Section 7.17.3 The Ugly Truth
         */

        void UseDestroyTooMuch()
        {
            GameObject gameCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            UsesOnDestroy monoDestroyer = gameCube.AddComponent<UsesOnDestroy>();
            DestroyEventDispatcher destroyDispatcher = new DestroyEventDispatcher();
            monoDestroyer.AssignListenerUpdater(destroyDispatcher);

            // Calling the event 100 times.
            destroyDispatcher.CallUpdateListenerEventTooManyTimes();
            // it should be gone, but it's still listening?
            destroyDispatcher.UpdateListenerEvent -= monoDestroyer.OnUpdateListener;
            // lets disconnect the event listener.
            
            Debug.Log("Calling event again");
            // Calling the event 100 times.
            destroyDispatcher.CallUpdateListenerEventTooManyTimes();

            Debug.Log("When will the UseOnDestroy script actually destroy itself?");
        }

        /*
         * Section 7.17.4 What We've learned
         */

        struct SomeStruct
        {
            public int MyInt;
            public SomeStruct(int myInt)
            {
                MyInt = myInt;
            }
        }

        void UseSomeStruct()
        {
            SomeStruct[] LotsOfStructs = new SomeStruct[10000000];
            //allocates a bunch of memory.
            // about 40MBs also causes Unity to warn about a
            // memory leak!
            for(int i = 0; i < 10000000; i++)
            {
                LotsOfStructs[i] = new SomeStruct(i);
            }
            //as soon as we exit this function they're all gone.
        }

        private void Start()
        {
            UseSelfDestructor();
            // UseDestroyBomber();

            /* comment one or the other line   */
            /* above to see the behaviour      */
            /* of the natural GC in the first  */
            /* function or the forced GC in    */
            /* the second function.            */

            //UseDispatcherAndSelfCleaner();
            //DestroyDestroyMe();
            //UseDestroyForMonoBehaviours();
            //UseDestroyTooMuch();
            //UseSomeStruct();
            /* uncomment each one of the above  */
            /* functions to isolate which one   */
            /* is called to get a more clear    */
            /* set of print outs to the console.*/
        }
    }
}

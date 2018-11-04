/*
 * Chapter 7.15 Events
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

using System;
using UnityEngine;

public class Events : MonoBehaviour
{
    /*
     * Section 7.15.1 A Basic Example
     */

    class Dispatcher
    {
        /*   indicates type of method */
        /*   we are declaring         */
        /*        ↓                   */
        public delegate void Handler();
        /*                      ↓     */
        /*         ┌────────────┘     */
        /*     Handler is the type    */
        /*        ┌┘                  */
        /*        ↓                   */
        public Handler HandleDelegate;
        public event Handler HandleEvent;

        public void CallHandlers()
        {
            /*   check if handle delegate  */
            /*   has an assignment         */
            /*        ↓                    */
            if (HandleDelegate != null)
            {
                /* call function assigned  */
                /* to the delegate handler */
                HandleDelegate();
            }

            /*   check if handle delegate  */
            /*   has an assignment         */
            /*        ↓                    */
            if (HandleEvent != null)
            {
                /* call function assigned  */
                /* to the event handler    */
                HandleEvent();
            }
        }
    }

    class Listener
    {
        private string Name;

        public Listener(string name)
        {
            Name = name;
        }
        
        public void OnDelegateHandled()
        {
            Debug.Log(Name + "'s Delegate Was Handled");
        }
    }

    void UseDispatcher()
    {
        /* attach the dispatcher to ourself. */
        Dispatcher dispatcher = new Dispatcher();
        /* make a couple of listeners to wait for the delegate or event */
        Listener sigmond = new Listener("Sigmund");
        Listener frasier = new Listener("Frasier");

        dispatcher.HandleDelegate += sigmond.OnDelegateHandled;
        dispatcher.HandleDelegate = new Dispatcher.Handler(frasier.OnDelegateHandled);

        dispatcher.CallHandlers();
        // Frasier's Delegate Was Handled

        dispatcher.HandleDelegate = null;
        dispatcher.CallHandlers();
        // nothing is called.


        //dispatcher.HandleEvent = new Dispatcher.Handler(sigmond.OnDelegateHandled);
        /* uncomment the line above to see the error. */
        // The event 'Events.Dispatcher.HandleEvent' can only appear on the                      
        // left hand side of += or -= (except when used from within the type 'Events.Dispatcher')

        //dispatcher.HandleEvent = null;
        /* uncomment the line above to see the error. */
        // The event 'Events.Dispatcher.HandleEvent' can only appear on the                      
        // left hand side of += or -= (except when used from within the type 'Events.Dispatcher')

        dispatcher.HandleEvent += sigmond.OnDelegateHandled;
        dispatcher.HandleEvent += new Dispatcher.Handler(frasier.OnDelegateHandled);
        dispatcher.CallHandlers();
        // Sigmund's Delegate Was Handled
        // Frasier's Delegate Was Handled

        dispatcher.HandleEvent -= frasier.OnDelegateHandled;
        dispatcher.CallHandlers();
        // Sigmund's Delegate Was Handled
    }

    /*
     * Section 7.15.2 A Proper Event
     */

    class ProperDispatcher
    {
        public delegate void ProperEventHandler(object sender, EventArgs args);
        public event ProperEventHandler ProperEvent;
        public void CallProperEvent()
        {
            ProperEvent?.Invoke(this, new EventArgs());
        }
    }

    class ProperListener
    {
        private string Name;

        public ProperListener(string name)
        {
            Name = name;
        }

        public void OnProperEvent(object sender, EventArgs args)
        {
            Debug.Log(Name + "'s event from " + sender + " " + args);
        }
    }

    void UseProperEvent()
    {
        ProperDispatcher dispatcher = new ProperDispatcher();
        ProperListener listener = new ProperListener("Sigmund");
        dispatcher.ProperEvent += listener.OnProperEvent;
        dispatcher.CallProperEvent();
        // Sigmund's event from Events+ProperDispatcher System.EventArgs
    }

    /*
     * Section 7.15.3 EventArgs
     */

    class MyEventArgs : EventArgs
    {
        public string Message;

        public MyEventArgs(string message)
        {
            Message = message;
        }
    }

    class ProperEventArgDispatcher
    {
        public delegate void ProperEventHandler(object sender, MyEventArgs args);
        public event ProperEventHandler ProperEvent;
        public void CallProperEvent()
        {
            ProperEvent?.Invoke(this, new MyEventArgs("Listen to me."));
        }
    }

    class ProperEventArgListener
    {
        private string Name;

        public ProperEventArgListener(string name)
        {
            Name = name;
        }

        public void OnProperEvent(object sender, MyEventArgs args)
        {
            Debug.Log(Name + "'s event from " + sender + " said: " + args.Message);
        }
    }

    void UseProperEventArgs()
    {
        ProperEventArgDispatcher dispatcher = new ProperEventArgDispatcher();
        ProperEventArgListener listener = new ProperEventArgListener("Frasier");
        dispatcher.ProperEvent += listener.OnProperEvent;
        dispatcher.CallProperEvent();
        // Frasier's event from Events+ProperEventArgDispatcher said: Listen to me.
    }
    void Start()
    {
        //UseDispatcher();
        //UseProperEvent();
        UseProperEventArgs();
    }
}


/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 7.15 Events                                               *
 *                                                                   *
 * Copyright © 2018 Alex Okita                                       *
 *                                                                   *
 * This software may be modified and distributed under the terms     *
 * of the MIT license.  See the LICENSE file for details.            *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
namespace Chapter7_15
{
    using System;
    using UnityEngine;

    public class Events : MonoBehaviour
    {
        #region Chapter 7.15.1 Events: A Basic Example
        /* * * * * * * * * * * * * * * * * *
         * Section 7.15.1 A Basic Example  *
         * * * * * * * * * * * * * * * * * */

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
        #endregion

        #region Chapter 7.15.2 A Proper Event
        /* * * * * * * * * * * * * * * * *
         * Section 7.15.2 A Proper Event *
         * * * * * * * * * * * * * * * * */

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
        #endregion

        #region Chapter 7.15.3 EventArgs
        /* * * * * * * * * * * * * * *
         * Section 7.15.3 EventArgs  *
         * * * * * * * * * * * * * * */

        class MessageEventArgs : EventArgs
        {
            public string Message;

            public MessageEventArgs(string message)
            {
                Message = message;
            }
        }

        class ProperEventArgDispatcher
        {
            public delegate void ProperEventHandler(object sender, MessageEventArgs args);
            public event ProperEventHandler ProperEvent;
            public void CallProperEvent()
            {
                ProperEvent?.Invoke(this, new MessageEventArgs("Listen to me."));
            }
        }

        class ProperEventArgListener
        {
            private string Name;

            public ProperEventArgListener(string name)
            {
                Name = name;
            }

            public void OnProperEvent(object sender, MessageEventArgs args)
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
        #endregion

        #region Chapter 7.15.4 Generic EventArgs
        /* * * * * * * * * * * * * * *
         * 7.15.4 Generic EventArgs  *
         * * * * * * * * * * * * * * */

        class GenericEventDispatcher
        {
            public delegate void EventHandler<TEventArgs>(object sender, TEventArgs args);
            public event EventHandler<MessageEventArgs> MessageEvent;
            public event EventHandler<NumerEventArgs> NumberEvent;

            public void CallMessageEvent()
            {
                MessageEvent?.Invoke(this, new MessageEventArgs("Generic Message"));
            }

            public void CallNumberEvent()
            {
                NumberEvent?.Invoke(this, new NumerEventArgs(3));
            }

            public class NumerEventArgs : EventArgs
            {
                public int Number;
                public NumerEventArgs(int limit)
                {
                    Number = limit;
                }
            }

            public event EventHandler<GenericEventArgs<string>> StringEvent;
            public event EventHandler<GenericEventArgs<int>> IntEvent;
            public class GenericEventArgs<T> : EventArgs
            {
                public T Value;
                public GenericEventArgs(T arg)
                {
                    Value = arg;
                }
            }

            public void CallGenericString()
            {
                StringEvent?.Invoke(this, new GenericEventArgs<string>("Generic generic arg!"));
            }

            public void CallGenericInt()
            {
                IntEvent?.Invoke(this, new GenericEventArgs<int>(42));
            }
        }

        class GenericListener
        {
            private string Name;
            public GenericListener(string name)
            {
                Name = name;
            }

            public void OnGenericMessage(object sender, MessageEventArgs message)
            {
                Debug.Log(Name + " got message " + message.Message + " from " + sender);
            }

            public void OnGenericNumber(object sender, GenericEventDispatcher.NumerEventArgs number)
            {
                Debug.Log(Name + " got number " + number.Number + " from " + sender);
            }

            public void OnGenericEvent(object sender, GenericEventDispatcher.GenericEventArgs<string> args)
            {
                Debug.Log(Name + " got value " + args.Value + " from " + sender);
            }

            public void OnGenericEvent(object sender, GenericEventDispatcher.GenericEventArgs<int> args)
            {
                Debug.Log(Name + " got value " + args.Value + " from " + sender);
            }
        }

        void UseGenericEventArgs()
        {
            GenericEventDispatcher dispatcher = new GenericEventDispatcher();
            GenericListener sigmund = new GenericListener("Sigmund");
            dispatcher.MessageEvent += sigmund.OnGenericMessage;
            dispatcher.NumberEvent += sigmund.OnGenericNumber;
            dispatcher.IntEvent += sigmund.OnGenericEvent;
            dispatcher.StringEvent += sigmund.OnGenericEvent;

            dispatcher.CallMessageEvent();
            // Sigmund got message Generic Message from Events+GenericEventDispatcher

            dispatcher.CallNumberEvent();
            // Sigmund got number 3 from Events+GenericEventDispatcher

            dispatcher.CallGenericInt();
            // Sigmund got value 42 from Events+GenericEventDispatcher

            dispatcher.CallGenericString();
            // Sigmund got value Generic generic arg! from Events+GenericEventDispatcher
        }
        #endregion

        void Start()
        {
            /* * * * * * * * * * * * * * * * * *
             * Section 7.15.1 A Basic Example  *
             * * * * * * * * * * * * * * * * * */
            UseDispatcher();

            /* * * * * * * * * * * * * * * * *
             * Section 7.15.2 A Proper Event *
             * * * * * * * * * * * * * * * * */
            UseProperEvent();

            /* * * * * * * * * * * * * * *
             * Section 7.15.3 EventArgs  *
             * * * * * * * * * * * * * * */
            UseProperEventArgs();

            /* * * * * * * * * * * * * * *
             * 7.15.4 Generic EventArgs  *
             * * * * * * * * * * * * * * */
            UseGenericEventArgs();
        }
    }
}

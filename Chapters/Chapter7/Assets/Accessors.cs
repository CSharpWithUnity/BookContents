/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 7.5 Accessors ( or Properties )                           *
 *                                                                   *
 * Copyright © 2018 Alex Okita                                       *
 *                                                                   *
 * This software may be modified and distributed under the terms     *
 * of the MIT license.  See the LICENSE file for details.            *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
namespace Chapter7_5
{
    using UnityEngine;
    public class Accessors : MonoBehaviour
    {
        #region Chapter 7.5 Accessors
        /* * * * * * * * * * * * * *
         * Section 7.5 Accessors   *
         * * * * * * * * * * * * * */

        /* any other object may change      */
        /* the PositiveNumbersOnly          */
        /* property of MyNumberProperty     */
        /* to any value.                    */
        class MyNumberProperty
        {
            public int PositiveNumbersOnly;
        }

        /* there's no way to change the      */
        /* value in this MyReadOnlyProperty  */
        /* class!                            */
        class MyReadOnlyProperty
        {
            public readonly int PositiveNuymbersOnly;
        }

        /* There are three ways in which these */
        /* properties are set                  */
        class MySetOnceNumbers
        {
            public readonly int ReadOnlyOne = 1;//set on initialization
            public readonly int SetByParamOnCreation;
            public readonly int SetOnCreation;

            /* Constructor */
            MySetOnceNumbers(int numberParameter)
            {
                /* Set once by parameter */
                SetByParamOnCreation = numberParameter;
                /* Set by assignment in constructor */
                SetOnCreation = 7;
            }
        }

        class MyPositiveAccessor
        {
            /* ┌──────────────────────────┐ */
            /* │ This value isn't visible │ */
            /* │ outside of this class    │ */
            /* │ this is internal to this │ */
            /* │ class alone.             │ */
            /* └──────────────┬───────────┘ */
            /*                ↓             */
            private int privatePositiveNumber;

            /* ┌──────────────────────────┐ */
            /* │ This value is visible    │ */
            /* │ outside of the class.    │ */
            /* └─────────────┬────────────┘ */
            /*               ↓              */
            public int publicPositiveNumber
            {
                get
                {
                    return privatePositiveNumber;
                }
                set
                {
                    if (value >= 0)
                    {
                        privatePositiveNumber = value;
                    }
                    else
                    {
                        privatePositiveNumber = 0;
                    }
                }
            }
        }
        #endregion

        #region Chapter 7.5.1 Value
        /* * * * * * * * * * * * *
         * Section 7.5.1 Value   *
         * * * * * * * * * * * * */

        class GetSet
        {
            public int MyInt { get; set; }
        }

        void UseGetSet()
        {
            GetSet getset = new GetSet();
            getset.MyInt = 10;
            Debug.Log("getset.MyInt: " + getset.MyInt);
            // "getset.MyInt: 10"
        }

        /* * * * * * * * * * * * * * * * * * * * * *
         * Section 7.5.1.1 Value: A Basic Example. *
         * * * * * * * * * * * * * * * * * * * * * */

        class GetSetWithValues
        {
            private int privateInt;
            public int publicInt
            {
                get
                {
                    return privateInt;
                }
                set
                {
                    privateInt = value;
                }
            }
        }

        void UseGetSetWithValues()
        {
            GetSetWithValues getset = new GetSetWithValues();
            getset.publicInt = 7;
        }

        class GetSetWithEvent
        {
            private int privateInt;
            public int publicInt
            {
                get
                {
                    return privateInt;
                }
                set
                {
                    if (value <= 0)
                    {
                        privateInt = 0;
                    }
                    else
                    {
                        privateInt = value;
                    }
                    if (IntSetEvent != null)
                    {
                        IntSetEvent(privateInt);
                    }
                }
            }
            public delegate void SetIntEventHandler(int i);
            public event SetIntEventHandler IntSetEvent;
        }

        void UseGetSetWithEvent()
        {
            GetSetWithEvent getset = new GetSetWithEvent();
            getset.IntSetEvent += OnIntSet;
            getset.publicInt = 7;
            getset.publicInt = -13;
        }

        void OnIntSet(int i)
        {
            Debug.Log("OnIntSet Called: " + i);
        }
        #endregion

        #region Chapter 7.5.3 Read-Only accessor
        /* * * * * * * * * * * * * * * * * * *
         * Section 7.5.3 Read-Only accessor  *
         * * * * * * * * * * * * * * * * * * */

        class GetSetReadOnly
        {
            public int Int;
            // Read only value
            public int doubleInt
            {
                get
                {
                    return Int * 2;
                }
            }
        }

        void UseGetSetWithEventReadOnly()
        {
            GetSetReadOnly getset = new GetSetReadOnly();
            getset.Int = 7;
            Debug.Log("getset.doubleInt: " + getset.doubleInt);

            //getset.doubleInt = 2;
            /* uncomment the line above to see the error */
        }
        #endregion

        #region Chapter 7.5.4 Simplification
        /* * * * * * * * * * * * * * * * *
         * Section 7.5.4 Simplification  *
         * * * * * * * * * * * * * * * * */
        struct AccessorStruct
        {
            private int privateInt;
            public int publicInt
            {
                get
                {
                    return privateInt;
                }
                set
                {
                    privateInt = value;
                }
            }
            public int GetInt()
            {
                return privateInt;
            }
            public void SetInt(int i)
            {
                privateInt = i;
            }
        }

        void UseAccessorStruct()
        {
            AccessorStruct accessorStruct = new AccessorStruct();
            accessorStruct.publicInt = 3;
            Debug.Log("accessorStruct.publicInt: " + accessorStruct.publicInt);
            // accessorStruct.publicInt: 3
            accessorStruct.SetInt(7);
            Debug.Log("accessorStruct.GetInt(): " + accessorStruct.GetInt());
            // accessorStruct.GetInt(): 7
        }
        #endregion

        private void Start()
        {
            /* * * * * * * * * * * * *
             * Section 7.5.1 Value   *
             * * * * * * * * * * * * */
            UseGetSet();

            /* * * * * * * * * * * * * * * * * * * * * *
             * Section 7.5.1.1 Value: A Basic Example. *
             * * * * * * * * * * * * * * * * * * * * * */
            UseGetSetWithValues();
            UseGetSetWithEvent();

            /* * * * * * * * * * * * * * * * * * *
             * Section 7.5.3 Read-Only accessor  *
             * * * * * * * * * * * * * * * * * * */
            UseGetSetWithEventReadOnly();

            /* * * * * * * * * * * * * * * * *
             * Section 7.5.4 Simplification  *
             * * * * * * * * * * * * * * * * */
            UseAccessorStruct();
        }
    }
}
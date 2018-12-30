/*
 * Chapter 4.4 Class Construction
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

using UnityEngine;

public class ClassConstruction : MonoBehaviour
{
    #region Chapter 4.4 Class Construction
    /* * * * * * * * * * * * * * * * * * *
     * Section 4.4 Class Construction    *
     * * * * * * * * * * * * * * * * * * */

    /*
     * A nested class can appear down below this comment.
     * 
     *    ┌─────────┐ ┌────────────┐
     *    │ keyword │ │ Identifier │
     *    └────┬────┘ └─────┬──────┘
     *   ┌─────┘            │
     *   │       ┌──────────┘
     * ┌─┴─┐ ┌───┴────┐
     * class MyNewClass
     * {
     * }
     * ┬
     * └───────┐
     *   ┌─────┴──────┐
     *   │ separators │
     *   └────────────┘
     *
     * Don't forget the { and } separators following the class declaration.
     * The contents of the new class are defined inside of the curly braces
     */
    #endregion

    #region Chapter 4.4.1 Class Declaration
    /* * * * * * * * * * * * * * * * * * * *
     * Section 4.4.1 Class Declaration     *
     * * * * * * * * * * * * * * * * * * * */

    class MyNewClass
    {
    }

    void UseMyNewClass()
    {
        /* * * * * * * * * * * * * * * * * * * * * * * * * * * *
         * Section 4.4.1.1 Class Declaration - A Basic Example *
         * * * * * * * * * * * * * * * * * * * * * * * * * * * */

        /* ┌────┐ ┌──────────┐ ┌───────────┐ ┌─────────┐
         * │Type│ │Identifier│ │Constructor│ │separator│ 
         * └─┬──┘ └───┬──────┘ └───┬───────┘ └──┬──────┘
         *   └─┐      └───┐        └───────┐    └─┐
         * MyNewClass newClass = new MyNewClass( );
         *           ┌─────────┘  └─┐           └┐
         *     ┌─────┴─────┐  ┌─────┴─────┐┌─────┴───┐
         *     │Assignment │  │Keyword new││Arguments│
         *     │Operator   │  └───────────┘└─────────┘        
         *     └───────────┘
         * MyNewClass is a new type
         */
        MyNewClass newClass = new MyNewClass();


        /* * * * * * * * * * * * * * * * * * * * * * *
         * Section 4.4.1.2 Value and Reference Types *
         * * * * * * * * * * * * * * * * * * * * * * */

        //MyNewClass newClass = 1;
        /* Uncomment the line above to see the error */

        int i = new System.Int32();

        Debug.Log(i);
    }
    #endregion

    #region Chapter 4.4.2 Adding Datafields
    /* * * * * * * * * * * * * * * * * * * *
     * Section 4.4.2 Adding Datafields     *
     * * * * * * * * * * * * * * * * * * * */

    class DataFields
    {
        public int myNumber;

        public void PrintMyNumber()
        {
            Debug.Log(myNumber);
        }
    }
    #endregion

    #region Chapter 4.4.3 Access Modifiers and the Dot Operator
    void TestAccess()
    {
        DataFields dataOne = new DataFields();
        dataOne.myNumber = 1;
        DataFields dataTwo = new DataFields();
        dataTwo.myNumber = 7;
        DataFields dataThree = new DataFields();
        dataThree.myNumber = 11;

        Debug.Log(dataOne.myNumber);
        // 1
        Debug.Log(dataTwo.myNumber);
        // 7
        Debug.Log(dataThree.myNumber);
        // 11

        /* * * * * * * * * * * * * * * * * * * *
         * Section 4.4.3 The Dot Operator      *
         * * * * * * * * * * * * * * * * * * * */

        DataFields firstData = new DataFields();
        firstData.myNumber = 3;
        firstData.PrintMyNumber();
        // 3

        /*
         * inside of DataFields are two members
         * myNumber and PrintMyNumber()
         * 
         */
    }
    #endregion

    #region Chapter 4.4.4 Class Scope
    /* * * * * * * * * * * * * * * * * * * *
     * Section 4.4.4 Class Scope           *
     * * * * * * * * * * * * * * * * * * * */

    /* Data and Function can be paired.    */
    class DataFunctionPairGrouping
    {
        public int MyCounter;
        public void UseMyCounter()
        {
            MyCounter += 1;
            Debug.Log(MyCounter);
        }

        public float MyFloat;
        public void UseMyFloat()
        {
            MyFloat += 1.0f;
            Debug.Log(MyFloat);
        }
    }

    class DefineVariablesFirst
    {
        public int FirstInt;
        public int SecondInt;
        public int ThirdInt;

        public void UseFirstInt()
        {
            Debug.Log(FirstInt);
        }
        public void UseSecondInt()
        {
            Debug.Log(SecondInt);
        }
        public void UseThirdInt()
        {
            Debug.Log(ThirdInt);
        }
    }
    #endregion

    #region Chapter 4.4.6 What We've Learned
    /* * * * * * * * * * * * * * * * * * * *
     * Section 4.4.6 What We've Learned    *
     * * * * * * * * * * * * * * * * * * * */

    void AccessOtherClass()
    {
        DifferentClass someOther = new DifferentClass();
        someOther.myInt = 1;
    }
    #endregion

    void Start()
    {
        /* * * * * * * * * * * * * * * * * * *
         * Section 4.4.1.1                   *
         * * * * * * * * * * * * * * * * * * */
        UseMyNewClass();

        /* * * * * * * * * * * * * * * * * * *
         * Section 4.4.2 Adding Datafields   *
         * * * * * * * * * * * * * * * * * * */
        TestAccess();
    }
}

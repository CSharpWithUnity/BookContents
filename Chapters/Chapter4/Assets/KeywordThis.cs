/*
 * Chapter 4.9 This
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

 using UnityEngine;

public class KeywordThis : MonoBehaviour
{
    #region Chapter 4.9 This
    /* * * * * * * * * * *
     * Section 4.9 This  *
     * * * * * * * * * * */
    int someInt = 0;
    void AssignInt(int i)
    {
        someInt = i;
    }
    /* the i parameter is not ambiguous */

    void AssignSomeInt(int someInt)
    {
        someInt = someInt;
    }
    /* there are no errors, but we do get a message *
     * about assigning a variable to itself.        */

    void AssignThisSomeInt(int someInt)
    {
        this.someInt = someInt;
    }
    /* we can successfully assign the class scoped  *
     * someInt to the incoming parameter.           */

    void UseThis()
    {
        Debug.Log(someInt); // 0
        AssignSomeInt(3);
        Debug.Log(someInt); // still 0?

        AssignThisSomeInt(3);
        Debug.Log(someInt); // 3
        /* the AssignThisSomeInt() function *
         * does what is expected.           */
    }
    #endregion

    #region Chapter 4.9.2 When This is Necessary
    /* * * * * * * * * * * * * * * * * * * * *
     * Section 4.9.2 when this is necessary  *
     * * * * * * * * * * * * * * * * * * * * */
    void AssignThisInt(int i)
    {
        this.someInt = i;
    }

    class ThisThing
    {
        ThisThing myThing;
        public void AssignThing()
        {
            myThing = this;
        }
    }

    void AssignAThingToItself()
    {
        ThisThing thing = new ThisThing();
        thing.AssignThing();
    }
    #endregion

    #region Chapter 4.9.3 What We've Learned
    /* * * * * * * * * * * * * * * * * * *
     * Section 4.9.3 What we've learned  *
     * * * * * * * * * * * * * * * * * * */
    class MyClass
    {
        int MyInt;
        void MyFunction(int mInt)
        {
            int m = mInt;
            MyInt = m;
        }
    }
    #endregion

    private void Start()
    {
        /* * * * * * * * * * *
         * Section 4.9 This  *
         * * * * * * * * * * */
        UseThis();
    }
}

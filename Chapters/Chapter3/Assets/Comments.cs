/*
 * Chapter 3.14 Comments
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 * 
 * Yep, this is a header comment, pretty commonly used at the very top of each
 * source file to indicate usage rights.
 * 
 */

using System;

public class Comments
{
    /*
     * Section 3.3.2 Comments a first look
     */


    //TODO: These comments show up in the Task List.


    /* Player class written by Alex Okita
     * This class manages the player's data and logic
     */

    /******************************************
     * This comment was written by Alex Okita *
     ******************************************/

    void AnotherFunction()
    {
        int someInt = 0;//I print 0 through 10
                        //int someInt = 3;//starts at 3
                        //int someInt = 11;//this won't work, so leave me out.
                        //trying out new code here
        for (int i = 0; i < someInt; i++)
        {
            System.Console.WriteLine(someInt);
        }

        //the code below will do the same thing.

        /*
        while(someInt < 10) {
        System.Console.WriteLine(someInt);
        someInt++;
        }
        */


    }

    void InLineComments()
    {
        int someInt = 0;

        while (someInt </*10*/100)
        {
            System.Console.WriteLine(someInt);
            someInt++;
        }

        Vector3(/* this is the x variable */1.0f,
            2.0f/* <- that was the Y variable*/,
            /* the z */3.0f/*variable is here*/);
    }

    /*
     * Section 3.14.3
     */

    /// <summary>
    /// A Vector3 function of my own!
    /// </summary>
    /// <
    /// <param name="v1"></param>
    /// <param name="v2"></param>
    /// <param name="v3"></param>
    private void Vector3(float v1, float v2, float v3)
    {
        //?
        /* uncomment the ? above to see the error
         * produced in the book.
         */
    }

    #region Special Area of Interest
    void SomeFunction()
    {
        // doing things in area of interest
    }
    int SomeInt = 0;
    #region Sub Section in the area
    class SomeClass
    {
        int SomeClassesInt = 1;
    }
    #endregion
    #endregion

    public void MyPublicMethod()
    {
    }
}

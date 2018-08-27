/*
 * Chapter 3.11 Types
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

using UnityEngine;

public class Types : MonoBehaviour {

	// Use this for initialization
	void Start () {
        /*
         * Section 3.11
         */

        int i = 1;

        /* The int is short for integer
         * an Integer is a whole number
         * or a number without a fraction.
         */
         
        /*
         * Section 3.12 Strong Typing
         */

        // Vector3 vec = new Vector3(1.0, 1.0, 1.0);

        /* Uncomment the line above to
         * see the error produced under the 1.0
         * values in the Vector3() constructor.
         */

        float f = 1.0f;
        double d = 1.0;

        /* The above assignments are
         * valid as the value assigned
         * match the type of the variable
         * being defined.
         */

        Vector3 vec = new Vector3(1.0f, 1.0f, 1.0f);

        /* The above works since we use the 1.0f
         * assignment for the float values.
         */

        /*
         * Section 3.12.1 Dynamic Type
         * 
         * In languages like lua we might see:
         * 
         * as seen in LUA:
         * 
         * var i = 1; // int?
         * if(i) // bool? lua can interpret 1 as true and 0 as false
         * {
         *     Console.WriteLine("is " + i + "i true or a 1?"); // int string or a bool?
         *     i = i * 0.1; // now is i a double?
         * }
         * 
         */

        /*
         * Section 3.13 Type Casting, Numbers
         */

        int hundredInt = 100;

        /* Decimals aren't allowed.
         */

        float hundredFloat = 100.0f;
        double hundredDouble = 100.0;

        float a = 0.9f;
        //int b = a;
        int b = (int)a;
        Debug.Log(b);

        /* What happens to the value of b?
         * int b = a; produces an error
         */

        /*
         * Section 3.13.1 Explicit versus Implicit Casting
         */

        int mInt = 1;
        double mDub= 0.9;
        //int c = mInt * mDub;

        int c = mInt * (int)mDub;

        Debug.Log("int c is: " + c);

        /*
         * Section 3.13.1 continued...
         */

        int anotherInt = 1;
        double anotherDouble = 0.9;
        int yetAnotherInt = anotherInt * (int)anotherDouble;
        Debug.Log("yetAnotherInt: " + yetAnotherInt);
        double yetAnotherDouble = yetAnotherInt;
        
        // this doesn't need a cast
        Debug.Log("yetAnotherDouble: " + yetAnotherDouble);

        /*
         * Section 3.13.1 continued...
         */

        int largeInt = 2147483647;
        Debug.Log("largeInt: " + largeInt);
        float largeFloat = largeInt;
        Debug.Log("largeFloat: " + largeFloat);
        int backAgain = (int)largeFloat;
        Debug.Log("backAgain: " + backAgain);

        int largeIntAgain = 214748361;
        Debug.Log("largeIntAgain: " + largeIntAgain);
        float largeFloatAgain = largeIntAgain;
        Debug.Log("largeFloatAgain: " + largeFloatAgain);
        int backAgainAgain = (int)largeFloatAgain;
        Debug.Log("backAgainAgain: " + backAgainAgain);

        /*
         * Section 3.13.1 continued...
         */

        string s = "1";
        int fromString = int.Parse(s);
        Debug.Log("fromString: " + fromString);

        //TODO: Clean up comments.
    }

    // Update is called once per frame
    void Update () {
		
	}
}

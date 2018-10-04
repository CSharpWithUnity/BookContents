using System;
using UnityEngine;

public class TypesAndOperators : MonoBehaviour
{
    void Equality()
    {
        {
            /*
             * Section 6.21 Types and Operators
             */
            float a = 1.0f;
            float b = 3.0f;
            bool c = a > b;// false
            bool d = a < b;// true
            Debug.Log("c=" + c + " d=" + d);
        }
        {
            string a = "hello, ";
            string b = "world.";
            string c = a + b;
            Debug.Log("c: " + c);
        }
        {
            string a = "hello, ";
            string b = "world.";
            bool c = a == b;
            bool d = a != b;
            string e = a + b;
            /*
             * things you can't do with strings
            string f = a - b;
            bool g = a > b;
            bool g = a < b;
            */
        }
        
    }
}

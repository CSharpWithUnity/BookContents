using System;
using UnityEngine;
/*
 * in section 6.21.3 Type Aliasing
 */
using MyOwnType = System.Int16;
/*    new name for an old type */

public class TypesAndOperators : MonoBehaviour
{
    void CheckOperators()
    {
        {
            /*
             * Section 6.21 Types and Operators
             */
            float a = 1.0f;
            float b = 3.0f;
            bool c = a > b;// false
            bool d = a < b;// true

            Debug.Log("c:" + c + " d:" + d);
        }
        {
            /*
             * adding strings together
             */
            string a = "hello, ";
            string b = "world.";
            string c = a + b;

            Debug.Log("c: " + c);
        }
        {
            /*
             * More things you can do with strings
             */
            string a = "hello, ";
            string b = "world.";
            bool c = a == b; // false
            bool d = a == "world."; // true
            bool e = a == "hello, "; // false
            bool f = a != b; // true
            string g = a + b; // hello, world.

            /*
             * Some things you can't do with strings
             */
            // string f = a - b;
            // string f = a * b;
            // string f = a / b;
            // bool g = a > b;
            // bool g = a < b;
        }
        {
            string a = "hello";
            switch (a)
            {
                case "hello":
                    Debug.Log("a was hello");
                    break;
                case "world":
                    Debug.Log("a was world");
                    break;
                default:
                    break;
            }
        }
        {
            /*
             * Section 6.21.1 GetType()
             */
            int a = 7;
            string b = "hello";
            bool c = a.GetType() == b.GetType();
            Debug.Log("a and b are the same type? " + c);
            // "a and b are the same type? False

            Debug.Log("a is type: " + a.GetType());
            // a is type System.Int32
            Debug.Log("b is type: " + b.GetType());
            // b is type System.String
        }
        {
            int a = 7;
            string b = "7";
            bool c = a.ToString() == b;
            Debug.Log("a as a string is the same as b? " + c);
            // "a as a string is the same as b? True"
        }
        {
            int a = 7;
            float b = 7.0f;
            bool c = a == b;
            Debug.Log("int a == float b? " + c);
            // "int a == float b? True"
        }
        {
            /*
             * Section 6.21.2 More Type Casting
             */
            int a = 7;
            float b = 7.9f;
            bool c = a == b; // false
            /*   ↑   ↓    ↓                     */
            /*   │   │    └────┐                */
            /*   │ ┌─┴──┐    ┌─┴──┐             */
            /*   │ │ 7  │ == │7.9f│             */
            /*   │ └────┘ ↓  └────┘             */
            /*   │     ┌───────┐                */
            /*   └─────┤ False │                */
            /*         └───────┘                */
            bool d = a == (int)b;
            /*   ↑   ↓     ↓   ↓                */
            /*   │   │     │ ┌─┴──┐             */
            /*   │   │     │ │7.9f│             */
            /*   │   │     │ └─┬──┘             */
            /*   │   │     └─→(int) cast to int */
            /*   │   │         ↓                */
            /*   │ ┌─┴──┐    ┌─┴──┐             */
            /*   │ │ 7  │ == │ 7  │             */
            /*   │ └────┘ ↓  └────┘             */
            /*   │     ┌──────┐                 */
            /*   └─────┤ True │                 */
            /*         └──────┘                 */

            Debug.Log("c: " + c + " d: " + d);
            // c: False d: True
        }
        {
            int a = 7;
            string b = "7";
            //bool c = a == (int)b;
            // Cannot convert type 'string' to 'int'
        }
        {
            GameObject a = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            GameObject b = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            bool c = a == b;
            Debug.Log("GameObjects a == b? " + c);
            // GameObjects a == b? False

            int a_InstanceID = a.GetInstanceID();
            int b_InstanceID = b.GetInstanceID();
            Debug.Log("a_InstanceID: " + a_InstanceID);
            // a_InstanceID: -2500
            // though the number itself will change every time you run the game
            Debug.Log("b_InstanceID: " + b_InstanceID);
            // b_InstanceID: -2510
            // though the number itself will change every time you run the game
            Debug.Log("GameObjects a_InstanceID == b_InstanceID? " + c);
            // GameObjects a_InstanceID == b_InstanceID? False
        }
        {
            GameObject a = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            GameObject b;
            b = a;
            bool c = a == b;
            Debug.Log("GameObject a == b? " + c);
            // GameObject a == b? True
        }
        {
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            int a = gameObject.GetInstanceID();
            int b;
            b = a;
            bool c = a == b;
            Debug.Log("InstanceIDs a == b? " + c);
            // InstanceIDs a == b? True
        }
        {
            /*
             * Can Types be equal?
             */
            GameObject a = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            GameObject b = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            Type aType = a.GetType();
            Type bType = b.GetType();
            bool c = aType == bType;
            Debug.Log("aType: " + aType + " bType: " + bType + " aType == bType? " + c);
            // aType: UnityEngine.GameObject bType: UnityEngine.GameObject aType == bType? True
        }
        {
            GameObject a = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            a.AddComponent<ZombieComponent>();
            // check if the GameObject a is a zombie by looking for the attached zombie component
            ZombieComponent component = a.GetComponent<ZombieComponent>();
            Type b = component.GetType();
            Type c = typeof(ZombieComponent);
            bool d = b == c;
            Debug.Log("b type: " + b + "c type: " + c + "b == c?" + d);
        }
        {
            System.Int32 a = 1;
            int b = 3;
            bool c = a.GetType() == b.GetType();
            Debug.Log("a == b? " + c);
            // "a == b? True

            System.Single d = 1.0f;
            float e = 3.0f;
            bool f = d.GetType() == e.GetType();
            Debug.Log("d == e? " + f);
            // "d == e? True
        }
        {
            /*
             * 6.21.3 Type Aliasing
             */
            MyOwnType a = 1;
            Debug.Log("a is a: " + a.GetType());
            // "a is a: System.Int16"
        }
        {
            /*
             * 6.21.4 Boxing and Unboxing
             */
            GameObject a = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            // remember, HumanWithStates : ZombieWithStates?
            ZombieWithStates b = a.AddComponent<HumanWithStates>();
            /*      ↑                                  ↑        */
            /*      └────────────────┬─────────────────┘        */
            /*                ┌──────┴─────────────┐            */
            /*                │types don't match   │            */
            /*                │but HumanWithStates │            */
            /*                │inherits from       │            */
            /*                │ZombieWithStates    │            */
            /*                └────────────────────┘            */

            GameObject c = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            MonoBehaviour d = c.AddComponent<ZombieWithStates>();
            /*      ↑                                  ↑        */
            /*      └────────────────┬─────────────────┘        */
            /*                ┌──────┴─────────────┐            */
            /*                │types don't match   │            */
            /*                │either but          │            */
            /*                │ZombieWithStates    │            */
            /*                │inherits from       │            */
            /*                │MonoBehaviour       │            */
            /*                └────────────────────┘            */

            object e = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            /*  ↑           ↑                                   */
            /*  └─────┬─────┘                                   */
            /* ┌──────┴─────────────┐                           */
            /* │GameObject inherits │                           */
            /* │from object         │                           */
            /* │but every class in  │                           */
            /* │C# inherits from    │                           */
            /* │object!             │                           */
            /* └────────────────────┘                           */
            object f = 1;
            object g = 1.0f;
            object h = new object[] {1, 1.0f, e, d, c, b, a};
            Debug.Log("what is h really? " + h);
            // what is h really? System.Object[]
            object[] objArray = h as object[];
            foreach(object o in objArray)
            {
                if(o is GameObject)
                {
                    Debug.Log("got a GameObject!");
                }
            }
            // got a GameObject!
            // got a GameObject!
            // got a GameObject!

            UnityEngine.Object[] allObjectsInTheScene = FindObjectsOfType<UnityEngine.Object>();
            foreach(UnityEngine.Object o in allObjectsInTheScene)
            {
                Debug.Log("Object: " + o);
            }
            // all kinds of things!
        }
    }

    public void Start()
    {
        CheckOperators();
    }
}

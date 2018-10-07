using System.Collections;
/*
 * Chapter 6.22 Operator Overloading
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

using UnityEngine;

public class OperatorOverloading : MonoBehaviour
{
    void UseOperatorOverloading()
    {
        {
            /*
             * Section 6.22 Operator Overloading
             */
            Zombie a = new Zombie(10);
            Zombie b = new Zombie(10);
            //Zombie c = a + b;
            // Operator + cannot be applied to operands of type 'Zombie' and 'Zombie'
        }
        {
            /*
             * Section 6.22.1 Operator Overloading A Basic Example
             */
            Puzzle a = new Puzzle()
            {
                x = 1,
                y = 2,
                points = 1
            };
            Puzzle b = new Puzzle()
            {
                x = 0,
                y = 1,
                points = 3
            };
            Puzzle c = a + b;
            Debug.Log("c.x: " + c.x + " c.y: " + c.y + " c.points: " + c.points);
            // c.x: 1 c.y: 3 c.points: 4
        }
        {
            /*
             * Section 6.22.2 Overloading *
             */
            Puzzle a = new Puzzle() { x = 1, y = 2, points = 3 };
            int b = 3;
            Puzzle c = a * b;
            Debug.Log("c.x: " + c.x + " c.y: " + c.y + " c.points: " + c.points);
            // c.x: 3 c.y: 6 c.points: 9

            c *= 3;
            Debug.Log("c.x: " + c.x + " c.y: " + c.y + " c.points: " + c.points);
            // c.x: 9 c.y: 18 c.points: 27

            c += 1;
            Debug.Log("c.x: " + c.x + " c.y: " + c.y + " c.points: " + c.points);
            // c.x: 10 c.y: 19 c.points: 28 //before revision
            // c.x: 9 c.y: 18 c.points: 28 // after revision

            Vector2Int vec2i = new Vector2Int(2, 3);
            c += vec2i;
            Debug.Log("c.x: " + c.x + " c.y: " + c.y + " c.points: " + c.points);
            // c.x: 11 c.y: 21 c.points: 28 // after revision
        }
        {
            /*
             * Section 6.22.3 Overloading < and >
             */
            Puzzle a = new Puzzle() { points = 1 };
            Puzzle b = new Puzzle() { points = 7 };
            bool c = a > b;
            Debug.Log("a > b? " + c);
            // a > b? False

            bool d = a < b;
            Debug.Log("a < b? " + d);
            // a < b? True
        }
    }

    private void Start()
    {
        UseOperatorOverloading();
    }

    public class Puzzle
    {
        public int x;
        public int y;
        public int points;
        /*
         * Section 6.22.1 Operator Overloading A Basic Example
         */

        /*┌─────────────┬────────────────┬────────────┬─────────────┬────────────┐*/
        /*│Accessibility│static means    │return type │indicates we │the operator│*/
        /*└──────┬──────┤the function is │the addition│will override│to be       │*/
        /*       │      │available to all│of a puzzle │an operator  │over-ridden │*/
        /*       │      │objects of this │to a puzzle ├──────┬──────┴─────┬──────┘*/
        /*       │      │type            │is another  │      │            │       */
        /*       │      └────────┬───────┤puzzle      │      │            │       */
        /*       │ ┌─────────────┘       └──────┬─────┘      │            │       */
        /*       │ │      ┌─────────────────────┘            │            │       */
        /*       │ │      │       ┌──────────────────────────┘            │       */
        /* ┌─────┘ │      │       │   ┌───────────────────────────────────┘       */
        /* ↓       ↓      ↓       ↓   ↓                                           */
        public static Puzzle operator +(Puzzle a, Puzzle b)
        {
            Puzzle p = new Puzzle()
            {
                x = a.x + b.x,
                y = a.y + b.y,
                points = a.points + b.points
            };
            return p;
        }

        public static Puzzle operator -(Puzzle a, Puzzle b)
        {
            Puzzle p = new Puzzle()
            {
                x = a.x - b.x,
                y = a.y - b.y,
                points = a.points - b.points
            };
            return p;
        }

        /*
         * Section 6.22.2 Overloading *
         */
        public static Puzzle operator *(Puzzle a, int b)
        {
            Puzzle p = new Puzzle()
            {
                x = a.x * b,
                y = a.y * b,
                points = a.points * b
            };
            return p;
        }

        public static Puzzle operator +(Puzzle a, int b)
        {
            Puzzle p = new Puzzle()
            {
                //x = a.x + b,
                //y = a.y + b,
                x = a.x,
                y = a.y,
                points = a.points + b
            };
            return p;
        }

        public static Puzzle operator +(Puzzle a, Vector2Int b)
        {
            Puzzle p = new Puzzle()
            {
                x = a.x + b.x,
                y = a.y + b.y,
                points = a.points
            };
            return p;
        }

        /*
         * Section 6.22.3 Overloading < and >
         */
        public static bool operator <(Puzzle a, Puzzle b)
        {
            return a.points < b.points;
        }

        public static bool operator >(Puzzle a, Puzzle b)
        {
            return a.points > b.points;
        }
    }

}

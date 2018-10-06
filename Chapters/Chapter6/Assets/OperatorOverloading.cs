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
            Zombie a = new Zombie();
            Zombie b = new Zombie();
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
    }

    public class Puzzle
    {
        public int x;
        public int y;
        public int points;
/*┌─────────────┬────────────────┬────────────┬─────────────┬────────────┐*/
/*│Accessibility│static means    │return type │indicates we │the operator│*/
/*└──────┬──────┤the function is │the addition│will override│to be       │*/
/*       │      │available to all│of a puzzle │an operator  │over-ridden │*/
/*       │      │objects of this │to a puzzle ├──────┬──────┴─────┬──────┘*/
/*       │      │type            │is another  │      │            │       */
/*       │      └────────┬───────┤puzzle      │      │            │       */
/*       │       ┌───────┘       └──────┬─────┘      │            │       */
/*       │       │       ┌──────────────┘            │            │       */
/*       │       │       │      ┌────────────────────┘            │       */
/*       └─┐     │       │      │     ┌───────────────────────────┘       */
/*         ↓     ↓       ↓      ↓     ↓                                   */
        public static Puzzle operator + (Puzzle a, Puzzle b)
        {
            Puzzle p = new Puzzle()
            {
                x = a.x + b.x,
                y = a.y + b.y,
                points = a.points + b.points
            };
            return p;
        }
    }
}

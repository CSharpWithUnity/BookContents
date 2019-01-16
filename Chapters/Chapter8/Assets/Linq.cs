/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 8.8 LINQ                                                      *
 *                                                                       *
 * Copyright © 2018 Alex Okita                                           *
 *                                                                       *
 * This software may be modified and distributed under the terms         *
 * of the MIT license.  See the LICENSE file for details.                *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
namespace Chapter8_8
{
    using System.Collections;
    using System.Linq;
    using System.Collections.Generic;
    using UnityEngine;
    using System;

    public class Linq : MonoBehaviour
    {
        /* * * * * * * * * * * * * * * * * * *
         * Section 8.8.1 Lambdas and Arrays  *
         * * * * * * * * * * * * * * * * * * */

        /* Observe above in the header we    *
         * include 'using System.Linq;'      *
         * this adds some new keywords!      */
        void UseLinqOnArray()
        {
            {
                int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                var evenNums = from n in numbers
                               where (n % 2) == 0
                               select n;
                // Linq adds the keywords, from
                // where and select.
                foreach (int n in evenNums)
                {
                    Debug.Log(n);
                }
                // 0
                // 2
                // 4
                // 6
                // 8
                // 10

            }
            {
                int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                /*      └──────────────❶────┐ numbers is an array    */
                /*                  ┌──❷──┐ ↓ n is each object in    */
                /*                  ↓     ↑ ↓ the number array.      */
                var evenNums = from n in numbers
                /*    ↑ the result  ↓                                 */
                /*    ❺ is added to └❸┐ an operation is performed     */
                /*    │ evenNums      ↓ on each object in the array   */
                /*    │      */where (n % 2) == 0
                /*    │               ↓ if this operation is true     */
                /*    │               ❹ the value is added to         */
                /*    │               ↓ the result of the statement   */
                /*    └─────←*/select n;

                // Linq adds the keywords, from
                // where and select.
                foreach (int n in evenNums)
                {
                    Debug.Log(n);
                }
                // 0
                // 2
                // 4
                // 6
                // 8
                // 10
            }
        }

        /* * * * * * * * * * *
         * Section 8.8.2 Var *
         * * * * * * * * * * */
        void UseVar()
        {
            var aThingHere = 7;
            var anotherThingThere = (object)19;
            var aDifferetThing = (float)23;

            System.Type firstType = aThingHere.GetType();
            System.Type secondType = anotherThingThere.GetType();
            System.Type thirdType = aDifferetThing.GetType();

            Debug.Log(firstType);
            // System.Int32
            Debug.Log(secondType);
            // System.Int32
            Debug.Log(thirdType);
            // System.Single

            var someThing = 1;
            var anotherThing = new GameObject();
            Debug.Log(someThing.GetType());
            /* uncomment the line below to see the */
            /* error from the assignment.          */
            //someThing = anotherThing;
        }

        /* * * * * * * * * * * * * *
         * Section 8.8.3 Linq From *
         * * * * * * * * * * * * * */
        class Zombie
        {
            public int hitPoints;
            public Zombie()
            {
                hitPoints = UnityEngine.Random.Range(1, 100);
            }
        }

        void UseFindZombies()
        {
            // make a bunch of zombies
            Zombie[] zombieArray = new Zombie[100];
            for (int i = 0; i < 100; i++)
            {
                zombieArray[i] = new Zombie();
            }

            // select weak zombies;
            var weakZombies = from z in zombieArray
                              where z.hitPoints < 50
                              select z;

            foreach (Zombie z in weakZombies)
            {
                Debug.Log(z.hitPoints);
            }
            // a bunch of numbers < 50!
        }

        /* * * * * * * * * * * * * * * * * * * * * *
         * Section 8.8.4 Strange Behavior in Linq  *
         * * * * * * * * * * * * * * * * * * * * * */
        void UseStrangeBehaviour()
        {
            //declare an array
            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var divisibleByThree = from number in numbers
                                       /*  ↓            */
                                       /*  ↓            */
                                   where (number % 3) == 0
                                   /*      ↓            */
                                   select number;
            numbers[0] = 1;        /*      │            */
            numbers[3] = 1;        /*      │  changes made to numbers not to         */
            numbers[6] = 30;       /*      │  divisibleByThree but divisibleByThree  */
            numbers[9] = 300;      /*      ↓  still knows it's function              */
            foreach (int i in divisibleByThree)
            {
                Debug.Log(i);
            }
            // 30
            // 300

            /* the updated values
             * are captured in the
             * Debug even after the
             * Linq operation was
             * invoked on the numbers
             */
            numbers[0] = 3000;
            numbers[1] = 30000;
            Debug.Log("look again!");
            foreach (int i in divisibleByThree)
            {
                Debug.Log(i);
            }
            // 3000
            // 30000
            // 30
            // 300
        }

        /*
         * Section 8.8.5 Linq on Lists
         */
        void UseLinqOnLists()
        {
            {
                int[] setA = { 1, 2, 3, 4 };
                int[] setB = setA.Where(x => x % 2 == 0).ToArray();
                foreach (int i in setB)
                {
                    Debug.Log(i);
                }
                // 2
                // 4
            }
            {
                int[] setA = { 1, 2, 3, 4 };

                // Lambda
                Func<int, bool> even = (x) => { return x % 2 == 0; };
                int[] setB = setA.Where(even).ToArray();
                foreach (int i in setB)
                {
                    Debug.Log(i);
                }
                // 2
                // 4
            }

            {
                int[] setA = { 1, 1, 2, 2, 3, 3, 4, 4 };
                // Distinct removes repeated values
                List<int> setB = setA.Distinct().ToList();
                foreach (int i in setB)
                {
                    Debug.Log(i);
                }
                // 1
                // 2
                // 3
                // 4
            }
            {
                int[] setA = { 1, 2, 3, 4 };
                int[] setB = { 3, 4, 5, 6 };

                // union merges the two lists together
                // distinct removes duplicates
                int[] setC = setA.Union(setB).Distinct().ToArray();
                foreach (int i in setC)
                {
                    Debug.Log(i);
                }
                // 1
                // 2
                // 3
                // 4
                // 5
                // 6
            }
            {
                int[] setA = { 1, 2, 3, 4 };
                int[] setB = { 3, 4, 5, 6 };

                // only shows things unique to setA
                int[] setC = setA.Except(setB).Distinct().ToArray();
                foreach (int i in setC)
                {
                    Debug.Log(i);
                }
                // 1
                // 2

                // only shows objects unique to setB
                int[] setD = setB.Except(setA).Distinct().ToArray();
                foreach (int i in setD)
                {
                    Debug.Log(i);
                }
                // 5
                // 6
            }
        }

        /* * * * * * * * * * * * * * * *
         * Section 8.8.6 Monsters Linq *
         * * * * * * * * * * * * * * * */

        public enum Alignments
        {
            Good,
            Neutral,
            Evil
        }

        class Monster
        {
            public string Name;
            public int HP;
            public Alignments Alignment;
            public Vector3 Position;
            public Monster()
            {
                string[] nameParts = { "Ba", "Ga", "Da", "Wa", "Pa", "Na", "La", "Ta", "Fa" };
                Name = "";
                for (int i = 0; i < 2; i++)
                {
                    int p = UnityEngine.Random.Range(0, nameParts.Length);
                    Name += nameParts[p];
                }
                Alignment = (Alignments)UnityEngine.Random.Range(0, 3);
                HP = UnityEngine.Random.Range(1, 11);
                Position = new Vector3()
                {
                    x = UnityEngine.Random.Range(-1f, 1f),
                    y = UnityEngine.Random.Range(-1f, 1f),
                    z = UnityEngine.Random.Range(-1f, 1f)
                };
            }
        }

        class MonsterNameEqualityComparer : IEqualityComparer<Monster>
        {
            public bool Equals(Monster x, Monster y)
            {
                return x.Name.Equals(y.Name);
            }

            public int GetHashCode(Monster obj)
            {
                return obj.Name.GetHashCode();
            }
        }

        class MonsterNameComparer : IComparer<Monster>
        {
            public int Compare(Monster x, Monster y)
            {
                return string.Compare(x.Name, y.Name);
            }
        }

        class MonsterAlignmentComparer : IComparer<Monster>
        {
            public int Compare(Monster x, Monster y)
            {
                int a = x.Alignment.GetHashCode();
                int b = y.Alignment.GetHashCode();
                int i = 0;
                if (a > b)
                    i = 1;
                else if (a < b)
                    i = -1;
                return i;
                // or...
                // return a > b ? 1 : a < b ? -1 : 0;
            }
        }

        void UseComparerClasses()
        {
            int numMonsters = 100;
            Monster[] monsters = new Monster[numMonsters];
            for (int i = 0; i < numMonsters; i++)
            {
                monsters[i] = new Monster();
            }
            {
                var distinct = monsters.Distinct();
                string log = "Distinct default: \n";
                int count = 1;
                foreach (Monster m in distinct)
                {
                    log += count++ + ") name: " + m.Name + " " + m.Alignment + "\n";
                }
                // odds are that all 100 are still in the list.
                Debug.Log(log);
            }
            {
                /* this will use the Name Comparer to filter out *
                 * monsters with the same name                   */
                MonsterNameEqualityComparer nameEqualer = new MonsterNameEqualityComparer();
                var unique = monsters.Distinct(nameEqualer).ToArray();
                //about a third of the names will be removed.
                string log = "";
                int count = 1;
                foreach (Monster m in unique)
                {
                    log += count++ + ") name: " + m.Name + " " + m.Alignment + "\n";
                }
                Debug.Log(log);
            }
            {
                /* this will use the Name Comparer to sort the names    *
                 * then we filter out repeated names but ignores        *
                 * alignments.                                          */
                MonsterNameComparer compareNames = new MonsterNameComparer();
                MonsterNameEqualityComparer nameEqualer = new MonsterNameEqualityComparer();
                var distinctOrdered = monsters.OrderBy(m => m, compareNames).Distinct(nameEqualer);

                string log = "using classes to compare and filter: \n";
                int count = 1;
                foreach (Monster m in distinctOrdered)
                {
                    log += count++ + ") name: " + m.Name + " " + m.Alignment + "\n";
                }
                Debug.Log(log);
            }
            {
                /* this uses lambdas to sort the names              *
                 * then we filter out repeated names but ignores    *
                 * alignments.                                      */
                var distinctOrdered = monsters.OrderBy(m => m.Name)
                                              .GroupBy(m => m.Name)
                                              .Select(group => group.First());

                string log = "using lambda to compare and filter: \n";
                int count = 1;
                foreach (Monster m in distinctOrdered)
                {
                    log += count++ + ") name: " + m.Name + " " + m.Alignment + "\n";
                }
                Debug.Log(log);
            }
            {
                /* this does the same name sorting and      *
                 * also filters out repeats, but ignores    *
                 * alignment.                               */
                var distinctOrdered = from monster in monsters
                                      orderby monster.Name ascending
                                      group monster by monster.Name into uniqueNames
                                      select uniqueNames.First();

                string log = "using linq to compare and filter \n";
                int count = 1;
                foreach (Monster m in distinctOrdered)
                {
                    log += count++ + ") name: " + m.Name + " " + m.Alignment + "\n";
                }
                Debug.Log(log);
            }
            {
                /* This produces the grouped data which is a Dictionary     *
                 * where the orderby turns the Name property into a Key     *
                 * to sort the array.                                       */
                var distinctOrdered = from monster in monsters
                                      orderby monster.Name ascending
                                      group monster by monster.Name into uniqueNames
                                      select uniqueNames;

                string log = "What is in uniqueNames \n";
                int count = 1;
                foreach (var group in distinctOrdered)
                {
                    var groupKey = group.Key;
                    foreach (Monster m in group)
                    {
                        log += count++ + ")" + groupKey + " " + m.Alignment + "\n";
                    }
                }
                Debug.Log(log);
            }
        }

        void UseLambdaComparer()
        {
            int numMonsters = 100;
            Monster[] monsters = new Monster[numMonsters];
            for (int i = 0; i < numMonsters; i++)
            {
                monsters[i] = new Monster();
            }

            {
                /* This produces a list of all 100 monsters *
                 * they are grouped together based on their *
                 * names and alignments.                    */
                var sorted = monsters.OrderBy
                (
                    m =>
                    m.Alignment.GetHashCode() + m.Name.GetHashCode()
                );

                string log = "Sorted Monsters using lambda \n";
                int n = 1;
                foreach (Monster m in sorted)
                {
                    log += n++ + ") name: " + m.Name + " " + m.Alignment + "\n";
                }
                Debug.Log(log);
            }

            {
                /* This picks out monsters with HP above 9  *
                 * then lists them out.                     */
                var strongMonsters = monsters.Where
                (
                    monster =>
                    monster.HP > 9
                );
                string log = "Strong Monsters: \n";
                int n = 1;
                foreach (Monster m in strongMonsters)
                {
                    log += n++ + ") " + m.Name + " " + m.HP + "\n";
                }
                Debug.Log(log);
            }


            {
                /* This picks out monsters with HP above 9          *
                 * then lists them out. This and the above          *
                 * statements are equivalent. The only difference   *
                 * is the syntax and use of keywords in place       *
                 * of anonymous lambda like syntax.                 */
                var strongMonsters = from monster in monsters
                                     where monster.HP > 9
                                     select monster;

                string log = "Strong Monsters: \n";
                int n = 1;
                foreach (Monster m in strongMonsters)
                {
                    log += n++ + ") " + m.Name + " " + m.HP + "\n";
                }
                Debug.Log(log);
            }

            {
                /* Objects in the linq statement can see *
                 * variables in its immediate scope      */

                Monster ComparedTo = new Monster();/* →─────┐          ComparedTo can  */
                var weakerThan = from monster in monsters/* ↓          be used in the  */
                                 where monster.HP < ComparedTo.HP/* where statement */
                                 select monster;

                string log = "Weaker than " + ComparedTo.Name + ":" + ComparedTo.HP + "\n";
                int n = 1;
                foreach (Monster m in weakerThan)
                {
                    log += n++ + ") " + m.Name + " " + m.HP + "\n";
                }
                Debug.Log(log);
            }
        }

        void Start()
        {
            /* * * * * * * * * * * * * * * * * * *
             * Section 8.8.1 Lambdas and Arrays  *
             * * * * * * * * * * * * * * * * * * */
            
            /* uncomment the line below to see  *
             * the function in action           */
            UseLinqOnArray();

            /* * * * * * * * * * * * * * * * * * *
             * Section 8.8.2 Var                 *
             * * * * * * * * * * * * * * * * * * */

            /* uncomment the line below to see  *
             * the function in action           */
            UseVar();

            /* * * * * * * * * * * * * * * * * *
             * Section 8.8.2 Var               *
             * * * * * * * * * * * * * * * * * */

            /* uncomment the line below to see  *
             * the function in action.          */
            UseFindZombies();

            /* * * * * * * * * * * * * * * * * *
             * Section 8.8.2 Var               *
             * * * * * * * * * * * * * * * * * */

            /* uncomment the line below to see  *
             * the function in action.          */
            UseStrangeBehaviour();

            /* * * * * * * * * * * * * * * * * *
             * Section 8.8.2 Var               *
             * * * * * * * * * * * * * * * * * */

            /* uncomment the line below to see  *
             * the function in action.          */
            UseLinqOnLists();
            UseComparerClasses();
        }
    }
}

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 6.17 More On Arrays                                       *
 *                                                                   *
 * Copyright © 2018 Alex Okita                                       *
 *                                                                   *
 * This software may be modified and distributed under the terms     *
 * of the MIT license.  See the LICENSE file for details.            *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
namespace Chapter6_17
{
    using System.Collections;
    using UnityEngine;

    public class MoreOnArrays : MonoBehaviour
    {
        void Start()
        {
            #region Chapter 6.17.1 More On Arrays
            {
                /* * * * * * * * * * * * * * * * *
                 * Section 6.17.1 More On Arrays *
                 * * * * * * * * * * * * * * * * */

                int i;
                /* a single int value */
                int[] ints;
                /* array of ints without any values */
                //Debug.Log(i + ints[0]);
                /* Cannot use i or ints without values */

                int[] primes = new int[] { 1, 3, 5, 7, 11, 13, 17, 23, 27, 31 };
                /*  ↑                  ↑              */
                /* ┌┴──────────────────┴────────┐     */
                /* │ brackets tell lexer to     │     */
                /* │ create array for given type│     */
                /* └────────────────────────────┘     */
            }
            {
                /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
                 * Section 6.17.1.1 A Basic Example More On Arrays continued...  *
                 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

                int[] primes = new int[] { 1, 3, 5, 7, 11, 13, 17, 23, 27, 31 };
                int primesLength = primes.Length;
                /*      ↓   └── ← ───┘      ↑               */
                /*   ┌──┴───┐    ┌──────────┴────────────┐  */
                /*   │ used │    │ returns the number of │  */
                /*   └──┬───┘    │ items in the array.   │  */
                /*      ↓        └───────────────────────┘  */
                /*      └────── → ──────┐                   */
                for (int i = 0; i < primesLength; i++)
                {                        /* ↓               */
                    Debug.Log(primes[i]);/* │ using         */
                }                        /* │ arrayLength   */
                                         /* │ value again   */
                                         /* │               */
                int j = 0;               /* │               */
                while (j < primesLength)/*←─┘               */
                {
                    Debug.Log(primes[j++]);
                }
            }
            {
                /* * * * * * * * * * * * * * * * *
                 * Section 6.17.1.1 continued.   *
                 * * * * * * * * * * * * * * * * */

                int[] primes = new int[] { 1, 3, 5, 7, 11, 13, 17, 23, 27, 31 };

                /*               ┌───────────────────────┐  */
                /*               │ Length needs to be    │  */
                /*               │ requested every loop  │  */
                /*               └──────────┬────────────┘  */
                /*                          ↓               */
                for (int i = 0; i < primes.Length; i++)
                {
                    Debug.Log(primes[i]);
                }
            }
            #endregion

            #region Chapter 6.17.2 Foreach a reminder
            {
                /* * * * * * * * * * * * * * * * * * *
                 * Section 6.17.2 Foreach a reminder *
                 * * * * * * * * * * * * * * * * * * */
                int[] primes = new int[] { 1, 3, 5, 7, 11, 13, 17, 23, 27, 31 };
                foreach (int p in primes)
                {
                    Debug.Log(p);
                }
            }
            {
                /* with some value types you can just assign them without new type[]    */
                /*  omitted   ↓ new int[], instead we're just assigning values {values} */
                int[] primes = { 1, 3, 5, 7, 11, 13, 17, 23, 27, 31 };
                int[] fibonacci = { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144 };
                int[] powersOfTwo = { 1, 2, 4, 8, 16, 32, 64, 128, 255, 512, 1024 };
                ArrayList numbers = new ArrayList { primes, fibonacci, powersOfTwo };
                int numArrays = numbers.Count; /* ArrayList uses .Count, not .Length */
                for (int i = 0; i < numArrays; i++)
                {
                    /*  ❶ nums assumes the type array of ints               */
                    /*  ┌────────────────────────────────┐ ┌───────────────┐*/
                    /*  ↓                                │ │ ❷ this allows │*/
                    int[] nums = numbers[i] as int[];/*  ├─┤   the use of  │*/
                    int items = nums.Length;/* ←─────────┘ │   .Length     │*/
                                            /*             └───────────────┘*/
                    for (int j = 0; j < items; j++)
                    {
                        Debug.Log(nums[j]);
                    }
                }

                //int notAvailable = numbers.Length;
                /* uncomment the line above to see the error */

                /* also valid! */
                object[] obj_numbers = { primes, fibonacci, powersOfTwo };
                foreach (int[] nums in obj_numbers)
                {/*          ↑                    ┌────────────────────────┐ */
                 /*          └────────────────────┤ performs the int[] cast│ */
                 /*                               │ from the object array  │ */
                    foreach (int n in nums) /*    └────────────────────────┘ */
                    {
                        Debug.Log(n);
                    }
                }
            }
            #endregion

            #region Chapter 6.17.3 Discovery
            {
                /* * * * * * * * * * * * * * *
                 * Section 6.17.3 Discovery  *
                 * * * * * * * * * * * * * * */


                int[] primes = { 1, 3, 5, 7, 11, 13, 17, 23, 27, 31 };
                int[] fibonacci = { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144 };
                int[] powersOfTwo = { 1, 2, 4, 8, 16, 32, 64, 128, 255, 512, 1024 };
                ArrayList numbers = new ArrayList { primes, fibonacci, powersOfTwo };

                int numArrays = numbers.Count;
                for (int i = 0; i < numArrays; i++)
                {
                }


                object thing = numbers.ToArray();
                Debug.Log("thing is: " + thing);

                object[] anotherThing = numbers.ToArray() as object[];
                Debug.Log("anotherThing Length: " + anotherThing.Length);
            }
            #endregion
        }
    }
}

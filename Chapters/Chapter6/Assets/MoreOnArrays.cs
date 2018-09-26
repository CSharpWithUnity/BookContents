/*
 * Chapter 6.17 More On Arrays
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

using UnityEngine;

public class MoreOnArrays : MonoBehaviour
{
    void Start()
    {
        {
            /*
             * Section 6.17.1.1 A Basic Example More On Arrays continued...
             */
            int[] primes = new int[] { 1, 3, 5, 7, 11, 13, 17, 23, 27, 31 };
            int primesLength = primes.Length;

            for (int i = 0; i < primesLength; i++)
            {
                Debug.Log(primes[i]);
            }

            int j = 0;
            while (j < primesLength)
            {
                Debug.Log(primes[j++]);
            }
        }
        {
            /*
             * Section 6.17.2 Foreach a reminder
             */

            int[] primes = new int[] { 1, 3, 5, 7, 11, 13, 17, 23, 27, 31 };
            foreach (int p in primes)
            {
                Debug.Log(p);
            }
        }
        {
            int[] primes = { 1, 3, 5, 7, 11, 13, 17, 23, 27, 31 };
            int[] fibonacci = { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144 };
            int[] powersOfTwo = { 1, 2, 4, 8, 16, 32, 64, 128, 255, 512, 1024 };

        }
    }
}


/*
 * Chapter 5.5.2.1 A Basic Example
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public static int numZombies;
    /*
     * remove the static keyword above
     * to see a different result
     */
	void Start ()
    {
        numZombies++;
        Debug.Log(numZombies);
	}

    public static void CountZombies()
    {
        Debug.Log(numZombies);
    }
}


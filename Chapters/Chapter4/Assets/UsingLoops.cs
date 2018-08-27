/*
 * Chapter 4.12.6 UsingLoops
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

using UnityEngine;

public class UsingLoops : MonoBehaviour
{
    int numCubes = 0;
    private void Start()
    {
        /*
         * Section 4.12.6 Using Loops
         */

        while (numCubes < 10)
        {
            GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
            box.transform.position = new Vector3(numCubes * 2.0f, 0, 0);
            numCubes++;
        }
    }
}


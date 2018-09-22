/*
 * Chapter 6.14 Type Casting Again
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using UnityEngine;

public class VectorsAreObjects : MonoBehaviour
{
    public int NumberOfMonsters;
    GameObject[] Monsters;

    void Start()
    {
        for (int i = 0; i < NumberOfMonsters; i++)
        {
            GameObject m = GameObject.CreatePrimitive(PrimitiveType.Capsule);

        }
    }
}


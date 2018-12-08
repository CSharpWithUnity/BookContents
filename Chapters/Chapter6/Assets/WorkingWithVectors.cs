/*
 * Chapter 6.14 Type Casting Again
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using UnityEngine;

namespace Chapter6_15
{
    /*
     * Chapter 6.15 Working With Vectors
     */

    public class WorkingWithVectors : MonoBehaviour
    {
        public int numMonsters;
        //Use this for initialization
        void Start()
        {
            for (int i = 0; i < numMonsters; i++)
            {
                GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                sphere.AddComponent<Monster>();
                Vector3 pos = new Vector3()
                {
                    x = Random.Range(-10, 10),
                    z = Random.Range(-10, 10)
                };
                sphere.transform.position = pos;
            }
        }

    }

    public class Monster : MonoBehaviour
    {
        
    }
}

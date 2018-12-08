/*
 * Chapter 6.14 Type Casting Again
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter6_15
{
    public class Gizmo : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        private void OnDrawGizmos()
        {
            /*
             * Chapter 6.15.3.1 Gizmos A Basic Example
             * uncomment the line below to see the cuboid
             * gizmo drawn at the origin.
             */

            //Gizmos.DrawCube(Vector3.zero, new Vector3(1, 2, 3));
            
            /*
             * Chapter 6.15.3.2 DrawRay
             */
            Ray ray = new Ray();
            ray.origin = Vector3.zero;
            ray.direction = Vector3.up;
            Gizmos.DrawRay(ray);

            /*
             * Chapter 6.15.4 Using Gizmos
             */

            Gizmos.DrawLine(transform.position, Vector3.zero);

        }
    }
}

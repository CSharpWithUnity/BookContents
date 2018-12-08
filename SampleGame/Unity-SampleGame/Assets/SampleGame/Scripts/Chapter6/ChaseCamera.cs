/*
 * Chapter 6.3.1 Chase Camera
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter6
{
    public class ChaseCamera : MonoBehaviour
    {
        private GameObject _Target;
        private GameObject Target
        {
            get
            {
                if (_Target == null)
                {
                    // find the player, keep
                    // a reference to it.
                    _Target = Chapter5.Player.ThePlayer;
                }
                return _Target;
            }
        }

        private Vector3 Offset;
        private void Update()
        {
            if (Target == null)
                return;
            // Calculate the difference between previous position
            // and the new position.
            Vector3 diff = Target.transform.position - Offset;
            // Move the camera that difference.
            transform.position += diff;
            // update the Offset value.
            Offset = Target.transform.position;
        }
    }
}

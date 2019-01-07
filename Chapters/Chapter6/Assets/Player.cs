/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 6.6 Enums                                                 *
 *                                                                   *
 * Copyright © 2018 Alex Okita                                       *
 *                                                                   *
 * This software may be modified and distributed under the terms     *
 * of the MIT license.  See the LICENSE file for details.            *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using UnityEngine;

namespace Chapter6_6
{
    public class Player : MonoBehaviour
    {
        public float Speed = 1;

        // Update is called once per frame
        void Update()
        {
            gameObject.transform.position += Movement(Speed);
        }

        Vector3 Movement(float dist)
        {
            Vector3 vec = Vector3.zero;
            if (Input.GetKey(KeyCode.A))
            {
                vec.x -= dist;
            }
            if (Input.GetKey(KeyCode.D))
            {
                vec.x += dist;
            }
            if (Input.GetKey(KeyCode.W))
            {
                vec.z += dist;
            }
            if (Input.GetKey(KeyCode.S))
            {
                vec.z -= dist;
            }
            return vec;
        }
    }
}

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 5.2 Review                                                *
 *                                                                   *
 * Copyright © 2018 Alex Okita                                       *
 *                                                                   *
 * This software may be modified and distributed under the terms     *
 * of the MIT license.  See the LICENSE file for details.            *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
namespace Chapter5_2
{
    using UnityEngine;

    public class RotateZ : MonoBehaviour
    {
        void Update()
        {
            transform.Rotate(new Vector3(0, 0, 1f * Time.deltaTime));
        }
    }
}

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 5.5.4 Putting it all together.                            *
 *                                                                   *
 * Copyright © 2018 Alex Okita                                       *
 *                                                                   *
 * This software may be modified and distributed under the terms     *
 * of the MIT license.  See the LICENSE file for details.            *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
namespace Chapter5_5_4
{
    using UnityEngine;

    public class Player : MonoBehaviour
    {
        public static Vector3 position;
        void Update()
        {
            bool w = Input.GetKey(KeyCode.W);
            bool a = Input.GetKey(KeyCode.A);
            bool s = Input.GetKey(KeyCode.S);
            bool d = Input.GetKey(KeyCode.D);

            /* Next set up some values to multiply against  *
             * transform position directions                */
            float xAxis = 0;
            float yAxis = 0;

            /* then add the desired position */
            if (w)
            {
                yAxis += 1;
            }
            if (a)
            {
                xAxis -= 1;
            }
            if (s)
            {
                yAxis -= 1;
            }
            if (d)
            {
                xAxis += 1;
            }

            /* get a vector for the new position */
            Vector3 direction = transform.position;
            direction += transform.forward * yAxis;
            direction += transform.right * xAxis;

            /* interpolate to that new position */
            transform.position = Vector3.Lerp(transform.position, direction, Time.deltaTime * 5f);

            /* now that the character is moving, *
             * lets get him to rotate            *
             * with the mouse.                   */
            bool q = Input.GetKey(KeyCode.Q);
            bool e = Input.GetKey(KeyCode.E);
            float rot = 0;
            if (q)
            {
                rot -= 10;
            }
            if (e)
            {
                rot += 10;
            }
            transform.Rotate(new Vector3(0, rot, 0));
        }
    }
}

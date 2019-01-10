/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 4.12.6 UsingLoops                                         *
 *                                                                   *
 * Copyright © 2018 Alex Okita                                       *
 *                                                                   *
 * This software may be modified and distributed under the terms     *
 * of the MIT license.  See the LICENSE file for details.            *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
namespace Chapter4_12
{
    using UnityEngine;

    public class UsingLoops : MonoBehaviour
    {
        public int numCubes = 10;
        private void Start()
        {
            #region Chapter 4.12.6 Using Loops
            {
                /* * * * * * * * * * * * * * * *
                 * Section 4.12.6 Using Loops  *
                 * * * * * * * * * * * * * * * */

                while (numCubes < 10)
                {
                    GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    box.transform.position = new Vector3(numCubes * 2.0f, 0, 0);
                    numCubes++;
                }
            }
            #endregion

            #region Chapter 4.12.7 Loops within Loops
            {
                /* * * * * * * * * * * * * * * * * * * *
                 * Section 4.12.7 Loops within Loops   *
                 * * * * * * * * * * * * * * * * * * * */
                for (int i = 0; i < numCubes; i++)
                {
                    for (int j = 0; j < numCubes; j++)
                    {
                        GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        box.transform.position = new Vector3(i * 2.0f, j * 2.0f, 0);
                    }
                }
            }
            #endregion

            #region Chapter 4.12.8 Runaway Loops
            {
                /* * * * * * * * * * * * * * * * *
                 * Section 4.12.8 Runaway Loops  *
                 * * * * * * * * * * * * * * * * */

                while (true)
                {
                    //return;
                    /*
                     * return here stops the entire function
                     * and the code under here will not be
                     * reached.
                     */
                    break;
                }

                for (; ; )
                {
                    break;
                }

                Debug.Log("Starting");
                for (; ; )
                {
                    Debug.Log("before break");
                    break;
                    //return;
                    Debug.Log("after the break");
                }
                Debug.Log("Ending");

                int counter = 0;
                while (true)
                {
                    counter++;
                    if (counter > 10)
                    {
                        Debug.Log("Break!");
                        break;
                    }
                }
            }
            #endregion
        }
    }
}

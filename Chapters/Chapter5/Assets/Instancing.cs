/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 5.4 Instancing                                            *
 *                                                                   *
 * Copyright © 2018 Alex Okita                                       *
 *                                                                   *
 * This software may be modified and distributed under the terms     *
 * of the MIT license.  See the LICENSE file for details.            *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
namespace Chapter5_4
{
    using Chapter5;
    using UnityEngine;

    public class Instancing : MonoBehaviour
    {
        #region Chapter 5.4.1 Class Initialization
        /* * * * * * * * * * * * * * * * * * * * *
         * Section 5.4.1 Class Initialization    *
         * * * * * * * * * * * * * * * * * * * * */
        public int i;
        public float f;
        public double d;
        /* Plain Old Data gets initialized       *
         * automatically.                        */
        #endregion

        #region Chapter 5.4.2 New
        /* * * * * * * * * * * * * * * * * * * * *
         * Section 5.4.2 New                     *
         * * * * * * * * * * * * * * * * * * * * */

        /* the new keyword gets used to make     *
         * a new instance of a object.           */
        class Thing
        {
        }

        void UseNew()
        {
            // creates new int i assigns 7
            int i = 7;

            /* creates new int j and assigns  *
             * a new int, but it's not given  *
             * any value.                     */
            int j = new int();

            /* creates and assigns      *
             * Thing t to a new Thing   */
            Thing t = new Thing();

            /* creates and assigns                       *
             * Example e to new Example : MonoBejaviour  */
            Example e = gameObject.AddComponent<Example>();
        }

        #endregion

        #region Chapter 5.4.3 Constructors
        /* * * * * * * * * * * * * * * * * * * * *
         * Section 5.4.3 Constructors            *
         * * * * * * * * * * * * * * * * * * * * */
        void UseConstructors()
        {
            {
                /* Section 5.4.3 Constructors               *
                 * This vectror is created                  *
                 * without any parameters                   */
                Vector3 vector = new Vector3();
                Debug.Log(vector);
            }
            {
                /* Section 5.4.3 continued...               *
                 * This vector was created with two         *
                 * parameters.                              */
                Vector3 vector = new Vector3(1.0f, 1.0f);
                Debug.Log(vector);
            }
            {
                /* Section 5.4.3 continued...               *
                 * This vector was created with all three   *
                 * parameters assigned.                     */
                Vector3 vector = new Vector3(1.0f, 2.0f, 3.0f);
                transform.position = vector;
            }
            {
                /* Section 5.4.3 continued...               *
                 * Setting the transform position directly  *
                 * to the new Vector.                       */
                transform.position = new Vector3(1.0f, 2.0f, 3.0f);
            }
            {
                /* Section 5.4.3 continued...               *
                 * Setting parameters in the new vector     */
                Vector3 vector = new Vector3(1.0f, 2.0f, 3.0f);
                vector.x = 3.0f;
                transform.position = vector;
            }
            {
                /* Section 5.4.3 continued...               *
                 * Setting parameters in the new vector     *
                 * this includes a scoped constructor.      */
                Vector3 vector = new Vector3()
                {
                    x = 1.0f,
                    y = 2.0f,
                    z = 3.0f
                };
                transform.position = vector;
            }
            {
                /* You're allowed to omit       *
                 * some initalizations          *
                 * using this notation          */

                Vector3 vector = new Vector3()
                {
                    z = 3.0f
                };
                transform.position = vector;
            }
            {
                /* initalizing POD with constructors    */
                int i = new int();
                Debug.Log("new int(): " + i); //new int(): 0
            }
        }
        #endregion

        private void Start()
        {
            /* * * * * * * * * * * * * * * * * * * * *
             * Section 5.4.2 New                     *
             * * * * * * * * * * * * * * * * * * * * */
            UseNew();

            /* * * * * * * * * * * * * * * * * * * * *
             * Section 5.4.3 Constructors            *
             * * * * * * * * * * * * * * * * * * * * */
            UseConstructors();
        }
    }
}

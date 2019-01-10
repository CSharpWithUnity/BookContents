/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 5.3.4 Object                                              *
 *                                                                   *
 * Copyright © 2018 Alex Okita                                       *
 *                                                                   *
 * This software may be modified and distributed under the terms     *
 * of the MIT license.  See the LICENSE file for details.            *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
namespace Chapter5_3_4
{
    using Chapter5_3_3;
    using UnityEngine;

    public class ObjectFinder : MonoBehaviour
    {
        #region Chapter 5.3.4 Object
        /* * * * * * * * * * * * *
         * Section 5.3.4 Object  *
         * * * * * * * * * * * * */

        // Use this for initialization
        void Start()
        {
            Object[] objects = FindObjectsOfType(typeof(Object));
            foreach (Object o in objects)
            {
                //Debug.Log(o);
                /* uncomment the line above to see all objects */

                ObjectParent parent = o as ObjectParent;
                if (parent != null)
                {
                    Debug.Log("FoundParent:" + parent);
                }
            }

            /* * * * * * * * * * * * * * * * * * * * * *
             * Section 5.3.4.1 A Type is not an Object *
             * * * * * * * * * * * * * * * * * * * * * */

            //FindObjectsOfType(Object);
            /* Uncomment the line above to see the error. */
        }
        #endregion

        #region Chapter5.3.5 != null
        /* * * * * * * * * * * * * *
         * Section 5.3.5 != null   *
         * * * * * * * * * * * * * */
        public GameObject foundObject;
        /* We'll assign the foundObject when    *
         * we find a ChildObject script on      *
         * a GameObject                         */

        // Update is called once per frame
        void Update()
        {
            if (foundObject == null)
            {
                Object[] objects = FindObjectsOfType(typeof(GameObject));
                // a list of all game objects in the scene

                foreach (GameObject o in objects)
                {
                    Debug.Log(o);
                    ObjectChild child = o.GetComponent(typeof(ObjectChild)) as ObjectChild;
                    /* child is initialized as null         *
                     * if GetComponent returns an object    *
                     * then child is not null               */
                    if (child != null)
                    {
                        foundObject = o;
                        /* if child isn't null              *
                         * then we found an object          *
                         * with the ObjectChild attached    */
                    }
                }
            }
        }
        #endregion
    }
}

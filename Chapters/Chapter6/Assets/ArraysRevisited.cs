/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 6.5 Arrays Revisited                                      *
 *                                                                   *
 * Copyright © 2018 Alex Okita                                       *
 *                                                                   *
 * This software may be modified and distributed under the terms     *
 * of the MIT license.  See the LICENSE file for details.            *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

namespace Chapter6_5
{
    using UnityEngine;
    public class ArraysRevisited : MonoBehaviour
    {
        #region Chapter 6.5.1 Arrays Revisited
        /* * * * * * * * * * * * * * * * * * *
         * Chapter 6.5.1 Arrays Revisited    *
         * * * * * * * * * * * * * * * * * * */
        public GameObject box1;
        public GameObject box2;
        public GameObject box3;
        public GameObject box4;
        public GameObject box5;
        public GameObject box6;
        public GameObject box7;
        public GameObject box8;
        public GameObject box9;
        public GameObject box10;

        public GameObject[] boxes;

        //a single int
        int MyInt;
        // an array of ints
        int[] MyInts;
        // a single object
        object MyObject;
        //an array of objects
        object[] MyObjects;

        public GameObject[] TenGameObjects = new GameObject[10];

        public int numBoxes = 10;
        public GameObject[] SomeBoxes;

        // Section 6.5.1.1
        public float Spacing;

        GameObject[] MonsterBoxes;

        void UseArrays()
        {
            {
                /* * * * * * * * * * * * * * * * * *
                 * Section 6.5.1.1 Starting with 0 *
                 * * * * * * * * * * * * * * * * * */
                SomeBoxes = new GameObject[numBoxes];
                for (int i = 0; i < numBoxes; i++)
                {
                }
            }

            {
                /* * * * * * * * * * * * * * * * *
                 * Section 6.5.1.1 Continued...  *
                 * * * * * * * * * * * * * * * * */
                SomeBoxes = new GameObject[numBoxes];
                for (int i = 0; i < numBoxes; i++)
                {
                    GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    SomeBoxes[i] = box;
                }
            }

            {
                /* * * * * * * * * * * * * * * * *
                 * Section 6.5.1.1 Continued...  *
                 * * * * * * * * * * * * * * * * */
                int i = 0;
                foreach (GameObject go in SomeBoxes)
                {
                    go.transform.position = new Vector3(1.0f, 0, 0);
                    i++;
                    Debug.Log("Box: " + i);
                }
            }

            {
                /* * * * * * * * * * * * * * * * *
                 * Section 6.5.1.1 Continued...  *
                 * * * * * * * * * * * * * * * * */
                int i = 0;
                foreach (GameObject go in SomeBoxes)
                {
                    go.transform.position = new Vector3(i * 1.0f, 0, 0);
                    i++;
                    Debug.Log("Box: " + i);
                }
            }

            {
                /* * * * * * * * * * * * * * * * *
                 * Section 6.5.1.1 Continued...  *
                 * * * * * * * * * * * * * * * * */
                int i = 0;
                foreach (GameObject go in SomeBoxes)
                {
                    go.transform.position = new Vector3(i * Spacing, 0, 0);
                    i++;
                    Debug.Log("Box: " + i);
                }
            }
        }

        /* * * * * * * * * * * * *
         * Section 6.5.1.2 Mathf *
         * * * * * * * * * * * * */
        void UseMathf()
        {
            int i = 0;
            foreach (GameObject go in SomeBoxes)
            {
                float wave = Mathf.Sin(Time.fixedTime + i);
                go.transform.position = new Vector3(i * Spacing, wave, 0);
                i++;
            }
        }
        #endregion

        #region Chapter 6.5.2 Instancing with AddComponent()
        /* * * * * * * * * * * * * * * * * * * * * * * * *
         * Section 6.5.2 Instancing with AddComponent()  *
         * * * * * * * * * * * * * * * * * * * * * * * * */
        void UseInstancingWithAddComponent()
        {
            MonsterBoxes = new GameObject[numBoxes];
            for (int i = 0; i < numBoxes; i++)
            {
                GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
                box.AddComponent(typeof(Monster));
                MonsterBoxes[i] = box;
            }
        }
        #endregion

        #region Chapter 6.5.3 Type Casting Unity 3D Objects
        /* * * * * * * * * * * * * * * * * * * * * * * *
         * Section 6.5.3 Type Casting Unity 3D Objects *
         * * * * * * * * * * * * * * * * * * * * * * * */
        void UseTypeCastingWithUnityObjects()
        {
            MonsterBoxes = new GameObject[numBoxes];
            for (int i = 0; i < numBoxes; i++)
            {
                GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
                box.AddComponent(typeof(Monster));
                Monster m = box.GetComponent(typeof(Monster)) as Monster;
                m.ID = i;
                MonsterBoxes[i] = box;
            }
        }

        #endregion

        private void Start()
        {
            /* * * * * * * * * * * * * * * * * *
             * Section 6.5.1.1 Starting with 0 *
             * * * * * * * * * * * * * * * * * */
            UseArrays();

            /* * * * * * * * * * * * * * * * * * * * * * * * *
             * Section 6.5.2 Instancing with AddComponent()  *
             * * * * * * * * * * * * * * * * * * * * * * * * */
            UseInstancingWithAddComponent();

            /* * * * * * * * * * * * * * * * * * * * * * * *
             * Section 6.5.3 Type Casting Unity 3D Objects *
             * * * * * * * * * * * * * * * * * * * * * * * */
            UseTypeCastingWithUnityObjects();
        }

        void Update()
        {
            /* * * * * * * * * * * * *
             * Section 6.5.1.2 Mathf *
             * * * * * * * * * * * * */
            UseMathf();
        }
    }
}
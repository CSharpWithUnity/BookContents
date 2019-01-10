/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 5.9 Arrays A First Look                                   *
 *                                                                   *
 * Copyright © 2018 Alex Okita                                       *
 *                                                                   *
 * This software may be modified and distributed under the terms     *
 * of the MIT license.  See the LICENSE file for details.            *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
namespace Chapter5_9
{
    using UnityEngine;

    public class ArraysAFirstLook : MonoBehaviour
    {
        #region Chapter 5.9 Introduction
        /* * * * * * * * * * * * * * * * * * * * *
         * Section 5.9 Arrays a first look...    *
         * * * * * * * * * * * * * * * * * * * * */

        /* not the best way to  *
         * store lots of data   */
        int score1;
        int score2;
        int score3;
        int score4;
        int score5;
        int score6;
        int score7;
        int score8;
        int score9;
        int score10;
        /* if you've guess there's a much better way *
         * to store lots of data like that then      *
         * you'd be correct.                         */
        #endregion

        #region Chapter 5.9.1 Fixed Sized Arrays
        /* * * * * * * * * * * * * * * * * * * * *
         * Section 5.9.1 Fixed Sized Arrays      *
         * * * * * * * * * * * * * * * * * * * * */

        public int[] scores = new int[10];
        public string[] strings = new string[10];
        public float[] floats = new float[10];

        /* not the best array for score values  */
        public string[] TopScoreList = new string[10];

        /* an array of classes                  */
        public class MyClass { }
        public MyClass[] MyClasses = new MyClass[10];

        /* array of GameObject                  */
        public GameObject[] GameObjects;

        void UseFixedSizedArrays()
        {
            Debug.Log(GameObjects.Length);
            for (int i = 0; i < GameObjects.Length; i++)
            {
                GameObjects[i].name = i.ToString();
            }
            /* * * * * * * * * * * * * * * * * * * * * * * *
             * Section 5.9.2.1 Foreach, a Basic Example... *
             * * * * * * * * * * * * * * * * * * * * * * * */
            foreach (GameObject go in GameObjects)
            {
                Debug.Log(go.name);
            }
        }
        #endregion

        #region Chapter 5.9.3 Dynamic Initialization
        /* * * * * * * * * * * * * * * * * * * * *
         * Section 5.9.3 Dynamic Initialization  *
         * * * * * * * * * * * * * * * * * * * * */
        void UseDynamicInitialization()
        {
            {
                float[] dynamicFloats = new float[10];
            }
            {
                /*
                 * Section 5.9.3 continued...
                 */
                float[] dynamicFloats;
                dynamicFloats = new float[10];
            }
            {
                /*
                 * Section 5.9.3 continued...
                 */
                float[] dynamicFloats;
                int numFloats = 10;
                dynamicFloats = new float[numFloats];
            }
        }
        #endregion

        #region Chapter 5.9.4 Using While Loops with Arrays
        /* * * * * * * * * * * * * * * * * * * * * * * *
         * Section 5.9.4 Using While Loop with Arrays  *
         * * * * * * * * * * * * * * * * * * * * * * * */
        void UseWhileLoopsWithArrays()
        {
            int[] scores = new int[10];
            int i = 0;
            while (i < 10)
            {
                Debug.Log(scores[i]);
                i++;
            }
        }
        #endregion

        #region Chapter 5.9.4.1 Setting Array Values
        /* * * * * * * * * * * * * * * * * * * * * * * *
         * Section 5.9.4.1 Setting Array Values        *
         * * * * * * * * * * * * * * * * * * * * * * * */
        void UseSettingArrayValues()
        {
            int[] scores = new int[10];
            scores[0] = 10;
            int i = 0;
            while (i < 10)
            {
                scores[i] = UnityEngine.Random.Range(0, 100);
                Debug.Log(scores[i]);
                i++;
            }
        }
        #endregion

        #region Chapter 5.9.4.2 Getting Array Values
        /* * * * * * * * * * * * * * * * * * * * * * * *
         * Section 5.9.4.2 Getting Array Values        *
         * * * * * * * * * * * * * * * * * * * * * * * */
        void UseGettingArrayValues()
        {
            int[] scores = new int[10];
            scores[0] = 10;
            int i = 0;
            while (i < 10)
            {
                scores[i] = UnityEngine.Random.Range(0, 100);
                int score = scores[i];
                Debug.Log(score);
                i++;
            }
        }
        #endregion

        void Start()
        {
            /* * * * * * * * * * * * * * * * * * * * *
             * Section 5.9.1 Fixed Sized Arrays      *
             * * * * * * * * * * * * * * * * * * * * */
            UseFixedSizedArrays();

            /* * * * * * * * * * * * * * * * * * * * *
             * Section 5.9.3 Dynamic Initialization  *
             * * * * * * * * * * * * * * * * * * * * */
            UseDynamicInitialization();

            /* * * * * * * * * * * * * * * * * * * * * * * *
             * Section 5.9.4 Using While Loop with Arrays  *
             * * * * * * * * * * * * * * * * * * * * * * * */
            UseWhileLoopsWithArrays();

            /* * * * * * * * * * * * * * * * * * * * * * * *
             * Section 5.9.4.1 Setting Array Values        *
             * * * * * * * * * * * * * * * * * * * * * * * */
            UseSettingArrayValues();

            /* * * * * * * * * * * * * * * * * * * * * * * *
             * Section 5.9.4.2 Getting Array Values        *
             * * * * * * * * * * * * * * * * * * * * * * * */
            UseGettingArrayValues();
        }

        public int[] primes = new int[] { 1, 3, 5, 7, 11, 13, 17 };
    }
}

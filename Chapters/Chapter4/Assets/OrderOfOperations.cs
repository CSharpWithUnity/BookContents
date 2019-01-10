/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 4.7 Order of Operation                                    *
 *                                                                   *
 * Copyright © 2018 Alex Okita                                       *
 *                                                                   *
 * This software may be modified and distributed under the terms     *
 * of the MIT license.  See the LICENSE file for details.            *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
namespace Chapter4_7
{
    using UnityEngine;

    public class OrderOfOperations : MonoBehaviour
    {
        #region Chapter 4.7 Order of Operation: What is calculated and When
        /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
         * Section 4.7 Order of Operation: What is calculated and When *
         * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
        void UseOrderOfOperation()
        {
            int a = 1;
            Debug.Log(a); // 1
            a = a + 3;
            Debug.Log(a); // 4
            a = a * 7;
            Debug.Log(a); // 28

            int b = 1 + 3 * 7;
            Debug.Log(b); // 22
        }
        #endregion

        #region Chapter 4.7.1.1 Math
        /* * * * * * * * * * * * *
         * Section 4.7.1.1 Math  *
         * * * * * * * * * * * * */
        void UseMath()
        {
            Debug.Log(10 / 3);
            Debug.Log(10f / 3f);
            Debug.Log(10.0 / 3.0);
            Debug.Log(10000000.0f / 3.0f);
            Debug.Log(1000000000000000.0 / 3.0);
        }

        // Update is called once per frame
        int mod = 1;
        void Update()
        {
            int mod12 = mod % 12;
            Debug.Log(mod + " mod 12 = " + mod12);
            mod++;
        }
        #endregion

        #region Chapter 4.7.1.2 Operator Evaluation
        /* * * * * * * * * * * * * * * * * * * *
         * Section 4.7.1.2 Operator Evaluation *
         * * * * * * * * * * * * * * * * * * * */
        void UseOperatorEvaluation()
        {
            int c = (1 + 3) * 7;
            Debug.Log(c);

            int d = 1 + 3 * 7 + 9;
            Debug.Log(d);

            int e = 1 + 3 * (7 + 9);
            Debug.Log(e);

            int f = (11 * ((9 * 3) * 2));
            Debug.Log(f);

            int g = ((((11 * ((9 * 3) * 2)))));
            Debug.Log(g);

            int h = 9 * 3;
            int i = h * 2;
            int j = i * 11;
            Debug.Log(j);
        }
        #endregion

        void Start()
        {
            /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
             * Section 4.7 Order of Operation: What is calculated and When *
             * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

            /* uncomment or comment the line below to see the code in action! */
            UseOrderOfOperation();

            /* * * * * * * * * * * * *
             * Section 4.7.1.1 Math  *
             * * * * * * * * * * * * */

            /* uncomment or comment the line below to see the code in action! */
            UseMath();

            /* * * * * * * * * * * * * * * * * * * *
             * Section 4.7.1.2 Operator Evaluation *
             * * * * * * * * * * * * * * * * * * * */

            /* uncomment or comment the line below to see the code in action! */
            UseOperatorEvaluation();
        }
    }
}


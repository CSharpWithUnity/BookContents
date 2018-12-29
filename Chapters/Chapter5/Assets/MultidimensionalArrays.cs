/*
 * Chapter 5.10 Multidimensional Arrays
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using UnityEngine;

public class MultidimensionalArrays : MonoBehaviour
{
    #region Chapter 5.10 Multidimensional Arrays
    /* * * * * * * * * * * * * * * * * * * * * * *
     * Section 5.10 Arrays                       *
     * * * * * * * * * * * * * * * * * * * * * * */
    void UseArray()
    {
        /* Section 5.10 Multidimensional Arrays *
         * single dimensional arrays are [1]    *
         * dimensions in size.                  */
        {
            Object[] objects = new Object[10];
            for (int i = 0; i < objects.Length; i++)
            {
                Debug.Log(objects[i]);
            }
        }
        {
            /* Multidimensional arrays have more than   *
             * one [1] size.                            *
             * a [,] array is a two dimensional array.  */

            Object[,] objects = new Object[2, 3];
            for (int i = 0; i < objects.Length; i++)
            {
                Debug.Log(i);
                /* how do we address    *
                 * two parameters in    *
                 * a multi dimensional  *
                 * array                */
            }
        }
    }
    #endregion
    #region Chapter 5.10.1.1 A Basic Example
    void UseTwoDimensions()
    {
        /* * * * * * * * * * * * * * * * * * * *
         * Section 5.11.1.1 A Basic Example    *
         * * * * * * * * * * * * * * * * * * * */
        GameObject a = new GameObject("a");
        GameObject b = new GameObject("b");
        GameObject c = new GameObject("c");
        GameObject d = new GameObject("d");
        GameObject e = new GameObject("e");
        GameObject f = new GameObject("f");
        GameObject[,] twoDimensions = new GameObject[2, 3] { { a, b, c }, { d, e, f } };
        /*
         * We can Initialize an array with this method.
         * {
         *     {a,b,c},
         *     {d,e,f}
         * };
         * is another way to look at the same
         * initialization to make the columns
         * and rows more visible.
         */
        InspectArray(twoDimensions);

        void InspectArray(GameObject[,] gameObjects)
        {
            int columns = gameObjects.GetLength(0);
            Debug.Log("columns:" + columns);
            int rows = gameObjects.GetLength(1);
            Debug.Log("rows:" + rows);
            for (int column = 0; column < columns; column++)
            {
                for (int row = 0; row < rows; row++)
                {
                    Debug.Log(gameObjects[column, row].name);
                }
            }
        }
    }
    #endregion
    #region Chapter 5.10.5 MultiDimensional Arrays - What We've Learned
    /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
     * Section 5.11.5 MultiDimensional Arrays - What We've Learned *
     * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
    void MultiDimensionArrayExample()
    {
        GameObject a = new GameObject("a");
        GameObject b = new GameObject("b");
        GameObject c = new GameObject("c");
        GameObject d = new GameObject("d");
        GameObject e = new GameObject("e");
        GameObject f = new GameObject("f");
        GameObject[,,] threeDimensions = new GameObject[4, 3, 2]
        {
            { {a, b}, { c, d}, { e, f} },
            { {a, b}, { c, d}, { e, f} },
            { {a, b}, { c, d}, { e, f} },
            { {a, b}, { c, d}, { e, f} }
        };
    }
    #endregion

    void Start()
    {
        /* * * * * * * * * * * * * * * * * * * * * * *
         * Section 5.10 Arrays                       *
         * * * * * * * * * * * * * * * * * * * * * * */
        UseArray();

        /* * * * * * * * * * * * * * * * * * * * * * *
         * Section 5.10.1.1 A Basic Example          *
         * * * * * * * * * * * * * * * * * * * * * * */
        UseTwoDimensions();
    }
}


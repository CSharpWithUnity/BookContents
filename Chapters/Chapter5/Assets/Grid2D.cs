/*
 * Chapter 5.11 Multidimensional Arrays
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

using UnityEngine;
public class Grid2D : MonoBehaviour
{
    public int Width;
    public int Height;
    public GameObject PuzzlePiece;
    public GameObject[,] Grid;
    /*
     * Section 5.11.2 A Puzzle Board
     */
    void Start()
    {
        Grid = new GameObject[Width, Height];
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                Vector3 position = new Vector3(x, y, 0);
                GameObject go = GameObject.Instantiate(PuzzlePiece) as GameObject;
                go.transform.position = position;
                Grid[x, y] = go;
            }
        }
    }
}


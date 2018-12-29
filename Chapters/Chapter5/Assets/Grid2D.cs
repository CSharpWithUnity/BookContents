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
    public Vector3 mousePosition;
    void Start()
    {
        /*
         * Section 5.11.2 Creating a 2D grid
         * of game objects.
         */
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
        /*
         * Section 5.11.2 Camera Setup
         */
        // change camera projection
        Camera.main.orthographic = true;
        Camera.main.orthographicSize = Width/2;
        Camera.main.farClipPlane = 20;

        // move the camera into position
        float xPos = (Width * 0.5f) - 0.5f;
        float yPos = (Height * 0.5f) - 0.5f;
        Camera.main.transform.position = new Vector3(xPos, yPos, -5);

        // build background
        GameObject collider = GameObject.CreatePrimitive(PrimitiveType.Plane);
        collider.transform.localScale = new Vector3(Width * 0.1f, 1, Height * 0.1f);
        collider.transform.eulerAngles = new Vector3(-90, 0, 0);
        collider.transform.position = new Vector3(xPos, yPos, 0);
        collider.AddComponent(typeof(Collider));
    }
    /* * * * * * * * * * * * * * * * * * * * * *
     * Section 5.11.2 continued...             *
     * * * * * * * * * * * * * * * * * * * * * */
    void Update()
    {
        /* Update Mouse Position */
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            mousePosition = hit.point;
        }

        Debug.DrawLine(Vector3.zero, mousePosition);
        /* Send the mouse position to       *
         * be evaluated in a new function.  */
        PickPuzzlePiece(mousePosition);
    }

    public int xGrid;
    public int yGrid;
    void PickPuzzlePiece(Vector3 position)
    {
        int x = (int)(position.x + 0.5f);
        int y = (int)(position.y + 0.5f);

        {
            /* a long winded way of validating  *
             * x and y values.                  */
            if (x >= 0)
            {
                if (x < Width)
                {
                    if (y >= 0)
                    {
                        if (y < Height)
                        {
                            //GameObject gameObject = Grid[x, y];
                        }
                    }
                }
            }
        }

        {
            /* Also valid, but might be a bit confusing */
            if (x >= 0 && x < Width && y >= 0 && y < Height)
            {
                xGrid = x;
                yGrid = y;
            }
        }

        {
            /* A much better way to validate    *
             * x and y                          */
            if (x >= 0 && x < Width)
            {
                xGrid = x;
            }
            if (y >= 0 && y < Height)
            {
                yGrid = y;
            }
        }

        /* set all of the game objects to white */
        for (int w = 0; w < Width; w++)
        {
            for (int h = 0; h < Height; h++)
            {
                GameObject go = Grid[w, h];
                Renderer renderer = go.GetComponent(typeof(Renderer)) as Renderer;
                renderer.material.color = Color.white;
            }
        }

        {
            /* set the one that the mouse is near to red */
            GameObject go = Grid[xGrid, yGrid];
            Renderer renderer = go.GetComponent(typeof(Renderer)) as Renderer;
            renderer.material.color = Color.red;
        }
    }
}


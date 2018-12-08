/*
 * Chapter 6.24 Room Generator
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter6
{
    [ExecuteInEditMode]
    public class RoomGenerator : MonoBehaviour
    {
        public bool GenerateRooms;
        public GameObject WallObject;
        public int RoomCount = 5;
        // minimum is 5.
        public int MaxRoomWidth = 7;
        public int MaxRoomDepth = 7;
        private List<GameObject> WallObjectList;

        // Update is called once per frame
        void Update()
        {
            if (GenerateRooms)
            {
                GenerateRooms = false;

                // clear any walls
                if (WallObjectList != null)
                {
                    foreach (GameObject wall in WallObjectList)
                    {
                        DestroyImmediate(wall);
                    }
                }
                // create list to remember objects to clear
                WallObjectList = new List<GameObject>();


                /*      14-6 = 8                                        */
                /*     ₓ┌──────┐ₓₓₓₓₓ                                   */
                /*     12345678901234                                   */
                /*   ₓ1╔════════════╗  Width  = 14                      */
                /*   ┌2║①━━━┓▪▪▪▫▫▫▫║  Height = 13                      */
                /*   │3║┃◦◦◦┃▪▪▪▫▫▫▫║  ① is the first valid point       */
                /*   │4║┃◦◦◦┃▪▪▪▫▫▫▫║    to start a room.               */
                /* 13│5║┃◦◦◦┃▪▪▪▫▫▫▫║                                   */
                /* -6│6║┗━━━┛▪▪▪▫▫▫▫║                                   */
                /* ──│7║▪▪▪▪▪▪▪▪▫▫▫▫║  if MaxRoomWidth/Depth = 5        */
                /*  7└8║▪▪▪▪▪▪▪②━━━┓║  ② Last point in the area that    */
                /*   ₓ9║▫▫▫▫▫▫▫┃◦◦◦┃║    can fit a 5x5 room             */
                /*   ₓ0║▫▫▫▫▫▫▫┃◦◦◦┃║                                   */
                /*   ₓ1║▫▫▫▫▫▫▫┃◦◦◦┃║                                   */
                /*   ₓ2║▫▫▫▫▫▫▫┗━━━┛║                                   */
                /*   ₓ3╚════════════╝                                   */
                /*                                                      */
                /* if a room is going to be a                           */
                /* maximum size of 5x5 then the                         */
                /* last point we can select in                          */
                /* each row is 5 away from the                          */
                /* edge.                                                */

                // get some data for floor size
                FloorGenerator generator = GetComponent<FloorGenerator>();
                // get safe area
                int maxW = 1 + generator.Width - MaxRoomWidth;
                int maxD = 1 + generator.Depth - MaxRoomDepth;

                for (int i = 0; i < RoomCount; i++)
                {
                    // a point somewhere in the safe zone
                    int x = Random.Range(1, maxW);
                    int z = Random.Range(1, maxD);
                    MakeRoom(x, z, generator);
                }
            }
        }

        void MakeRoom(int x, int z, FloorGenerator generator)
        {
            // make a room size startPoint + width/height
            int sizeX = x + Random.Range(5, MaxRoomWidth);
            int sizeZ = z + Random.Range(5, MaxRoomDepth);

            // generate walls for the room
            for (int sX = x; sX < sizeX; sX++)
            {
                for (int sZ = z; sZ < sizeZ; sZ++)
                {
                    bool isEdge = sX == x || sX == sizeX - 1 || sZ == z || sZ == sizeZ - 1;
                    if (isEdge)
                    {
                        GameObject wall = Instantiate(WallObject, transform);
                        WallObjectList.Add(wall);
                        wall.transform.position = new Vector3()
                        {
                            x = sX - (generator.Width / 2),
                            z = sZ - (generator.Depth / 2)
                        };
                    }
                }
            }
        }
    }
}

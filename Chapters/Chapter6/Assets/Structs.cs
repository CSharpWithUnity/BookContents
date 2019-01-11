/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 6.8 Structs                                               *
 *                                                                   *
 * Copyright © 2018 Alex Okita                                       *
 *                                                                   *
 * This software may be modified and distributed under the terms     *
 * of the MIT license.  See the LICENSE file for details.            *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
namespace Chapter6_8
{
    using UnityEngine;

    public class Structs : MonoBehaviour
    {
        #region Chapter 6.8
        class WithoutStructs
        {
            float X;
            float Y;
            float Z;
            void SetX(float x)
            {
                X = x;
            }
            void SetY(float y)
            {
                Y = y;
            }
            void SetZ(float z)
            {
                Z = z;
            }

            void SetValues()
            {
                SetX(1.0f);
                SetY(1.0f);
                SetZ(1.0f);
            }

            void LogValues()
            {
                Debug.Log("X:" + X + "Y:" + Y + "Z:" + Z);
            }

            // or
            Vector3 Vector;
            void SetVector()
            {
                Vector = new Vector3(1, 1, 1);
            }
        }

        #endregion

        #region Chapter 6.8.1 Structs
        /*
         * Section 6.8.1 Structs
         * 
         * Structs are collections of
         * data in a single object.
         * 
         */
        public struct PlayerDataStruct
        {
            public Vector3 Position;
            public int HitPoints;
            public int Ammunition;
            public float RunSpeed;
            public float WalkSpeed;
        }
        #endregion

        #region Chapter 6.8.2 Struct versus Class
        PlayerDataStruct playerDataStruct;
        /* * * * * * * * * * * * * * * * * * *
         * Section 6.8.2 Struct versus Class *
         * * * * * * * * * * * * * * * * * * */

        /* a struct and a class can look alike. */
        public class PlayerDataClass
        {
            public Vector3 Position;
            public int HitPoints;
            public int Ammunition;
            public float RunSpeed;
            public float WalkSpeed;
        }
        PlayerDataClass playerDataClass;
        void UseStructVersusClass()
        {
            PlayerDataStruct playerStruct = new PlayerDataStruct();
            PlayerDataClass playerClass = new PlayerDataClass();
            playerStruct.HitPoints = 1;
            playerClass.HitPoints = 1;

            PlayerDataStruct otherPlayerStruct = playerStruct;
            otherPlayerStruct.HitPoints = 3; // change the copied data
            Debug.Log(playerStruct.HitPoints + " and " + otherPlayerStruct.HitPoints);
            // 1 and 3
            PlayerDataClass otherPlayerClass = playerClass;
            otherPlayerClass.HitPoints = 3; // change the copied data, or did we?
            Debug.Log(playerClass.HitPoints + " and " + otherPlayerClass.HitPoints);
            // 3 and 3

            PlayerDataClass anotherPlayerClass = new PlayerDataClass();
            anotherPlayerClass.HitPoints = playerClass.HitPoints;
            anotherPlayerClass.HitPoints = 7;
            Debug.Log(playerClass.HitPoints + ":" +
                      otherPlayerClass.HitPoints + ":" +
                      anotherPlayerClass.HitPoints);
            // 3:3:7
        }
        #endregion

        #region Chapter 6.8.3 Without Structs?
        /* * * * * * * * * * * * * * * * * *
         * Section 6.8.3 Without Structs?  *
         * * * * * * * * * * * * * * * * * */
        void UseWithoutStructs()
        {
            object[] playerDataArray = new object[5]
            {
                new Vector3(),  // Position
                10,             // HitPoints
                13,             // Ammunition
                6.5f,           // Run Speed
                1.2f            // Walk Speed
            };
            object[] copyOfPlayerDataArray = playerDataArray;
            Debug.Log(playerDataArray[1]);
            // 10
            copyOfPlayerDataArray[1] = 1;
            Debug.Log(playerDataArray[1] + ":" + copyOfPlayerDataArray[1]);
            // 1:1
        }
        #endregion

        #region Chapter 6.8.4 Handling Structs
        /* * * * * * * * * * * * * * * * * *
         * Section 6.8.4 Handling Structs  *
         * * * * * * * * * * * * * * * * * */
        struct BoxParams
        {
            public float width;
            public float height;
            public float depth;
            public Color color;
        }

        void StartCube()
        {
            // Called in Start()
            BoxParams box = new BoxParams();
            box.width = 2;
            box.height = 3;
            box.depth = 4;
            box.color = Color.red;
            // calling to function with box params
            CreateCube(box);
        }

        void CreateCube(BoxParams b)
        {
            // incoming box from StartCube() is renamed b
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            // b.width height and depth are used to change the size of the
            // box created by the line above
            go.transform.localScale = new Vector3(b.width, b.height, b.depth);
            go.GetComponent<MeshRenderer>().material.color = b.color;
        }
        #endregion

        void Start()
        {
            /* * * * * * * * * * * * * * * * * * * * *
             * Section 6.8.2 Structs versus Classes  *
             * * * * * * * * * * * * * * * * * * * * */
            UseStructVersusClass();

            /* * * * * * * * * * * * * * * * * *
             * Section 6.8.3 Without Structs?  *
             * * * * * * * * * * * * * * * * * */
            UseWithoutStructs();

            /* * * * * * * * * * * * * * * * * *
             * Section 6.8.4 Handling Structs  *
             * * * * * * * * * * * * * * * * * */
            StartCube();
        }
    }

    // not inside of the Structs script
    public struct PublicBoxParams
    {
        public float width;
        public float height;
        public float depth;
        public Color color;
    }

    public class OtherClass
    {
        //BoxParams Not accesible
        PublicBoxParams box;
        //Public Box Params is visible!

        BoxParameters globalBox;
        // Found in Global.cs
    }
}
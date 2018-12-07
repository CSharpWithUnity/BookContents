using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter6
{
    [ExecuteInEditMode]
    public class FloorGenerator : MonoBehaviour
    {
        // Trigger in the Inspector Panel to
        // generate tiles
        public bool GenerateTiles;
        // Original prefab objects to make
        // a tile floor from
        public GameObject[] TileOriginals;
        // a List of tiles to store if
        // we want to make new tiles
        public GameObject[,] TileObjects;
        // How many tiles to make
        public int Width;
        public int Depth;
        private List<GameObject> TileObjectList;

        void Update()
        {
            if (GenerateTiles)
            {
                GenerateTiles = false;

                //clear any tiles that might already be there
                if (TileObjectList != null)
                {
                    foreach (GameObject tile in TileObjectList)
                    {
                        DestroyImmediate(tile);
                    }
                }
                TileObjectList = new List<GameObject>();

                TileObjects = new GameObject[Width, Depth];
                for (int x = 0; x < Width; x++)
                {
                    for (int z = 0; z < Depth; z++)
                    {
                        int o = (z + x) % TileOriginals.Length;
                        TileObjects[x, z] = GameObject.Instantiate(TileOriginals[o], transform);
                        TileObjects[x, z].transform.position = new Vector3()
                        {
                            x = x - (Width / 2),
                            z = z - (Depth / 2)
                        };
                        // keep track of what to delete when we
                        // need to make a new set of tiles.
                        TileObjectList.Add(TileObjects[x, z]);
                    }
                }
            }
        }
    }
}

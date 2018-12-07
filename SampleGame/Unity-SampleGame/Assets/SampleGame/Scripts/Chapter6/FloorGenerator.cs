using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public GameObject[] TileObjects;
    // How many tiles to make
    public int Width;
    public int Depth;

    void Update()
    {
        if (GenerateTiles)
        {
            GenerateTiles = false;

            //clear any tiles that might already be there
            if (TileObjects.Length > 0)
            {
                foreach (GameObject go in TileObjects)
                {
                    DestroyImmediate(go);
                }
                TileObjects = null;
            }

            // Make new tiles
            List<GameObject> tiles = new List<GameObject>();
            for (int x = 0; x < Width; x++)
            {
                for (int z = 0; z < Depth; z++)
                {
                    int o = (z + x) % TileOriginals.Length;
                    GameObject tile = GameObject.Instantiate(TileOriginals[o], transform);
                    tile.transform.position = new Vector3()
                    {
                        x = x - (Width/2),
                        z = z - (Depth/2)
                    };
                    tiles.Add(tile);
                }
            }
            TileObjects = new GameObject[tiles.Count];
            tiles.CopyTo(TileObjects);
        }
    }
}

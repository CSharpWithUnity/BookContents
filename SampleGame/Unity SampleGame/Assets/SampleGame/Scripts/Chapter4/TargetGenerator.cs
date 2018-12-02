using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGenerator : MonoBehaviour
{
    public GameObject Target;
    public int NumTargets;
    public int TargetCount;

    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < 10; x++)
        {
            for (int z = 0; z < 10; z++)
            {
                Vector3 position = new Vector3()
                {
                    x = x - 5,
                    y = 0,
                    z = z - 5
                };

                if (x + z %2 == 0)
                {
                    Instantiate(Target, position, Quaternion.identity);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

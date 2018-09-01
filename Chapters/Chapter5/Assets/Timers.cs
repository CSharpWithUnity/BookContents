/*
 * Chapter 5.14 Timers
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

using UnityEngine;

public class Timers : MonoBehaviour
{
    public float NextTime;
    public float Delay = 0.5f;
    public int Counter = 10;
    public int MinimumHeight = 1;
    public int MaximumHeight = 10;
    public float XSpacing = 1.2f;
    public float YSpacing = 1.2f;
    public float ZSpacing = 1.2f;
    void Update()
    {
        /*
         * Section 5.14.1 Timers
         *
        {

            Debug.Log(Time.fixedTime);
        }

        {
            if (Time.fixedTime > 3)
            {
                Debug.Log("Times Up");
            }
        }

        {
            if (Time.fixedTime > NextTime)
            {
                NextTime = Time.fixedTime + 3;
                Debug.Log("Times Up");
            }
        }

        {
            if (Counter > 0)
            {
                if (Time.fixedTime > NextTime)
                {
                    NextTime = Time.fixedTime + 3;
                    Counter--;
                    Debug.Log("Times Up");
                }
            }
        }

        {
            if (Counter > 0 && Time.fixedTime > NextTime)
            {
                NextTime = Time.fixedTime + Delay;
                Counter--;
                Debug.Log("Times Up");
            }
        }
        {
            if (Counter > 0 && Time.fixedTime > NextTime)
            {
                GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
                box.transform.position = new Vector3(Counter * 2f, 0, 0);
                NextTime = Time.fixedTime + Delay;
                Counter--;
                Debug.Log("Times Up");
            }
        }
        {
            if (Counter > 0 && Time.fixedTime > NextTime)
            {
                int vertical = UnityEngine.Random.Range(0, 10);
                for (int i = 0; i < vertical; i++)
                {
                    GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    box.transform.position = new Vector3(Counter * 2f, i, 0);
                }
                NextTime = Time.fixedTime + Delay;
                Counter--;
                Debug.Log("Times Up");
            }
        }


        {
            if (Counter > 0 && Time.fixedTime > NextTime)
            {
                int vertical = UnityEngine.Random.Range(MinimumHeight, MaximumHeight);
                for (int i = 0; i < vertical; i++)
                {
                    GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    box.transform.position = new Vector3(Counter * XSpacing, i * YSpacing, 0);
                }
                NextTime = Time.fixedTime + Delay;
                Counter--;
                Debug.Log("Times Up");
            }
        }
    Move this comment to different sections to see how
    the different sets of code behave.
    */
        {
            if (Counter > 0 && Time.fixedTime > NextTime)
            {
                for (int i = 0; i < 10 ; i++)
                {
                    int vertical = UnityEngine.Random.Range(MinimumHeight, MaximumHeight);
                    for (int j = 0; j < vertical; j++)
                    {
                        GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        Vector3 position = new Vector3()
                        {
                            x = Counter * XSpacing,
                            y = j * YSpacing,
                            z = i * ZSpacing
                        };
                        box.transform.position = position;
                    }
                }
                NextTime = Time.fixedTime + Delay;
                Counter--;
                Debug.Log("Times Up");
            }
        }
    }
}

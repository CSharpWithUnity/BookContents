/*
 * Chapter 6.5 Arrays Revisited
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using UnityEngine;
public class Monster : MonoBehaviour
{
    public int ID;
    public float Spacing = 1.1f;
    void Start()
    {
        Debug.Log("Im Alive!");
    }

    /*
     * Section 6.5.3 Type Casting Unity 3D Objects
     */
    void Update()
    {
        float wave = Mathf.Sin(Time.fixedTime + ID);
        transform.position = new Vector3(ID * Spacing, wave, 0);
    }
}

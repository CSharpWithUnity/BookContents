/*
 * Chapter 3.10 UsingTheVariables
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

using UnityEngine;

public class UsingTheVariables : MonoBehaviour
{
    /*
     * Section 3.10.3 Using The Variables
     */

    public float RotationSpeed;
    public float Rotation;
    public float ForwardSpeed;

	// Use this for initialization
	void Start ()
    {
		
	}

	// Update is called once per frame
	void Update ()
    {
        /*
         * Section 3.10.3 continued...
         * 
         * Update the Rotation with RotationSpeed
         * multiplied by Time.deltaTime.
         */

        Rotation += RotationSpeed * Time.deltaTime;

        /*
         * now add this to the objects Y rotation
         * the second value in the object's local
         * euler angles.
         */

        transform.localEulerAngles = new Vector3(0, Rotation, 0);

        /*
         * the transform.forward value is something provided
         * by the Unity API.
         */

        transform.position += transform.forward * (ForwardSpeed * Time.deltaTime);
	}
}

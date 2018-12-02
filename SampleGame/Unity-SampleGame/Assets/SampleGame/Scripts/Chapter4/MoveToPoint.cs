/*
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPoint : MonoBehaviour {
    public GameObject myTransformObject;
    public Vector3 moveToPosition;
	// Use this for initialization
	void Start () {
        myTransformObject = GameObject.Find("TransformPrimitive");
	}
	
	// Update is called once per frame
	void Update () {
        /*
         * Section 4.3.2 MoveToPoint
         * 
         * Make the robot look at the Transform Primitive
         * first get the rotation value that is the rotation to
         * rotate the robot to.
         */

        Vector3 lookTarget = myTransformObject.transform.position - transform.position;
        
        /* The Look at target is a 3d point in the world relative to the
         * current position from the target position.
         */

        Quaternion direction = Quaternion.LookRotation(lookTarget, transform.up);
        /*
         * Get the rotation result of an interpolation from Slerp
         * then assign it to the rotation of the robot
         */
        transform.rotation = Quaternion.Slerp(transform.rotation, direction, Time.deltaTime * 5f);

        if (Input.GetMouseButton(0))
        {
            /*
             * while the mouse is down update the move to position
             * to where the transform primitive is located
             */
            moveToPosition = myTransformObject.transform.position;
        }
        /*
         * finally lets move to the moveToPosition with another
         * interpolated result.
         */
        transform.position = Vector3.Lerp(transform.position, moveToPosition, Time.deltaTime);
	}
}

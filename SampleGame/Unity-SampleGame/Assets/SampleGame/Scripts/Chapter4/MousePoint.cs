using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePoint : MonoBehaviour {
    /*
     * these are variables that we'll cover soon
     */

    public Camera myCamera;
    public GameObject myTransformObject;
    // Use this for initialization
	void Start () {
        /*
         * Section 4.3.1 Mouse Point
         * first get the main camera from the scene.
         * then get the transform object reference.
         */

        myCamera = Camera.main;
        myTransformObject = GameObject.Find("TransformPrimitive");
        /*
         * more on how the above works will be coming when we cover how
         * these functions work, but continue on and see what happens
         * next.
         */
	}
	
	// Update is called once per frame
	void Update () {
        /*
         * Section 4.3.1 Mouse Point
         */

        Ray ray = myCamera.ScreenPointToRay(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 h = hit.point;
            h.y = 0;
            myTransformObject.transform.position = h;
        }
        /*
         * The ray becomes a line that starts at the myCamera as a point that passes
         * through the Input.mousePosition and continues through to the game world.
         * 
         * If the ray hits something with a collider on it
         * then Physics will tell us if that ray has collided with
         * a solid object in the world.
         */
	}
}

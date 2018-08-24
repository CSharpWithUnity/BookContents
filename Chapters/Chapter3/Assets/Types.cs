using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Types : MonoBehaviour {

	// Use this for initialization
	void Start () {
        /*
         * Section 3.12 Strong Typing
         */

        // Vector3 vec = new Vector3(1.0, 1.0, 1.0);

        /* Uncomment the line above to
         * see the error produced under the 1.0
         * values in the Vector3() constructor.
         */

        float f = 1.0f;
        double d = 1.0;

        /* The above assignments are
         * valid as the value assigned
         * match the type of the variable
         * being defined.
         */

        Vector3 vec = new Vector3(1.0f, 1.0f, 1.0f);
        
        /* The above works since we use the 1.0f
         * assignment for the float values.
         */
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

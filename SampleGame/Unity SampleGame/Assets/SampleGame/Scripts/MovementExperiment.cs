using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementExperiment : MonoBehaviour {

	// Use this for initialization
	void Start () {
        /* 
         * Section 3.3.1 Movement Experiments
         */
        gameObject.transform.position = new Vector3(0, 0, 1);
        /*
         * Section 3.3.2 Reading Programmer Documentation
         */
        gameObject.transform.localEulerAngles = new Vector3(45, 0, 0);

    }

    // Update is called once per frame
    void Update () {

    }
}

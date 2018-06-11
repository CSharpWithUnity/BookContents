using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstExample : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /*
     * A nested class can appear down below this comment.
     * 
     *    ┌─────────┐ ┌────────────┐
     *    │ keyword │ │ Identifier │
     *    └────┬────┘ └─────┬──────┘
     *   ┌─────┘            │
     *   │       ┌──────────┘
     * ┌─┴─┐ ┌───┴────┐
     * class MyNewClass
     * {
     * }
     * ┬
     * └───────┐
     *   ┌─────┴──────┐
     *   │ separators │
     *   └────────────┘
     *
     * Don't forget the { and } separators following the class declaration.
     * 
     */

    class MyNewClass
    {

    }

}

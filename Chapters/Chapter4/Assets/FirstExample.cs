using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstExample : MonoBehaviour {

    /*
     * Section 4.4.1
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
     * The contents of the new class are defined inside of the curly braces
     * 
     */

    class MyNewClass
    {
    }


    // Use this for initialization
    void Start()
    {
        /*
         * Section 4.4.1.1
         * 
         * 
         *            MyNewClass newClass = new MyNewClass();
         * 
         */
        MyNewClass newClass = new MyNewClass();
    }

    // Update is called once per frame
    void Update()
    {

    }

}

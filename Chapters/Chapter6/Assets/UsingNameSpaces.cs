/*
 * Chapter 6.10 Namespaces
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

/*
 * Section 6.10.2 Directives in Namespaces
 */
using UnityEngine;
using MyNamespace; // added a directive to add our namespace
using AnotherNamespace; // added for section 6.10.3 ambiguous namespaces
public class UsingNameSpaces : MonoBehaviour
{
    void Start()
    {
        MyClass myClass = new MyClass();
        //myClass.MyFunction();

        MyNamespace.MyClass nsClass = new MyNamespace.MyClass();
        nsClass.MyFunction();

        //UniqueClass uClass = new UniqueClass();
        //uClass.MyFunction();
        /*
         * Uncomment the above to see the error caused by including
         * the using AnotherNamespace; directive.
         * alternatively, comment out the using AnotherNamespace;
         * directive to see that the UniqueClass is referencing
         * the MyNamespace version of the class identifier.
         */
        AnotherNamespace.UniqueClass anClass = new AnotherNamespace.UniqueClass();
        anClass.MyFunction();

        MyNamespace.SubSpace.MyClass subClass = new MyNamespace.SubSpace.MyClass();
    }
}

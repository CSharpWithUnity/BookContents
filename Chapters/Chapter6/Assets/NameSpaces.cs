/*
 * Chapter 6.10 Namespaces
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

/*
 * Section 6.10.1
 */
using UnityEngine;
namespace MyNamespace
{
}

/*
 * Section 6.10.1 continued...
 */
namespace MyNamespace
{
    namespace SubSpace
    {
        public class MyClass
        {
            public void MyFunction()
            {
                Debug.Log("MyClass says Hello from MyNamespace in SubSpace");
            }
        }
    }
    public class MyClass
    {
        public void MyFunction()
        {
            Debug.Log("MyClass says Hello from MyNamespace");
        }
    }
    /*
     * Section 6.10.2 Directives continued.
     */
    public class UniqueClass
    {
        public void MyFunction()
        {
            Debug.Log("UnitqueClass says hello from MyNamespace");
        }
    }
}

/*
 * Section 6.10.2
 */
public class NameSpaces : MonoBehaviour
{

}
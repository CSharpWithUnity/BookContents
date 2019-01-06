/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 6.10 Namespaces                                       *
 *                                                               *
 * Copyright © 2018 Alex Okita                                   *
 *                                                               *
 * This software may be modified and distributed under the terms *
 * of the MIT license. See the LICENSE file for details.         *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

/* Section namespaces protect the contents of this section       *
 * from interfering with the contents of another section         */
#region Chapter 6.10 Namespaces
#region Chapter 6.10.1 A Basic Example
namespace Chapter6_10_1
{
    /* * * * * * * * * * * * * * * * * * * * * * * *
     * Section 6.10.1 Namespaces: A Basic Example  *
     * * * * * * * * * * * * * * * * * * * * * * * */
    namespace MyNamespace
    {
    }

    /* Namespaces don't collide with one another        *
     * instead the second declaration below             *
     * extends the namespace and includes the contents  *
     * of both.                                         */

    namespace MyNamespace
    {
        public class SomeClass
        {
        }
    }

    /* public classes are available to objects         *
     * outside of the Namespace                        */

    namespace MyNamespace
    {
        /* Adds the UnityEngine library  *
         * to this scope of MyNamespace  */
        using UnityEngine;
        public class MyClass
        {
            public void MyFunction()
            {
                //Debug.Log() comes from UnityEngine
                Debug.Log("MyClass says Hello from MyNamespace");
            }
        }
    }

    /* global is a omnicient namespace that exists     *
     * everywhere.                                     */
    namespace MyNamespace
    {
        public class AnotherClass
        {
            void SomeFunction()
            {
                global::UnityEngine.Debug.Log("Using Global");
            }
        }
    }
}
#endregion
#region Chapter 6.10.2 Directives in Namespaces
namespace Chapter6_10_2
{
    /* * * * * * * * * * * * * * * * * * * * * * *
     * Section 6.10.2 Directives in Namespaces   * 
     * * * * * * * * * * * * * * * * * * * * * * */
    namespace SecondNamespace
    {
        using UnityEngine;
        using Chapter6_10_1.MyNamespace;
        public class UniqueClass
        {
            private Chapter6_10_1.MyNamespace.MyClass myClass;
            public void UseOtherNamespace()
            {
                myClass = new MyClass();
                myClass.MyFunction();
            }
        }
    }

    /* Wrapping the NameSpaces MonoBehaviour in the SecondNamespace       *
     * allows it to see the UniqueClass without a using SecondNamespace   *
     * directive                                                          */
    namespace SecondNamespace
    {
        using UnityEngine;
        /* Unity finds the only MonoBehaviour that matches the file name  *
         * and uses this as the component to attach to the gameObject     *
         * in the scene.                                                  */
        public class NameSpaces : MonoBehaviour
        {
            private void Start()
            {
                UniqueClass uniqueClass = new UniqueClass();
                uniqueClass.UseOtherNamespace();
            }
        }


    }
    #endregion


}
#endregion
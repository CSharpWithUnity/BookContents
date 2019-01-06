/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 6.10 Namespaces                                           *
 *                                                                   *
 * Copyright © 2018 Alex Okita                                       *
 *                                                                   *
 * This software may be modified and distributed under the terms     *
 * of the MIT license.  See the LICENSE file for details.            *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
#region Chapter 6.10.3 Ambiguous References
/* * * * * * * * * * * * * * * * * * * * * 
 * Section 6.10.3 Ambigusous References  *
 * * * * * * * * * * * * * * * * * * * * */
namespace Chapter6_10_3
{
    namespace AnotherNamespace
    {
        /* this is the samename as   *
         * seen in SecondNamespace   */
        public class UniqueClass
        {
        }
    }
    /* * * * * * * * * * * * * * * * * * 
     * Section 6.10.4 Alias Directives *
     * * * * * * * * * * * * * * * * * */
    namespace AnotherNamespace
    {
        /* a namespace in a namespace */
        namespace SubSpace
        {
            using UnityEngine;
            public class SubSpaceClass
            {
                public void UseSubSpaceFunction()
                {
                    Debug.Log("Hello from SubSpace Function");
                }
            }
        }
    }

    namespace AmbiguousNamespaces
    {
        using UnityEngine;
        using Chapter6_10_2.SecondNamespace; // has UniqueClass
        using AnotherNamespace;              // has UniqueClass

        public class AmbiguousReferences : MonoBehaviour
        {
            void Start()
            {
                /* which UniqueClass to use?        */

                //UniqueClass uniqueClass = new AnotherNamespace.UniqueClass();

                /* this is more specific */
                AnotherNamespace.UniqueClass uniqueClass = new AnotherNamespace.UniqueClass();
                Chapter6_10_2.SecondNamespace.UniqueClass secondUniqueClass = new Chapter6_10_2.SecondNamespace.UniqueClass();
            }
        }
    }

}
#endregion
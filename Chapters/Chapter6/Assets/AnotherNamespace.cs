/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 6.10.3 Ambiguous Namespaces                               *
 *                                                                   *
 * Copyright © 2018 Alex Okita                                       *
 *                                                                   *
 * This software may be modified and distributed under the terms     *
 * of the MIT license.  See the LICENSE file for details.            *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
namespace AnotherNamespace
{
    using UnityEngine;
    public class UniqueClass
    {
        public void MyFunction()
        {
            Debug.Log("Hello from MyClass in AnotherNamespace.");
        }
    }
}

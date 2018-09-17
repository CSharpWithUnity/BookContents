/*
 * Chapter 6.10.6 Extending Namespaces
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using UnityEngine;
namespace MyNamespace
{
    public class AnotherClassInMyNamespace
    {
        public void MyFunction()
        {
            Debug.Log("hello from MyNamespace");
        }
    }
}

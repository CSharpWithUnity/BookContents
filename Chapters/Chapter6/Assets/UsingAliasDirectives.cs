/*
 * Chapter 6.10.4 Alias Directives
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using UnityEngine;
/*
 * This allows you to shorten the name of a
 * namespace to something easier to use.
 */
using Sub = MyNamespace.SubSpace;

public class UsingAliasDirectives : MonoBehaviour
{
    void Start()
    {
        Sub.MyClass sClass = new Sub.MyClass();
        sClass.MyFunction();
    }
}

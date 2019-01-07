/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 6.10.4 Alias Directives                                 *
 *                                                                 *
 * Copyright © 2018 Alex Okita                                     *
 *                                                                 *
 * This software may be modified and distributed under the terms   *
 * of the MIT license.  See the LICENSE file for details.          *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

namespace Chapter6_10_4
{
    #region Chapter 6.10.4 Alias Directive
    /* * * * * * * * * * * * * * * * * * 
     * Section 6.10.4 Alias Directive  *
     * * * * * * * * * * * * * * * * * */
    using UnityEngine;
    /* This allows you to shorten the name of a     *
     * namespace to something easier to use.        */
    using Sub = Chapter6_10_3.AnotherNamespace.SubSpace;

    public class UsingAliasDirectives : MonoBehaviour
    {
        void Start()
        {
            /* uses Sub rather than                          *
             * Chapter6_10_3.AnotherNamespace.SubSpace       */
            Sub.SubSpaceClass subClass = new Sub.SubSpaceClass();
            subClass.UseSubSpaceFunction();
        }
    }
}
#endregion
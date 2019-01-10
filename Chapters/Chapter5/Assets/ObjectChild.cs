/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 5.3.3 Parent Child                                        *
 *                                                                   *
 * Copyright © 2018 Alex Okita                                       *
 *                                                                   *
 * This software may be modified and distributed under the terms     *
 * of the MIT license.  See the LICENSE file for details.            *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
namespace Chapter5_3_3
{
    using UnityEngine;

    public class ObjectChild : ObjectParent
    {
        private void Start()
        {
            ParentAbility();
        }

        public void ChildAbility()
        {
            Debug.Log("My parent doesn't get me.");
        }
    }
}

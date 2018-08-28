/*
 * Chapter 4.13 Scope Again
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

using UnityEngine;
public class OtherScope : MonoBehaviour
{
    /*
     * Section 4.13 Scope Again
     */
    public float Size;
    //Accessible to any other class

    Vector3 mScale;

    private void Update()
    {
        mScale = new Vector3(Size, Size, Size);
        transform.localScale = mScale;
    }
}
 
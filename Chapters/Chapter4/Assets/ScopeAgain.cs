/*
 * Chapter 4.13 Scope Again
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
 using UnityEngine;

public class ScopeAgain : MonoBehaviour
{
    /*
     * Section 4.13.1 Visibility or Accessibility
     * 
     * accessibility keywords:
     * private
     * public
     * protected
     * internal
     */
    public bool SomeBool;

    /*
     * Section 4.13.1.1 A Basic Example
     */
    OtherScope other;
    private void Start()
    {
        SomeBool = true;
        other = (OtherScope)GameObject.FindObjectOfType(typeof(OtherScope));
        Debug.Log(other.gameObject.name);
    }

    public float otherScale;
    private void Update()
    {
        other.Size = otherScale;
    }

    private bool hiddenBool;
    bool alsoHidden;

    private int privateInt;
    public int publicInt;
    protected int protectedInt;
    internal int internalInt;


}

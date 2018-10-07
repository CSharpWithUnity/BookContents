/*
 * Chapter 6.23 Controlling Inheritance
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using UnityEngine;

/*
 * Section 6.23.1.1 Sealed
 */
sealed class FinalizedObject
{
}

//class InheritFromSealed : FinalizedObject
//{
//}
/* cannot derive from sealed type 'ControllingInheritance.FinalizedObject' */

/*
 * Section 6.23.2 Extension Functions
 * 
 */
static class FinalizedObjectExtension
{
    public static void ExtensionFunction(this FinalizedObject finalObj)
    {
        Debug.Log("Extending the finalizedObject.");
    }

    public static void AnotherExtension(this FinalizedObject finalObj, int someArg)
    {
        Debug.Log("AnotherExtension: " + someArg);
    }

    public static void AnotherExtension(this AnotherSealedClass anotherClass, int anotherArg)
    {
        anotherClass.SealedFunction(anotherArg);
    }
}

sealed class AnotherSealedClass
{
    public void SealedFunction(int sealedArg)
    {
        Debug.Log("SealedFunctions's sealedArg:" + sealedArg);
    }
}

public class ControllingInheritance : MonoBehaviour
{
    void UsingControllingInheritance()
    {
        FinalizedObject finalizedObject = new FinalizedObject();
        /*                                              │                 */
        finalizedObject.ExtensionFunction();//←─────────┘
        /*                      ↑                                         */
        /*            ┌─────────┴──────────────────────┐                  */
        /*            │function not actually written in│                  */
        /*            │the FinalizedObject class.      │                  */
        /*            └────────────────────────────────┘                  */

        finalizedObject.AnotherExtension(7);
        // AnotherExtension: 7

        AnotherSealedClass another = new AnotherSealedClass();
        another.AnotherExtension(3);
        //SealedFunctions's sealedArg:3
    }

    void Start()
    {
        UsingControllingInheritance();
    }
}

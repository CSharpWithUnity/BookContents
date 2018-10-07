/*
 * Chapter 6.20 Type Casting Numbers
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

using UnityEngine;

public class TypeCastingNumbers : MonoBehaviour
{
    public int IntRotationY;
    public float FloatRotationY;
    public GameObject IntPointer;
    public GameObject FloatPointer;
    void Update()
    {
        /*
         * Section 6.20 Type Casting Numbers
         */
        FloatRotationY += Time.deltaTime;
        /*   ↑                  ↓ The amount of time that's passed between Updates */ 
        /*   └──────────────────┘ slowly increases FloatRotationY                  */ 
        /*          ┌───────────┐           */ 
        /*   ┌─────←┤cast to int├←──┐       */ 
        /*   │      └────┬──────┘   │       */ 
        /*  int          ↓        float     */ 
        IntRotationY = (int)FloatRotationY;
        /*   ↑                  ↓ only the whole digit of float gets carried through */ 
        /*   └─( X.000...000)───┘ the cast from float to int                         */ 
        /*        ↑                         */ 
        /*  only numbers past the decimal   */
        /*  are carried over                */
        
        float FloatFromInt = IntRotationY;
        /*        ↑             ↓ going from int to float doesn't require a cast */ 
        /*        └─( X.??? )───┘ since we don't lose any values in the cast     */ 
        /*             ↑ nothing past here...                                       */
        
        IntPointer.transform.localEulerAngles = new Vector3(0, IntRotationY, 0);
        FloatPointer.transform.localEulerAngles = new Vector3(0, FloatRotationY, 0);
    }
}

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 6.20 Type Casting Numbers                                 *
 *                                                                   *
 * Copyright © 2018 Alex Okita                                       *
 *                                                                   *
 * This software may be modified and distributed under the terms     *
 * of the MIT license.  See the LICENSE file for details.            *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
namespace Chapter6_20
{
    using UnityEngine;
    public class TypeCastingNumbers : MonoBehaviour
    {
        /* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
         * ╔═══════════════╤═══════╤════════════════════════════════════════════════════════╗ *
         * ║ sbyte	       │8  bits│                      –128 ↔ 127                        ║ *
         * ╟───────────────┼───────┼────────────────────────────────────────────────────────╢ *
         * ║ Byte	       │8  bits│                         0 ↔ 255                        ║ *
         * ╟───────────────┼───────┼────────────────────────────────────────────────────────╢ *
         * ║ Short	       │16 bits│                   –32,768 ↔ 32,767                     ║ *
         * ╟───────────────┼───────┼────────────────────────────────────────────────────────╢ *
         * ║ Unsigned short│16 bits│                         0 ↔ 65,535                     ║ *
         * ╟───────────────┼───────┼────────────────────────────────────────────────────────╢ *
         * ║ Int	       │32 bits│            –2,147,483,648 ↔ 2,147,483,647              ║ *
         * ╟───────────────┼───────┼────────────────────────────────────────────────────────╢ *
         * ║ Unsigned int  │32 bits│                         0 ↔ 4,294,967,295              ║ *
         * ╟───────────────┼───────┼────────────────────────────────────────────────────────╢ *
         * ║ Long	       │64 bits│–9,223,372,036,854,775,808 ↔ 9,223,372,036,854,775,807  ║ *
         * ╟───────────────┼───────┼────────────────────────────────────────────────────────╢ *
         * ║ Unsigned long │64 bits│                         0 ↔ 18,446,744,073,709,551,615 ║ *
         * ╚═══════════════╧═══════╧════════════════════════════════════════════════════════╝ *
         *                                                                                    *
         * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

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
}
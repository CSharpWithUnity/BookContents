/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 8.10 Bitwise Operators                                        *
 *                                                                       *
 * Copyright © 2018 Alex Okita                                           *
 *                                                                       *
 * This software may be modified and distributed under the terms         *
 * of the MIT license.  See the LICENSE file for details.                *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
namespace Chapter8_10
{
    using System;
    using System.Collections;
    using UnityEngine;

    public class BitwiseMath : MonoBehaviour
    {

        /* * * * * * * * * * * * * * *
         * Section 8.10 Bitwise Math *
         * * * * * * * * * * * * * * */

        /* A byte is an array of bits 1 or 0     *
         * or true/false.                        *
         * A byte is 8 bits long.                *
         * A byte[] is an array of bits arranged *
         * into groups of 8 for each byte.       */
        void ShowBits(byte B)
        {
            /* BitArray only converts from       *
             * an array of byte, not a single    *
             * byte ¯\_(ツ)_/¯                   */

            byte[] array = new byte[] { B };
            BitArray bits = new BitArray(array);
            string log = "bits in " + B + ":\n";
            foreach (bool b in bits)
            {
                log += b ? "1" : "0";
            }
            Debug.Log(log);
        }


        void ShowBits(int number)
        {
            int bitLen = 32;
            string log = "bits in int:" + number + "\n";
            for (int i = 0; i < bitLen; i++)
            {
                int mask = 1 << i;
                if ((number & mask) == mask)
                {
                    log += "1";
                }
                else
                {
                    log += "0";
                }
            }
            Debug.Log(log);
        }

        /* * * * * * * * * * * * * * *
         * Section 8.10 Bitwise Math *
         * * * * * * * * * * * * * * */
        void UseHex()
        {
            byte ff = 0xff;
            Debug.Log("ff: " + ff);
            // ff: 255

            sbyte sff = -0x80;
            Debug.Log("sff: " + sff);
            // sff: -128

            sff--;
            Debug.Log("sff--: " + sff);
            // sff--: 127

        }

        /* * * * * * * * * * * * * * * * * *
         * Section 8.10.2 Twos Complement  *
         * * * * * * * * * * * * * * * * * */
        void UseTwosComplement()
        {

            int hexMax = 0x7fffffff;
            Debug.Log("max in hex:" + hexMax);
            // max in hex:2147483647

            int intMax = int.MaxValue;
            Debug.Log("max from int:" + intMax);
            // max from int:2147483647

            int negOne = -1;
            ShowBits(negOne);
            // bits in int:-1
            // 11111111111111111111111111111111

            int ten = 0x0a;
            ShowBits(ten);
            // bits in int:10
            // 01010000000000000000000000000000

            int nTen = ~ten;
            ShowBits(nTen);
            // bits in int:-11
            // 10101111111111111111111111111111

            int nTenOne = ~ten + 1;
            ShowBits(nTenOne);
            // bits in int:-10
            // 01101111111111111111111111111111

            int complement = 100;
            complement = ~complement + 1;
            ShowBits(complement);
            // bits in int:-100
            // 00111001111111111111111111111111
        }

        /* * * * * * * * * * * * * * * * * * * * * * * * * *
         * Section 8.10.3 Bitwise Addition and Subtraction *
         * * * * * * * * * * * * * * * * * * * * * * * * * */
        void UseBitwiseAdditionAndSubtraction()
        {
            {
                int a = 7;
                int b = 3;
                int c = a & b;
                int r = a ^ b;
                while (c != 0)
                {
                    int s = c << 1;
                    c = r & s;
                    r = r ^ s;
                }
                Debug.Log(r);
            }

            {
                int a = 7;
                // 1110 0000

                int b = 3;
                // 1100 0000

                int c = a & b;
                //a  1110 0000
                //b &1100 0000
                //  =1100 0000

                int r = a ^ b;
                //a  1110 0000
                //b ^1100 0000
                //  =0010 0000

                while (c != 0)
                {   //[   first iteration ][ second iteration  ]
                    //[ c   1100 0000     ][ c   0010 0000     ]
                    int s = c << 1;
                    //[ s = 0110 0000 << 1][ s = 0001 0000 << 1] → actual direction
                    c = r & s;
                    //[ r   0010 0000     ][ r   0100 0000     ]
                    //[ s & 0110 0000     ][ s & 0001 0000     ]
                    //[ c = 0010 0000     ][ c = 0000 0000     ](c == 0)
                    r = r ^ s;
                    //[ r   0010 0000     ][ r   0100 0000     ]
                    //[ s ^ 0110 0000     ][ s ^ 0001 0000     ] 
                    //[ r = 0100 0000     ][ r = 0101 0000     ](final result)
                }
                ShowBits(r);
                //bits in int:10
                //01010000000000000000000000000000
            }
        }

        int BitwiseAdd(int a, int b)
        {
            int c = a & b;
            int r = a ^ b;
            while (c != 0)
            {
                int s = c << 1; //shift digits to add
                c = r & s;      //find overlapping digits
                r = r ^ s;      //merge digits that don't overlap
            }
            return r;
        }

        void UseBitwiseSub()
        {
            int a = 7;
            int b = 3;
            int c = BitwiseSub(a, b);
        }


        int BitwiseSub(int a, int b)
        {
            b = BitwiseAdd(~b, 1);
            return BitwiseAdd(a, b);
        }

        int BitwiseMultiplication(int a, int b)
        {
            int r = 0;
            while (b != 0)
            {
                if ((b & 1) != 0)
                {
                    r = BitwiseAdd(r, a);
                }
                a = a << 1;
                if (b == 0)
                {
                    r = a;
                    break;
                }
                b = b >> 1;
            }
            return r;
        }

        int BitwiseDiv(int a, int b)
        {
            int divideStart = a;
            int timesDivided = 1;
            while (true)
            {
                divideStart = BitwiseSub(divideStart, b);
                if (divideStart <= 0)
                    break;
                timesDivided = BitwiseAdd(timesDivided, 1);
            }
            return timesDivided;
        }

        /* * * * * * * * * * * * * * * * *
         * Section 8.10.4 Bitwise Tricks *
         * * * * * * * * * * * * * * * * */
        void UseBitwiseTricks()
        {
            // checks if both are positive
            // or both are negative.
            int a = 20;
            int b = 1;
            bool same = ((a ^ b) > 0);
            Debug.Log(same);


            string BitsToString(int number, int digits)
            {
                char[] binary = new char[digits];
                int digit = digits - 1;
                int place = 0;
                while (place < digits)
                {
                    int d = number & (1 << place);
                    if (d != 0)
                    {
                        binary[digit] = '1';
                    }
                    else
                    {
                        binary[digit] = '0';
                    }
                    digit--;
                    place++;
                }
                return new string(binary);
            }

            Debug.Log(BitsToString(42, 8));
            // 00101010
        }



        void Start()
        {
            /* * * * * * * * * * * * * * * *
             * Section 8.10 Bitwise Math   *
             * * * * * * * * * * * * * * * */
            //UseHex();

            /* * * * * * * * * * * * * * * * * *
             * Section 8.10.2 Twos Complement  *
             * * * * * * * * * * * * * * * * * */
            //UseTwosComplement();

            /* * * * * * * * * * * * * * * * * * * * * * * * * *
             * Section 8.10.3 Bitwise Addition and Subtraction *
             * * * * * * * * * * * * * * * * * * * * * * * * * */
            UseBitwiseAdditionAndSubtraction();

            /* * * * * * * * * * * * * * * * *
             * Section 8.10.4 Bitwise Tricks *
             * * * * * * * * * * * * * * * * */
            UseBitwiseTricks();

        }
    }
}
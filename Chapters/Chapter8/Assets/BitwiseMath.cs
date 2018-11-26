/*
 * Chapter 8.9 Bitwise Operators
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using System;
using System.Collections;
using UnityEngine;
public class BitwiseMath : MonoBehaviour
{
    /*
     * Section 8.11 Bitwise Math
     * 
     * A byte is an array of bits 1 or 0
     * or true/false.
     * A byte is 8 bits long.
     * A byte[] is an array of bits arranged
     * into groups of 8 for each byte.
     */
    void ShowBits(byte B)
    {
        /* BitArray only converts from
         * an array of byte, not a single
         * byte ¯\_(ツ)_/¯
         */
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

    /*
     * Section 8.10 Bitwise Math
     */
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

    /*
     * Section 8.10.2 Twos Complement
     */
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

        int nTenOne = ~ten+1;
        ShowBits(nTenOne);
        // bits in int:-10
        // 01101111111111111111111111111111

        int complement = 100;
        complement = ~complement + 1;
        ShowBits(complement);
        // bits in int:-100
        // 00111001111111111111111111111111
    }

    /*
     * Section 8.10.3 Bitwise Addition and Subtraction
     */
    void UseBitwiseAdditionAndSubtraction()
    {
        int a = 21;
        ShowBits((byte)a);

        int b = 17;
        ShowBits((byte)b);
        
        int c = a & b;
        ShowBits((byte)c);

        int r = a ^ b;
        ShowBits((byte)r);

        while (c != 0)
        {
            int s = c << 1;
            ShowBits((byte)s);
            c = r & s;
            ShowBits((byte)c);
            r = r ^ s;
            ShowBits((byte)r);
        }

    }

    void Start()
    {
        /*
         * Section 8.10 Bitwise Math
         */
        //UseHex();

        /*
         * Section 8.10.2 Twos Complement
         */
        //UseTwosComplement();

        /*
         * Section 8.10.3 Bitwise Addition and Subtraction
         */
        UseBitwiseAdditionAndSubtraction();
    }
}
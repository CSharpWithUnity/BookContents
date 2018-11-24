/*
 * Chapter 8.9 Bitwise Operators
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using System.Collections;
using UnityEngine;

public class BitwiseOperators : MonoBehaviour
{
    /*
     * Section 8.9 Bitwise Operators
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

    void ShowBits(sbyte B)
    {
        /* BitArray only converts from
         * an array of byte, not a single
         * byte ¯\_(ツ)_/¯
         */
        byte[] array = new byte[] { (byte)B };

        BitArray bits = new BitArray(array);
        string log = "bits in " + B + ":\n";
        foreach (bool b in bits)
        {
            log += b ? "1" : "0";
        }
        Debug.Log(log);
    }

    void ReadBits()
    {
        ShowBits(1);
        // bits in 1:
        // 10000000

        ShowBits(128);
        // bits in 128:
        // 00000001
        
        ShowBits(255);
        // bits in 255:
        // 11111111

        ShowBits((sbyte)-1);
        // bits in -1:
        // 11111111

        ShowBits((sbyte)-2);
        // bits in -1:
        // 01111111

        ShowBits((sbyte)1);
        // bits in 1:
        // 10000000

        ShowBits((sbyte) 0);
        // bits in 0:
        // 00000000

        ShowBits((sbyte)127);
        // bits in -127:
        // 10000000

        ShowBits((sbyte)-127);
        // bits in -127:
        // 10000001

        int max = 2147483647;
        Debug.Log(max);
        // 2147483647
        
        max += 1;
        Debug.Log(max);
        // -2147483648

        uint umax = 4294967295;
        Debug.Log(umax);
        // 4294967295

        umax += 1;
        Debug.Log(umax);
        // 0
    }

    /*
     * Section 8.9.3 Bitwise Or |
     * 
     *    1248
     *    1001 =  9
     *    1010 =  5
     *  | _________
     *    1011 = 13
     */
    void UseBitwiseOr()
    {
        {
            // | "Or" also known as Bar
            uint a = 5;     // 1 + 0 + 4 = 5
            uint b = 6;     // 0 + 2 + 4 = 6
            uint c = a | b; // 1 + 2 + 4 = 7
            Debug.Log(c);
            // 7
        }
    }

    /*
     * Section 8.9.4 Enums and Numbers
     *
     * multi class characters
     */

    enum CharacterClasses
    {
        Farmer  = 0x00,
        Fighter = 0x01,
        Thief   = 0x02,
        Wizard  = 0x04,
        Archer  = 0x08
    }

    void UseOrCharacterClasses()
    {
        CharacterClasses fighter = CharacterClasses.Fighter;
        ShowBits((byte)fighter);
        // bits in 1:
        // 10000000
        
        CharacterClasses wizard = CharacterClasses.Wizard;
        ShowBits((byte)wizard);
        // bits in 4:
        // 00100000

        CharacterClasses multiClass = fighter | wizard;
        ShowBits((byte)multiClass);
        // bits in 5:
        // 10100000
    }

    /*
     * Section 8.9.5 Bitwise And &
     * 
     *    1248
     *    1001 =  9
     *    1010 =  5
     *  & _________
     *    1000 =  1
     */
    void UseAndCharacterClasses()
    {
        /* & "And" also known as Ampersand
         * the & operator shows us what matches
         */
        uint a = 5;     // 1 + 0 + 4 = 5
        uint b = 6;     // 0 + 2 + 4 = 6
        uint c = a & b; // 0 + 0 + 4 = 7
        Debug.Log(c);
        // 4

        CharacterClasses fighter = CharacterClasses.Fighter;
        ShowBits((byte)fighter);
        // bits in 1:
        // 10000000

        CharacterClasses wizard = CharacterClasses.Wizard;
        ShowBits((byte)wizard);
        // bits in 4:
        // 00100000

        CharacterClasses fighterAndWizard = fighter & wizard;
        ShowBits((byte)fighterAndWizard);
        // bits in 0:
        // 00000000

        CharacterClasses multiClass = fighter | wizard;
        ShowBits((byte)multiClass);
        // bits in 5:
        // 10100000

        byte andFighter = (byte)(multiClass & CharacterClasses.Fighter);
        ShowBits(andFighter);
        // bits in 1:
        // 10000000

        byte andWizard = (byte)(multiClass & CharacterClasses.Wizard);
        ShowBits(andWizard);
        // bits in 4:
        // 00100000

        byte andArcher = (byte)(multiClass & CharacterClasses.Archer);
        ShowBits(andArcher);
        // bits in 0:
        // 00000000
    }

    /*
     * Section 8.9.5 Bitwise Xor ^
     *    1248
     *    1001 =  9
     *    1010 =  5
     *  ^ _________
     *    0011 = 12
     */
    void UseXorCharacterClasses()
    {
        /* ^ "Xor" also known as caret
         * Xor shows what's different about the two
         * different bytes.
         */
        uint a = 5;     // 1 + 0 + 4 = 5
        uint b = 6;     // 0 + 2 + 4 = 6
        uint c = a ^ b; // 1 + 2 + 0 = 3
        Debug.Log(c);
        // 3

        /* using | we add in a wizard to the fighter
         * to take the wizard flag back out use ^
         */
        CharacterClasses wizard = CharacterClasses.Wizard;
        CharacterClasses fighter = CharacterClasses.Fighter;
        CharacterClasses multiClass = wizard | fighter;
        ShowBits((byte)multiClass);
        // bits in 5:
        // 10100000
        Debug.Log(multiClass);

        CharacterClasses result = multiClass ^ CharacterClasses.Fighter;
        ShowBits((byte)result);
        // bits in 4:
        // 00100000
        Debug.Log(result);

        multiClass = CharacterClasses.Fighter | CharacterClasses.Thief | CharacterClasses.Wizard;
        ShowBits((byte)multiClass);
        // bits in 7:
        // 11100000

        bool isThief = (multiClass & CharacterClasses.Thief) == CharacterClasses.Thief;
        Debug.Log("multiClass is Thief:" + isThief);
        // multiClass is Thief:True
    }

    /*
     * Section 8.9.7 Setting Bitwise Flags
     */
    void UseSettingBitwiseFlags()
    {
        CharacterClasses addClass(CharacterClasses a, CharacterClasses b)
        {
            return a | b;
        }
        CharacterClasses newbie = CharacterClasses.Farmer;
        newbie = addClass(newbie, CharacterClasses.Wizard);

        newbie = addClass(newbie, CharacterClasses.Archer);

        CharacterClasses removeClass(CharacterClasses a, CharacterClasses b)
        {
            return a ^ b;
        }
        newbie = removeClass(newbie, CharacterClasses.Wizard);

        bool hasClass(CharacterClasses a, CharacterClasses b)
        {
            return (a & b) == b;
        }
        bool isFarmer = hasClass(newbie, CharacterClasses.Farmer);
        Debug.Log("newbie is a farmer:" + isFarmer);
        // newbie is a farmer:True
    }

    /*
     * Section 8.9.8 Bitwise Shortcuts
     */
    void UseBitwiseShortcuts()
    {
        CharacterClasses character = CharacterClasses.Farmer;
        character |= CharacterClasses.Fighter;
        character |= CharacterClasses.Wizard;
        character |= CharacterClasses.Archer;
        character |= CharacterClasses.Thief;
        ShowBits((byte)character);
        // bits in 15:
        // 11110000

        character ^= CharacterClasses.Fighter;
        ShowBits((byte)character);
        // bits in 14:
        // 01110000

    }

    /*
     * Section 8.9.9 Bits in Numbers
     */
    void UseBitsInNumbers()
    {
        int number = 758;
        bool even = (number & 1) == 0;
        Debug.Log("number:" + number + " is even:" + even);

        bool evenMod = number % 2 == 0;
        Debug.Log("number:" + number + " is even:" + evenMod);
    }

    /*
     * Section 8.9.10 Bit Shifting
     * Observing how << and >> work
     */
    enum Alignments
    {
        TrueNeutral     = 0,
        ChaoticNeutral  = 1 << 1,
        LawfulNeutral   = 1 << 2,
        ChaoticGood     = 1 << 3,
        NeutralGood     = 1 << 4,
        LawfulGood      = 1 << 5,
        ChaoticEvil     = 1 << 6,
        NeutralEvil     = 1 << 7,
        LawfulEvil      = 1 << 8, //is this going to work?
    }

    void UseBitShifting()
    {
        Alignments trueNeutral = Alignments.TrueNeutral;
        ShowBits((byte)trueNeutral);

        Alignments chaoticNeutral = Alignments.ChaoticNeutral;
        ShowBits((byte)chaoticNeutral);

        Alignments lawfulGood = Alignments.LawfulGood;
        ShowBits((byte)lawfulGood);

        Alignments lawfulEvil = Alignments.LawfulEvil;
        ShowBits((byte)lawfulEvil);
        // zero!

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

        ShowBits((int)1);
    }

    void Start()
    {
        /*
         * Section 8.9 Bitwise Operators
         */
        //ReadBits();

        /*
         * Section 8.9.3 Bitwise Or |
         */
        //UseBitwiseOr();

        /*
         * Section 8.9.4 Enums and Numbers
         */
        //UseOrCharacterClasses();

        /*
         * Section 8.9.5 Bitwise And &
         */
        //UseAndCharacterClasses();

        /*
         * Section 8.9.6 Bitwise Xor ^
         */
        //UseXorCharacterClasses();

        /*
         * Section 8.9.7 Setting Bitwise Flags
         */
        //UseSettingBitwiseFlags();

        /*
         * Section 8.9.8 Bitwise Shortcuts
         */
        //UseBitwiseShortcuts();

        /*
         * Section 8.9.9 Bits in Numbers
         */
        //UseBitsInNumbers();

        /*
         * Section 8.9.10 Bit Shifting
         */
        UseBitShifting();
    }
}

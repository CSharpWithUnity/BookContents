/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 6.9 Class Data                                            *
 *                                                                   *
 * Copyright © 2018 Alex Okita                                       *
 *                                                                   *
 * This software may be modified and distributed under the terms     *
 * of the MIT license.  See the LICENSE file for details.            *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
namespace Chapter6_9
{
    using UnityEngine;
    public class ClassData : MonoBehaviour
    {
        #region Chapter 6.9 Class Data
        /* * * * * * * * * * * * * *
         * Section 6.9 Class Data  *
         * * * * * * * * * * * * * */
        void DoThings()
        {
            int[] arrayOfInts = new int[100];
            for (int i = 0; i < 100; i++)
            {
                arrayOfInts[i] = i;
            }
        }
        #endregion
    }
    #region Chapter 6.9.1 Class Data continued...
    /* * * * * * * * * * * * * * * * * * * * *
     * Section 6.9.1 Class Data continued... *
     * * * * * * * * * * * * * * * * * * * * */

    /* things you can't do with structs. */

    struct MyStruct
    {
        //public int a = 0;

        /*
         * uncomment the declaration
         * above to see the error
         */

        //public MyStruct()
        //{
        //}

        /*
         * Uncomment the constructor
         * to see thee error.
         */
    }

    //struct AddingToMyStruct : MyStruct
    //{
    //}

    /*
     * struct childStruct : parentStruct
     * {
     * }
     * the above isn't allowed so structs
     * must stand on their own
     */

    class MyClass
    {
        public int a = 0;
        public MyClass()
        {
        }
    }

    class PlayerData
    {
        public Vector3 Position;
        public int HitPoints;
        public int Ammo;
        public float RunSpeed;
        public float WalkSpeed;
    }
    #endregion

    #region Chapter 6.9.1 Character Base Class
    /* * * * * * * * * * * * * * * * * * * *
     * Section 6.9.1 Character Base Class  *
     * * * * * * * * * * * * * * * * * * * */
    public class BaseMonster
    {
        /* * * * * * * * * * * * *
         * Section 6.9.2 const   *
         * * * * * * * * * * * * */
        //const int MaxHitPoints = 10;
        public const int MaxHitPoints = 10;

        /* * * * * * * * * * * * * *
         * Section 6.9.3 Readonly  *
         * * * * * * * * * * * * * */
        public readonly int MaxMagicPoints = 10;
        public void SetMaxMagicPoints(int mp)
        {
            //MaxMagicPoints = mp;
            // the above is not allowed.
        }

        /* however, you can modify it in the constructor */
        public BaseMonster(int maxMP)
        {
            MaxMagicPoints = maxMP;
            // this is valid
        }
    }

    public class Zombie : BaseMonster
    {
        public Zombie(int maxMP) : base(maxMP)
        {
        }
    }
}
#endregion

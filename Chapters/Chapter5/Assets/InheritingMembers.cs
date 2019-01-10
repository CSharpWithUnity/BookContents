/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 5.3.1.1 Inheriting Members                                *
 *                                                                   *
 * Copyright © 2018 Alex Okita                                       *
 *                                                                   *
 * This software may be modified and distributed under the terms     *
 * of the MIT license.  See the LICENSE file for details.            *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
namespace Chapter5_3_1_1
{
    using UnityEngine;

    public class InheritingMembers : MonoBehaviour
    {
        #region Chapter 5.3.1 Class Members
        /* * * * * * * * * * * * * * * * * * * *
         * Section 5.3.1.1 Inheriting Members  *
         * * * * * * * * * * * * * * * * * * * */

        public class Cat
        {
            public int paws = 4;
            public void Meow()
            {
                Debug.Log("Meow");
            }
        }

        public class PianoCat : Cat
        {
            public void PlayPiano()
            {
                Meow(); // inherited from Cat
            }
        }

        #endregion

        #region Chapter 5.3.1.2 Is-A and Has-A
        /* * * * * * * * * * * * * * * * * *
         * Section 5.3.1.2 Is-A and Has-A  *
         * * * * * * * * * * * * * * * * * */

        public class LaptopComponent : Component
        {
        }

        /* ComputerCat Is-A Cat     */
        public class ComputerCat : Cat
        {
            /* ComputerCat Has-A LaptopComponent */
            LaptopComponent Laptop;
        }

        void UseIs()
        {
            Cat cat = new Cat();
            PianoCat pianoCat = new PianoCat();
            ComputerCat computerCat = new ComputerCat();

            bool pianoCatIsCat = pianoCat is Cat;
            Debug.Log("PianoCat is a Cat?" + (pianoCatIsCat ? "True" : "False"));
            // PianoCat is a Cat? True

            bool pianoCatIsComputerCat = pianoCat is ComputerCat;
            Debug.Log("PianoCat is a ComputerCat?" + (pianoCatIsComputerCat ? "True" : "False"));
            // PianoCat is a ComputerCat False
        }
        #endregion

        #region Chapter 5.3.2 Instancing
        /* * * * * * * * * * * * * * *
         * Section 5.3.2 Instancing  *
         * * * * * * * * * * * * * * */
        void UseInstancing()
        {
            PianoCat famousCat = new PianoCat();
            /*
             * famousCat is now an instance of a PianoCat
             */
            famousCat.PlayPiano();     // Meow from PianoCat
            famousCat.Meow();          // Meow from Cat
            Debug.Log(famousCat.paws); //paws from Cat
        }
        #endregion

        private void Start()
        {
            /* * * * * * * * * * * * * *
             * Section 5.3.1.2 UseIs   *
             * * * * * * * * * * * * * */
            UseIs();

            /* * * * * * * * * * * * * * *
             * Section 5.3.2 Instancing  *
             * * * * * * * * * * * * * * */
            UseInstancing();
        }
    }
}

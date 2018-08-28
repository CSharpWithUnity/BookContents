/*
 * Chapter 5.3.1.1 Inheriting Members
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using UnityEngine;

public class InheritingMembers : MonoBehaviour
{
    /*
     * Section 5.3.1.1 Inheriting Members
     */

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

    /*
     * Section 5.3.2 Instancing
     */
    private void Start()
    {
        PianoCat famousCat = new PianoCat();
        /*
         * famousCat is now an instance of a PianoCat
         */
        famousCat.PlayPiano();     // Meow from PianoCat
        famousCat.Meow();          // Meow from Cat
        Debug.Log(famousCat.paws); //paws from Cat
    }
}

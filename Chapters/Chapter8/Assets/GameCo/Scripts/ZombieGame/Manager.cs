/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 8.11 Design Patterns                                          *
 *                                                                       *
 * Copyright © 2018 Alex Okita                                           *
 *                                                                       *
 * This software may be modified and distributed under the terms         *
 * of the MIT license.  See the LICENSE file for details.                *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
namespace GameCo.ZombieGame
{
    using UnityEngine;

    public class Manager : MonoBehaviour
    {
        /*
         * Singleton Pattern
         */
        public static Manager ZombieManager;
        void Awake()
        {
            if(ZombieManager == null)
            {
                ZombieManager = this;
            }
        }
    }
}
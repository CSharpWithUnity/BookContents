/*
 * Chapter 8.10 Architecture and Organization
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

using System.Collections;
using System.Collections.Generic;

namespace GameCo.ZombieGame
{
    public partial class BaseItemInfo
    {
        public static int TotalItems;
        public string Name;
        public int Cost;

        public BaseItemInfo()
        {
            TotalItems++;
        }
    }
}

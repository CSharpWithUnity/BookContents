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
using UnityEngine;

namespace GameCo.ZombieGame
{
    public class BaseItem : Behavior
    {
        public BaseItemInfo ZombieItemInfo;

        public virtual void Start()
        {
            ZombieItemInfo = new BaseItemInfo();
        }
    }
}

/*
 * Chapter 6.10.5 Putting Namespaces to Work
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

namespace ZombieGame
{
    public class ZombieMonster
    {
        public MonsterInfo zombieInfo;
        public ZombieMonster()
        {
            zombieInfo = new MonsterInfo()
            {
                Health = 10,
                Armor = 10,
                AttackPower = 1
            };
        }
    }
}

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
    public struct MonsterInfo
    {
        public int Health;
        public int Armor;
        public int AttackPower;
        public void TakeDamage(int damage)
        {
            int damageToZombie = (damage - Armor);
            // reduce damage by armor
            if (damageToZombie < 1)
            {
                damageToZombie = 1;
                // don't let damage fall
                // below 1 or we might get
                // negative values.
            }
            Health -= damageToZombie;
        }
    }
}

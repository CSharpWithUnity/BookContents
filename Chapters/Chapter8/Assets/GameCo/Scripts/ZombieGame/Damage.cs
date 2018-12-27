/*
 * Chapter 8.10 Architecture and Organization
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

namespace GameCo.ZombieGame
{
    public class Damage
    {
        public DamageData Info;
    }

    public class DamageData
    {
        public DamageTypes DamageType;
        public int DamageAmount;
    }

    public enum DamageTypes
    {
        Projectile  = 0,
        Poison      = 1,
        Fire        = 2,
        Explisove   = 4,
        Cutting     = 8,
        Dimensional = 16,
        Freezing    = 32,
        Crushing    = 64,
        Falling     = 128
    }
}

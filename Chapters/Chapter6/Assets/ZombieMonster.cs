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

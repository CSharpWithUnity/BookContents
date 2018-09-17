/*
 * Chapter 6.10 Namespaces
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

/*
 * Section 6.10.2 Directives in Namespaces
 */
using UnityEngine;
using MyNamespace; // added a directive to add our namespace
using AnotherNamespace; // added for section 6.10.3 ambiguous namespaces
using ZombieGame; // added for section 6.10.5 Putting Namespaces to Work
public class UsingNameSpaces : MonoBehaviour
{
    void Start()
    {
        {
            MyClass myClass = new MyClass();
            //myClass.MyFunction();
            
            /*
             * This version of MyClass comes from ClassData.cs
             */

            MyNamespace.MyClass nsClass = new MyNamespace.MyClass();
            nsClass.MyFunction();

            //UniqueClass uClass = new UniqueClass();
            //uClass.MyFunction();

            /*
             * Uncomment the above to see the error caused by including
             * the using AnotherNamespace; directive.
             * alternatively, comment out the using AnotherNamespace;
             * directive to see that the UniqueClass is referencing
             * the MyNamespace version of the class identifier.
             */

            AnotherNamespace.UniqueClass anClass = new AnotherNamespace.UniqueClass();
            anClass.MyFunction();

            MyNamespace.SubSpace.MyClass subClass = new MyNamespace.SubSpace.MyClass();
        }
        {
            /*
             * Section 6.10.5 Putting Namespaces to Work
             */
            zombieMonster = new ZombieMonster();
            AttackMonster();
        }
    }
    /*
    * Section 6.10.5 Putting Namespaces to Work
    */
    public ZombieMonster zombieMonster;
    public int attackPower;
    void AttackMonster()
    {
        MonsterInfo mi = zombieMonster.zombieInfo;
        attackPower = 12;
        if (attackPower > mi.Armor && mi.Health > 0)
        {
            zombieMonster.zombieInfo.TakeDamage(attackPower);
        }
    }
}

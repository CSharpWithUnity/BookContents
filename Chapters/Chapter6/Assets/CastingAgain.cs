/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 6.14 Type Casting Again                                   *
 *                                                                   *
 * Copyright © 2018 Alex Okita                                       *
 *                                                                   *
 * This software may be modified and distributed under the terms     *
 * of the MIT license.  See the LICENSE file for details.            *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
namespace Chapter6_14
{
    using UnityEngine;
    public class CastingAgain : MonoBehaviour
    {
        /*
         * Section 6.14 Type Casting Again
         */
        enum SimpleEnums
        {
            FirstValue,
            SecondValue,
            ThirdValue
        }

        void Start()
        {
            {
                /*
                 * Section 6.14 Casting Again
                 */

                SimpleEnums simpleEnum = SimpleEnums.SecondValue;
                //int convertedEnum = simpleEnum as int;
                /* Uncomment the line above ↑ to see the error
                 */
                int convertedEnum = (int)simpleEnum;
                /* this type conversion does work!
                 * Explicit casts (as explained in 3.13)
                 * have functions that define how to
                 * convert to the destination type indicated
                 * by the (dataType) in the explicit type
                 * cast operator.
                 */
                Debug.Log("convertedEnum: " + convertedEnum);
                // convertedEnum: 1
            }

            {
                /*
                 * Section 6.14.1 (<type>) versys "as"
                 */
                CastingHumanoids();
                CastingCastableHumanoids();
            }
        }

        /*
         * Section 6.14.1 (<type>) versys "as"
         */
        class Humanoid
        {
        }

        class Zombie : Humanoid
        {
        }

        class Person : Humanoid
        {
        }

        void CastingHumanoids()
        {
            Humanoid h = new Humanoid();
            Zombie z = h as Zombie;
            Debug.Log(z);
            //"Null"

            //Zombie x = (Zombie)h;
            //Debug.Log(x);
            /* uncomment the line above to see the following error:
             * "InvalidCastException: Cannot cast from source type to destination type."
             */

            Person p = new Person();
            //Zombie zombieFromPerson = p as Zombie;
            /* uncomment the line above to see the following error:
             * "InvalidCastException: Cannot cast from source type to destination type."
             */
        }

        /*
         * Section 6.14.2 User-Defined Type Conversion
         */

        class CastableHumanoid
        {
            public int HitPoints;
        }

        class CastablePerson : CastableHumanoid
        {
            static public implicit operator CastableZombie(CastablePerson person)
            {
                CastableZombie castable = new CastableZombie();
                castable.HitPoints = person.HitPoints * -1;
                return castable;
            }
        }

        class CastableZombie : CastableHumanoid
        {
            public bool isZombie;
            static public implicit operator CastablePerson(CastableZombie zombie)
            {
                CastablePerson castable = new CastablePerson();
                castable.HitPoints = 1;
                // imply you've revived someone
                // and they're barely alive.
                return castable;
            }
        }

        void CastingCastableHumanoids()
        {
            {
                CastablePerson p = new CastablePerson();
                p.HitPoints = 10;
                CastableZombie z = p as CastablePerson;
                Debug.Log("Cast Zombie: " + z.HitPoints);
                //"Cast Zombie: -10"

                CastableZombie personZombie = new CastablePerson();
                Debug.Log(personZombie);
            }
            {
                CastablePerson p = new CastablePerson();
                p.HitPoints = 10;
                CastableZombie z = (CastableZombie)p;
                Debug.Log(z + " " + z.HitPoints);
                // CastableAgain+CastableZombie -10
            }
            {
                /*
                 * Section 6.14.3 Implicit versus Explicit Type Conversion
                 */
                CastableHumanoid[] humanoids = new CastableHumanoid[]
                {
                new CastableZombie(),
                new CastablePerson(),
                new CastableHumanoid(),
                new CastableZombie(),
                new CastablePerson()
                };

                foreach (CastableHumanoid humanoid in humanoids)
                {
                    Debug.Log(humanoid + " is a humanoid");
                    Debug.Log("humanoid has: " + humanoid.HitPoints + "HP");

                    //if (humanoid.isZombie)//variable could not be found!
                    //{
                    //    Debug.Log("humanoid is a zombie?");
                    //}

                    /* Uncomment the block of code above to see
                     * the error.
                     */
                }
            }
        }

        struct A
        {
            public static explicit operator B(A a)
            {
                return new B();
            }
        }

        struct B
        {
            static public explicit operator A(B b)
            {
                return new A();
            }
        }
    }
}

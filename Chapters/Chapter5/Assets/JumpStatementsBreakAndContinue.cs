/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 5.9 Arrays A First Look                                   *
 *                                                                   *
 * Copyright © 2018 Alex Okita                                       *
 *                                                                   *
 * This software may be modified and distributed under the terms     *
 * of the MIT license.  See the LICENSE file for details.            *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
namespace Chapter5_9_2
{
    using UnityEngine;
    public class Zombie : MonoBehaviour
    {
        public int HitPoints;
    }
}

namespace Chapter5_9
{
    using Chapter5_5_2_1;
    using Chapter5_5_4;
    using System.Collections;
    using UnityEngine;

    public class JumpStatementsBreakAndContinue : MonoBehaviour
    {
        #region Chapter 5.9.1 Jump Statments: Break and Continue
        /* * * * * * * * * * * * * * * * * * * * * * * * * * * *
         * Section 5.9.1 Jump Statements: Break and Continue  *
         * * * * * * * * * * * * * * * * * * * * * * * * * * * */
        void UseBreakAndContinue()
        {
            // Break stops the for loop short.
            for (int i = 0; i < 100; i++)
            {
                Debug.Log(i);
                if (i > 10)
                {
                    break;
                }
            }

            /* * * * * * * * * * * * * * * *
             * Section 5.9.1.1 Continue   *
             * * * * * * * * * * * * * * * */
            for (int i = 0; i < 100; i++)
            {
                Debug.Log(i);
                if (i > 10)
                {
                    Debug.Log("i is greater than 10!");
                    continue;
                }
            }
        }
        #endregion

        #region Chapter 5.10.2 ZombieData
        /* * * * * * * * * * * * * * * 
         * Section 5.10.2 ZombieData *
         * * * * * * * * * * * * * * */
        
        GameObject[] gameObjects;
        void UseZombieData()
        {
            gameObjects = new GameObject[10];
            for (int i = 0; i < 10; i++)
            {
                //make a game object
                GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);

                //find a random place for it
                Vector3 position = new Vector3();
                position.x = UnityEngine.Random.Range(-10, 10);
                position.z = UnityEngine.Random.Range(-10, 10);
                go.transform.position = position;

                //name it something unique
                go.name = i.ToString();
                if (i % 2 == 0)
                {
                    // pick every other one to be a zombie
                    Zombie z = go.AddComponent(typeof(Zombie)) as Zombie;

                    // assign a random value to the hit points
                    z.hitPoints = UnityEngine.Random.Range(1, 20);
                }

                //add the game object to the array
                gameObjects[i] = go;
            }
            /*
             * Section 5.10.3 Foreach - Again
             * 
             * After creating the zombies, lets
             * look at them.
             */
            foreach (GameObject go in gameObjects)
            {
                Zombie z = (Zombie)go.GetComponent(typeof(Zombie));
                if (z == null)
                {
                    /* if we don't find a zombie skip
                     * the game object and move on to
                     * the next one in the array.
                     */
                    continue;
                }

                if (z.hitPoints > 10)
                {
                    Debug.Log("This has more than 10 hit points: " + z.name);
                    break;
                }
            }
        }
        #endregion

        #region Chapter 5.9.3 ZombieData Continued
        /* * * * * * * * * * * * * * * * * * * * * * * * * * * *
         * Section 5.10.3 ZombieData Continued...              *
         * * * * * * * * * * * * * * * * * * * * * * * * * * * */
        void UseMoreZombieData()
        {
            {
                Player[] players = new Player[] { new Player() };

                foreach (Player p in players)
                {
                    if (p == null)
                    {
                        continue;
                    }

                    if (p != null)
                    {
                        AttackPlayer();
                    }
                }
            }
            {
                ArrayList players = new ArrayList();

                foreach (GameObject go in gameObjects)
                {
                    Player player = go.GetComponent(typeof(Player)) as Player;
                    if (player != null)
                    {
                        players.Add(player);
                        continue;
                    }
                }
            }

            void AttackPlayer()
            {
            }
        }
        #endregion

        void Start()
        {
            /* * * * * * * * * * * * * * * * * * * * * * * * * * * *
             * Section 5.10.1 Jump Statements: Break and Continue  *
             * * * * * * * * * * * * * * * * * * * * * * * * * * * */
            UseBreakAndContinue();

            /* * * * * * * * * * * * * * * * * * * * * * * * * * * *
             * Section 5.10.2 ZombieData                           *
             * * * * * * * * * * * * * * * * * * * * * * * * * * * */
            UseZombieData();

            /* * * * * * * * * * * * * * * * * * * * * * * * * * * *
             * Section 5.10.3 ZombieData Continued...              *
             * * * * * * * * * * * * * * * * * * * * * * * * * * * */
            UseMoreZombieData();
        }
    }
}

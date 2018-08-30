/*
 * Chapter 5.9 Arrays A First Look
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpStatementsBreakAndContinue : MonoBehaviour
{
    //used for section 5.10.2
    GameObject[] gameObjects;

    void Start()
    {
        {
            /*
             * Section 5.10.1 Jump Statements: Break and Continue
             * A Basic Example
             */
            for (int i = 0; i < 100; i++)
            {
                Debug.Log(i);
                if (i > 10)
                {
                    break;
                }
            }
        }
        {
            /*
             * Section 5.10.1.1 Continue
             */
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
        {
            /*
             * Section 5.10.2 ZombieData
             */
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
        {
            /*
             * Section 5.10.3 continued.
             */
            Player[] players = new Player[]{ new Player()};

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
    }
    void AttackPlayer()
    {
    }
}

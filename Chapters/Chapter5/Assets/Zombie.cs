/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 5.5.2.1 A Basic Example                                   *
 *                                                                   *
 * Copyright © 2018 Alex Okita                                       *
 *                                                                   *
 * This software may be modified and distributed under the terms     *
 * of the MIT license.  See the LICENSE file for details.            *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
 
 namespace Chapter5_5_2_1
{
    using Chapter5_5_4;
    using UnityEngine;

    public class Zombie : MonoBehaviour
    {
        public static int numZombies;
        /* remove the static keyword above  *
         * to see a different result        */
        public int hitPoints;
        void Start()
        {
            numZombies++;
            Debug.Log(numZombies);
        }

        public static void CountZombies()
        {
            Debug.Log(numZombies);
        }
        /* Called in Static.cs       *
         * when the KeyCode.A is     *
         * pressed then the above    *
         * will print the number     *
         * of zombies to the console.*/

        /* * * * * * * * * * * * * * * *
         * Section 5.5.4 continued...  *
         * * * * * * * * * * * * * * * */
        public Player player;
        private void Update()
        {
            if (player == null)
            {
                /* Find the player */
                player = FindObjectOfType(typeof(Player)) as Player;
            }

            if (player != null)
            {
                /* make sure that the player
                 * exists before trying to
                 * move to it.
                 */
                MoveToPlayer();
            }
        }

        /* * * * * * * * * * * * * * * *
         * Section 5.5.4 continued...  *
         * * * * * * * * * * * * * * * */
        void MoveToPlayer()
        {
            {
                /* we used this technique
                 * in the MoveToPoint script
                 * in the sample game
                 */
                Vector3 playerPos = player.gameObject.transform.position;
                Vector3 towardPlayer = playerPos - transform.position;
                transform.position = Vector3.Lerp(transform.position, playerPos, Time.deltaTime);
                Quaternion direction = Quaternion.LookRotation(towardPlayer, transform.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, direction, Time.deltaTime * 5f);
            }

            {
                Vector3 direction = (Player.position - transform.position).normalized;
                float distance = (Player.position - transform.position).magnitude;
            }
        }
        /* * * * * * * * * * * * * * * * * * * * * * * *
         * Section 5.7.3 Class is a type continued...  *
         * * * * * * * * * * * * * * * * * * * * * * * */
        private void OnDestroy()
        {
            numZombies--;
        }
    }
}

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 6.17.4 Putting It Together                                *
 *                                                                   *
 * Copyright © 2018 Alex Okita                                       *
 *                                                                   *
 * This software may be modified and distributed under the terms     *
 * of the MIT license.  See the LICENSE file for details.            *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
namespace Chapter6_17
{
    using System.Collections;
    using UnityEngine;

    public class GunTurretLogic : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            {
                /* * * * * * * * * * * * * * * * * * * * * * *
                 * Section 6.17.4 Putting it all together!   *
                 * * * * * * * * * * * * * * * * * * * * * * */
                GameObject[] allObjects = FindObjectsOfType<GameObject>();
                ArrayList zombies = new ArrayList();
                ArrayList humans = new ArrayList();

                // iterate through all game objects and find humans and zombies

                foreach (GameObject go in allObjects)
                {
                    HumanWithStates aHuman = go.GetComponent<HumanWithStates>() as HumanWithStates;
                    ZombieWithStates aZombie = go.GetComponent<ZombieWithStates>() as ZombieWithStates;
                    bool isHuman = aHuman != null;
                    bool isZombie = aZombie != null;
                    {
                        if (isHuman)
                        {
                            humans.Add(go);
                            continue; //added to skip the zombies.Add(go); statement.
                        }
                        if (!isHuman && isZombie)
                        {
                            zombies.Add(go);
                        }
                    }
                }

                GameObject[] theZombies = new GameObject[zombies.Count];
                zombies.CopyTo(theZombies);
                foreach (GameObject z in theZombies)
                {
                    //check distance from zombie to all humans
                    foreach (GameObject h in humans)
                    {
                        float dist = (z.transform.position - h.transform.position).magnitude;
                        float tooCloseToZombie = 1.0f;
                        if (dist < tooCloseToZombie)
                        {
                            zombies.Remove(z);
                        }
                    }
                }

                float closestDistance = Mathf.Infinity;
                GameObject closestTarget = null;
                foreach (GameObject zombie in zombies)
                {
                    float dist = (zombie.transform.position - transform.position).magnitude;
                    if (dist < closestDistance)
                    {
                        closestDistance = dist;
                        closestTarget = zombie;
                    }
                }

                if (closestTarget != null)
                {
                    GunTurretController controller = GetComponent<GunTurretController>();
                    controller.ShootAtTarget(closestTarget);
                    Debug.DrawLine(closestTarget.transform.position, transform.position, Color.red);
                }
            }
        }
    }
}
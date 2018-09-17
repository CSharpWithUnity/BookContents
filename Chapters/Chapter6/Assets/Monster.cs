/*
 * Chapter 6.5 Arrays Revisited
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using UnityEngine;
public class Monster : MonoBehaviour
{
    public int ID;
    public float Spacing = 1.1f;
    void Start()
    {
        Debug.Log("Im Alive!");
        MonsterState = MonsterStates.standing;

        {
            /*
             * Section 6.6.4 What We've Learned
             */
            int number = (int)MonsterState;
            Debug.Log(number);
        }
    }

    /*
     * Section 6.5.3 Type Casting Unity 3D Objects
     */
    void Update()
    {
        float wave = Mathf.Sin(Time.fixedTime + ID);
        transform.position = new Vector3(ID * Spacing, wave, 0);

        {
            /*
             * Section 6.6.2 Combining What We've Learned
             */
            if (MonsterState == MonsterStates.standing)
            {
                Debug.Log("Standing monster is standing...");
            }
            if (MonsterState == MonsterStates.wandering)
            {
                Debug.Log("Wandering monster is wandering...");
            }
            if (MonsterState == MonsterStates.chasing)
            {
                Debug.Log("Chasing monster is chasing...");
            }
            if (MonsterState == MonsterStates.attacking)
            {
                Debug.Log("Attacking monster is attacking...");
            }
        }
    }

    /*
     * Section 6.6.2 Combining What We've Learned
     */
    public enum MonsterStates
    {
        standing,
        wandering,
        chasing,
        attacking
    }
    public MonsterStates MonsterState;
}

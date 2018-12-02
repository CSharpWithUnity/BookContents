/*
 * Chapter 4.10 Shooting A Projectile
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : MonoBehaviour
{
    // projectiles per minute
    public float RateOfFire;
    private float NextTime;
    public GameObject ProjectileObject;
    public GameObject ProjectileStart;
    public AudioClip BlasterShotClip;

    // Use this for initialization
    void Start ()
    {
		
	}

    // convert RPM to tenthsOfSeconds
    float NextShot(float rpm)
    {
        // 600 rounds per minute
        //÷ 60 minute
        //────
        //= 10 rounds per second
        float perSecond = rpm / 60;

        // tents of a second
        // between each round
        //
        //   1 second
        //÷ 10 rounds per second
        //────
        //=0.1 seconds

        float tenths = 1 / perSecond;
        return tenths;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButton(1) && Time.time > NextTime)
        {
            NextTime = Time.time + NextShot(RateOfFire);
            GetComponent<AudioSource>().PlayOneShot(BlasterShotClip);
            Instantiate(ProjectileObject, ProjectileStart.transform.position, ProjectileStart.transform.rotation);
        }
	}
}

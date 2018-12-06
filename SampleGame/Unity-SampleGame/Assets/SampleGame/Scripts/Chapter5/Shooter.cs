using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Chapter5
{
    public class Shooter : Mover
    {
        public GameObject ProjectileObject;
        public GameObject ProjectileStart;
        public AudioClip BlasterShotClip;
        private float NextTime;
        public float RateOfFire;

        protected override void Update()
        {
            base.Update();
            ShootAt();
        }

        // convert RPM to tenthsOfSeconds
        float NextShot(float rpm)
        {
            float perSecond = rpm / 60;
            float tenths = 1 / perSecond;
            return tenths;
        }

        private void ShootAt()
        {
            if (Time.time > NextTime)
            {
                NextTime = Time.time + NextShot(RateOfFire);
                Vector3 pos = ProjectileStart.transform.position;
                Quaternion rot = ProjectileStart.transform.rotation;
                Instantiate(ProjectileObject, pos, rot);
                GetComponent<AudioSource>().PlayOneShot(BlasterShotClip);
            }
        }
    }
}

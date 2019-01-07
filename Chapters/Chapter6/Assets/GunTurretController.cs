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
    using UnityEngine;
    public class GunTurretController : MonoBehaviour
    {
        internal Projectile[] Projectiles;
        public int NumProjectiles = 10;
        public float ProjectileSpeed = 10;
        private int projectileIndex = 0;
        public GameObject ProjectileObject;
        public GameObject Turret;
        public GameObject Launcher;
        public float DelayBetweenShots = 1f;
        private float ShotDelay;
        private bool CanShoot = false;
        private Quaternion targetRotation;
        // Start is called before the first frame update
        void Start()
        {
            Projectiles = new Projectile[NumProjectiles];
            for (int i = 0; i < NumProjectiles; i++)
            {
                Projectiles[i] = new Projectile(ProjectileObject);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (Time.time > ShotDelay)
            {
                CanShoot = true;
                ShotDelay = Time.time + DelayBetweenShots;
            }
            Turret.transform.rotation = Quaternion.RotateTowards(Turret.transform.rotation, targetRotation, Time.deltaTime * 90f);
        }

        internal void ShootAtTarget(GameObject target)
        {
            if (!CanShoot)
                return;
            Vector3 targetVector = new Vector3()
            {
                x = target.transform.position.x,
                y = 0,
                z = target.transform.position.z
            };
            Vector3 lookDirection = targetVector - Turret.transform.position;
            targetRotation = Quaternion.LookRotation(lookDirection, Turret.transform.up);
            CanShoot = false;
            int index = projectileIndex % NumProjectiles;
            Projectile p = Projectiles[index];
            p.SetPosition(Launcher.transform.position + (Launcher.transform.forward * 0.4f));
            Vector3 direction = target.transform.position - p.ProjectileObject.transform.position;
            p.AddVelocity(Turret.transform.forward * ProjectileSpeed);
            projectileIndex++;
        }

        internal class Projectile
        {
            public GameObject ProjectileObject;
            public Projectile(GameObject gameObject)
            {
                ProjectileObject = GameObject.Instantiate(gameObject);
                ProjectileObject.AddComponent<SphereCollider>();
                ProjectileObject.AddComponent<Rigidbody>();
                ProjectileObject.GetComponent<Rigidbody>().isKinematic = true;
                ProjectileObject.SetActive(false);//hide till its needed
            }

            public void SetPosition(Vector3 position)
            {
                ProjectileObject.transform.position = position;
                ProjectileObject.transform.rotation = Quaternion.identity;
            }

            public void AddVelocity(Vector3 velocity)
            {
                ProjectileObject.SetActive(true);
                ProjectileObject.GetComponent<Rigidbody>().isKinematic = false;
                ProjectileObject.GetComponent<Rigidbody>().velocity = velocity;
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    public int Damage;
    // Prefabs to instantiate when a hit is recorded
    public GameObject ExplosionSmall;
    public GameObject ExplosionLarge;

    private void OnCollisionEnter(Collision collision)
    {
        ProjectileShape other = collision.gameObject.GetComponent<ProjectileShape>();
        if (other != null)
        {
            // make the projectile go away.
            Destroy(other.gameObject);
            Vector3 pos = collision.contacts[0].point;
            Vector3 dir = collision.contacts[0].normal;
            Quaternion rot = Quaternion.LookRotation(dir);
            Damage -= other.Damage;
            if (Damage <= 0)
            {
                Instantiate(ExplosionLarge, pos, rot);
                // make this thing go away.
                Destroy(this.gameObject);
            }
            else
            {
                Instantiate(ExplosionSmall, pos, rot);
            }
        }
    }
}

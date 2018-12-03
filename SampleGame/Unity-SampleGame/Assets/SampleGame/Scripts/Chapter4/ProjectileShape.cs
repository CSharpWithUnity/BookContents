using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShape : MonoBehaviour
{
    public float LifeTime;
    public int Damage;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * Speed;

        LifeTime = Time.time + LifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= LifeTime)
        {
            Destroy(this.gameObject);
        }
    }
}

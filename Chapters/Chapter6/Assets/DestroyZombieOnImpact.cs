using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Chapter6_16
{
    public class DestroyZombieOnImpact : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<ZombieWithStates>() != null)
            {
                Destroy(collision.gameObject);
                gameObject.SetActive(false);
            }
        }
    }
}
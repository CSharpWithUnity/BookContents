using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

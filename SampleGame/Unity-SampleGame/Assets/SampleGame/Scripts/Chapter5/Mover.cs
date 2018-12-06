using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Chapter5
{
    public class Mover : MonoBehaviour
    {
        private GameObject _Target;
        private GameObject Target
        {
            get
            {
                if (_Target == null)
                {
                    // find the player, keep
                    // a reference to it.
                    _Target = Player.ThePlayer;
                }
                return _Target;
            }
        }
        
        protected virtual void Update()
        {
            if (Target == null)
                return;
            Vector3 TargetDirection = GetDirection(Target);
            MoveTo(TargetDirection);
            LookAt(TargetDirection);
        }

        private Vector3 GetDirection(GameObject target)
        {
            Vector3 myPosition = transform.position;
            Vector3 otherPosition = target.transform.position;
            return otherPosition - myPosition;
        }

        private void MoveTo(Vector3 targetDirection)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddForce(targetDirection, ForceMode.Force);
        }

        private void LookAt(Vector3 targetDirection)
        {
            Quaternion look = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, look, 15f);
        }


    }
}

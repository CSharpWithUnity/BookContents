using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter5
{
    public class Player : MonoBehaviour
    {
        public static GameObject ThePlayer;

        private void Start()
        {
            ThePlayer = this.gameObject;
        }

        private void Update()
        {

        }
    }
}

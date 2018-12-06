using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter4
{
    public class DirectMousePosition : MonoBehaviour
    {
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            gameObject.transform.position = Input.mousePosition;
        }
    }
}

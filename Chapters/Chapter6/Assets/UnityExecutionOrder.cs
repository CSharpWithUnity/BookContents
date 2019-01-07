/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 6.10.6 Extending Namespaces                               *
 *                                                                   *
 * Copyright © 2018 Alex Okita                                       *
 *                                                                   *
 * This software may be modified and distributed under the terms     *
 * of the MIT license.  See the LICENSE file for details.            *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
namespace Chapter6_10
{
    using UnityEngine;
    public class UnityExecutionOrder : MonoBehaviour
    {
        void Awake()
        {
            Debug.Log("Awake Start");
            this.gameObject.AddComponent(typeof(Second));
            Debug.Log("Awake Done");
        }

    }

    public class Second : MonoBehaviour
    {
        private void Awake()
        {
            Debug.Log("Second Awake Start");
            for (int i = 0; i < 1000; i++)
            {
                Debug.Log("Wait!");
            }
            Debug.Log("Second Awake Done.");
        }

        private void OnEnable()
        {
            Debug.Log("Second Start");
        }
    }
}
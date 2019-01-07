/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 6.12.1 Execution Order                                    *
 *                                                                   *
 * Copyright © 2018 Alex Okita                                       *
 *                                                                   *
 * This software may be modified and distributed under the terms     *
 * of the MIT license.  See the LICENSE file for details.            *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
namespace Chapter6_12
{
    using UnityEngine;
    public class ExecutionOrderThird : MonoBehaviour
    {
        void Awake()
        {
            Debug.Log("Third Awake");
        }

        void OnEnable()
        {
            Debug.Log("Third OnEnable");
        }

        void Start()
        {
            Debug.Log("Third Start");
        }

        void FixedUpdate()
        {
            Debug.Log("Third FixedUpdate");
        }

        void Update()
        {
            Debug.Log("Third Update");
        }

        private void LateUpdate()
        {
            Debug.Log("Third LateUpdate");
            Destroy(this);
        }

        private void OnDisable()
        {
            Debug.Log("Third OnDisable");
        }

        private void OnDestroy()
        {
            Debug.Log("Third OnDistroy");
        }
    }
}
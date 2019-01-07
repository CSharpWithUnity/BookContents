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
    public class ExecutionOrderFirst : MonoBehaviour
    {

        void Awake()
        {
            {
                Debug.Log("First Awake");
            }
            {
                Debug.Log("First Awake Start");
                this.gameObject.AddComponent(typeof(ExecutionOrderSecond));
                Debug.Log("First Awake Done");
            }
        }

        void OnEnable()
        {
            Debug.Log("First OnEnable");
        }

        void Start()
        {
            Debug.Log("First Start");
        }

        void FixedUpdate()
        {
            Debug.Log("First FixedUpdate");
        }

        void Update()
        {
            Debug.Log("First Update");
        }

        private void LateUpdate()
        {
            Debug.Log("First LateUpdate");
            Destroy(this);
        }

        private void OnDisable()
        {
            Debug.Log("First OnDisable");
        }

        private void OnDestroy()
        {
            Debug.Log("First OnDistroy");
        }
    }
}

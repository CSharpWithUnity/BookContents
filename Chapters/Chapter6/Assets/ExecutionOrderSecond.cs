/*
 * Chapter 6.12.1 Execution Order
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

using UnityEngine;

public class ExecutionOrderSecond : MonoBehaviour
{

    void Awake()
    {
        {
            Debug.Log("Second Awake");
            for (int i = 0; i < 1000; i++)
            {
                Debug.Log("Wait!");
            }
            Debug.Log("Second Awake Done");
        }
    }

    void OnEnable()
    {
        Debug.Log("Second OnEnable");
    }

    void Start()
    {
        Debug.Log("Second Start");
    }

    void FixedUpdate()
    {
        Debug.Log("Second FixedUpdate");
    }

    void Update()
    {
        Debug.Log("Second Update");
    }

    private void LateUpdate()
    {
        Debug.Log("Second LateUpdate");
        Destroy(this);
    }

    private void OnDisable()
    {
        Debug.Log("Second OnDisable");
    }

    private void OnDestroy()
    {
        Debug.Log("Second OnDistroy");
    }
}

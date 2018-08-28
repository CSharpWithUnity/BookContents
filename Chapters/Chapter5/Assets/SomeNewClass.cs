/*
 * Chapter 5.2 Review
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using UnityEngine;
using System.Collections;
using System.IO;
using System.Net.Sockets;

public class SomeNewClass : MonoBehaviour
{
    private void Start()
    {
        Debug.Log(MyFunction(7));
        MyLoopFunction(10);
    }

    public int MyFunction(int inPut)
    {
        return inPut;
    }

    public void MyLoopFunction(int loops)
    {
        for (int i = 0; i < loops; i++)
        {
            Debug.Log(i);
        }
    }
}

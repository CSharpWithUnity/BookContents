/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 2.2 Class Construction                                  *
 *                                                                 *
 * Copyright © 2018 Alex Okita                                     *
 *                                                                 *
 * This software may be modified and distributed under the terms   *
 * of the MIT license.  See the LICENSE file for details.          *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using UnityEngine;

public class LineNumbers : MonoBehaviour
{
    public int SomeInt = 1;
    public int OtherInt = 7;

    // Use this for initialization
    void Start()
    {
        // a new line of code appears!
    }

    // Update is called once per frame
    void Update()
    {

    }

    int MyFunction(int a, int b)
    {
        return a + b;
    }
}

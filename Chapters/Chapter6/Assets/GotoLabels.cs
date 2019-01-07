/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 6.16 Goto Labels                                          *
 *                                                                   *
 * Copyright © 2018 Alex Okita                                       *
 *                                                                   *
 * This software may be modified and distributed under the terms     *
 * of the MIT license.  See the LICENSE file for details.            *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
namespace Chapter6_16
{
    using UnityEngine;
    public class GotoLabels : MonoBehaviour
    {
        void Start()
        {
            /* * * * * * * * * * * * * * *
             * Section 6.16 Goto Labels  *
             * * * * * * * * * * * * * * */
            {
                //StartOver:
                //goto StartOver;
                /* Uncomment the two lines above, only if you want to freeze
                 * Unity in an infinite loop when the game starts.
                 * (not recommended.)
                 * 
                 *    ┌─────┐  ┌─────┐
                 *    │Label│  │colon│
                 *    └──┬──┘  └──┬──┘
                 *       └─┐    ┌─┘         ❶ label is initially ignored.
                 *         ↓    ↓          
                 *   ❶ StartOver: ←── ←╮    ❷ executes what might be after the
                 *   ❷-❹...//do things ❸      label as normal.
                 *   ❸ goto StartOver;→╯      
                 *      ↑        ↑          ❸ goto tells C# to go up to StartOver:
                 *      └─┐      └─┐
                 *   ┌────┴───┐ ┌──┴─────┐  ❹ executes what might be after the
                 *   │goto    │ │Label to│    label as normal.
                 *   │keyword │ │go to.  │
                 *   └────────┘ └────────┘  Without an escape condition this repeats
                 *                          forever.
                 */
            }
            {
                int num = 0;

            StartOver:

                num++;
                if (num > 3)
                {
                    goto Stop;
                }

                Debug.Log("Looping: " + num + " times.");
                goto StartOver;

            Stop:

                Debug.Log("Stopped.");
            }
            {
                /*
                 * Section 6.16.1 Skipping down
                 */
                int num = 0;/*  setting this to 1             */
                if (num > 0)/*  will jump our code            */
                {                      /*                     */
                    goto FirstLabel;   /* from here→❶╮         */
                }                                /*  ↓         */
                Debug.Log("Before FirstLabel:"); /*  │ skipped */
            FirstLabel:                      /*  ↓         */
                Debug.Log("After FirstLabel:");  /*←❷╯ to here */
            }
        }
    }
}
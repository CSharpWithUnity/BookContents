/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Chapter 4.12 Loops                                                *
 *                                                                   *
 * Copyright © 2018 Alex Okita                                       *
 *                                                                   *
 * This software may be modified and distributed under the terms     *
 * of the MIT license.  See the LICENSE file for details.            *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
namespace Chapter4_12
{
    using UnityEngine;

    public class Loops : MonoBehaviour
    {
        /* * * * * * * * * * * * * * * * * *
         * Section 4.12.1 Unary Operators  *
         * * * * * * * * * * * * * * * * * */
        public int counter;

        // Update is called once per frame
        void Update()
        {
            #region Chapter 4.12.1 Unary Operators
            /* * * * * * * * * * * * * * * * * *
             * Section 4.12.1 Unary Operators  *
             * * * * * * * * * * * * * * * * * */

            /* int counterPlusOne = counter + 1;
             * counter = counterPlusOne;
             * 
             * The above two lines work, but it's a bit
             * verbose.
             * 
             * counter = counter + 1;
             * 
             * this also work, but still can be shorter.
             * 
             */
            #endregion

            #region Chapter 4.12.2 While
            {
                /* * * * * * * * * * * * *
                 * Section 4.12.2 While  *
                 * * * * * * * * * * * * */

                counter++;
                int i = 0;
                while (i < 10)
                {
                    Debug.Log(i);
                    i++;
                }
                Debug.Log(counter);
            }
            #endregion

            #region Chapter 4.12.3 For
            {
                /* * * * * * * * * * * *
                 * Section 4.12.3 For  *
                 * * * * * * * * * * * */

                /* 
                 * for( initialization ; condition ; operation )
                 * {
                 *     code goes here...
                 * }
                 * 
                 */

                {
                    for (int i = 0; i < 10; i++)
                    {
                        Debug.Log(i);
                    }
                    //Debug.Log(i);

                    /* uncomment the line above to see the error. */
                }
                {
                    int i = 0;
                    //for (int i = 0; i < 10; i++)
                    //{
                    //
                    //}

                    /* The int i = 0; in the                *
                     * initialization of the for loop       *
                     * will cause an error                  *
                     * since i was already declared before  *
                     * the for() loop.                      */
                }
                {
                    int i = 0;
                    for (; i < 10; i++)
                    {
                        Debug.Log(i);
                    }

                    /* We can ignore putting anything   *
                     * in the initialization if i       *
                     * was already declared!            */
                }
                {
                    int i = 0;
                    for (; i < 10;)
                    {
                        Debug.Log(i);
                        i++;
                    }
                    /* Why not just use a While() loop  *
                     * instead?                         */
                }
                {
                    int i = 0;
                    bool loop = true;
                    for (; loop;)
                    {
                        Debug.Log(i);
                        i++;
                        if (i > 10)
                            loop = false;
                    }
                    /* now we're just abusing the for loop */
                }
                {
                    for (float f = 0; f < 10f; f = f + 1.0f)
                    {
                        Debug.Log("float: " + f);
                    }
                }
            }
            #endregion

            {
                #region Chapter 4.12.4 Do While
                /* * * * * * * * * * * * * *
                 * Section 4.12.4 Do While *
                 * * * * * * * * * * * * * */
                {
                    int i = 0;
                    do
                    {
                        Debug.Log("do-while:" + i);
                        i++;
                    } while (i < 10);
                    /* The do{}while(); loop     * 
                     * is the only loop that     *
                     * checks the condition      *
                     * _after_ running the       *
                     * it's code                 *
                     * lua looks like:           *
                     *                           *
                     * for int i = 1, 10 do      *
                     *     print(i)              *
                     * end                       *
                     *                           *
                     * which is fairly suscinct  *
                     * but F# looks like:        *
                     *                           *
                     * for i = 1 to 10 do        *
                     * printfn"%d"i              *
                     *                           *
                     * even shorter!             */
                }
                #endregion

                #region Chapter 4.12.5 Postfix and Prefix notation
                {
                    /* * * * * * * * * * * * * * * * * * * * * * * *
                     * Section 4.12.5 Postfix and Prefix notation  *
                     * * * * * * * * * * * * * * * * * * * * * * * */
                    {
                        int i = 0;
                        Debug.Log(i);       // 0
                        while (i < 1)
                        {
                            Debug.Log(i++); // 0
                            Debug.Log(i);   // 1
                        }

                        // post fix changes i after it's read
                    }
                    /* post fix and prefix unary operators  *
                     * change the order of operation        *
                     * in very subtle ways.                 */
                    {
                        int i = 0;
                        Debug.Log(i);       // 0
                        while (i < 1)
                        {
                            Debug.Log(++i); // 1
                            Debug.Log(i);   // 1
                        }

                        // pre fix changes before i is read
                    }

                    {
                        int i = 0;
                        Debug.Log(i);
                        while (++i < 1)
                        {
                            Debug.Log(i); //unreachable code
                        }
                    }
                    {
                        int i = 0;
                        Debug.Log(i);
                        while (i++ < 1)
                        {
                            Debug.Log(i); // 1
                        }
                    }
                }
                #endregion
            }
        }
    }
}

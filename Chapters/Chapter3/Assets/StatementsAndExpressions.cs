/*
 * Chapter 3.5 StatementsAndExpressions
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

using UnityEngine;

public class StatementsAndExpressions : MonoBehaviour
{
    #region Chapter 3.5.1 Expressions
    private enum Food
    {
        kale,
        broccoli
    }
    Food lunch = Food.kale;
    Food dinner = Food.broccoli;

    /*
     * Section 3.5.1 Expressions
     * 
     * if a food is described properly in C# then you can
     * assign it various values based on different values
     * that food has.
     * ┌───────────────┐  ┌────────────────────────┐
     * │ type of value │  │ identifier for a value │ 
     * └───────┬───────┘  └────────────┬───────────┘
     *         │                       │
     *         └──────┐   ┌────────────┘
     *                ┴   ┴
     *              food Lunch = Kale;
     *                            ┬
     *                 ┌──────────┘
     *    ┌────────────┴────────────────────┐ 
     *    │ value of food assigned to Lunch │
     *    └─────────────────────────────────┘
     *         
     * The assignment can be arbitrary, and food can be
     * written to contain any number of values.
     * 
     * Expressions can also involve processes to assign values.
     * food Dinner = Pasta + Broccoli;
     * 
     */
    #endregion

    #region Chapter 3.5.2 How Unity3D Executes your Code
    /*
     * Section 3.4.2
     * 
     * When this code is attached to a game object in
     * Unity 3D the engine invokes Start() in this
     * class.
     * 
     * The following line of code Invokes the function
     * above.
     * 
     * Running this code int he play-in-editor
     * will send "I've been invoked!" to the console
     */
    void ExpressionToInvoke()
    {
        Debug.Log("I've been invoked!");
    }

    void Start()
    {


        ExpressionToInvoke();

        /*
         * the Function identifier is also how the function
         * is called. Without the line above calling on
         * the function, the code encapsulated in the function
         * named will not execute.
         */
    }

    void Update()
    {
        // Gather Data
        float closestDistance = Mathf.Infinity;
        GameObject closestGameObject = null;
        GameObject[] allGameObjects = FindObjectsOfType<GameObject>();

        // Process Data
        foreach(GameObject g in allGameObjects)
        {
            // Gather Data
            bool notMe = g != this.gameObject;
            
            // Process Data
            if (notMe)
            {
                // Gather Data
                Vector3 otherPosition = g.transform.position;
                Vector3 mPosition = transform.position;
                Vector3 difference = otherPosition - mPosition;
                float distance = difference.magnitude;

                // Process Data
                if(distance < closestDistance)
                {
                    closestDistance = distance;
                    closestGameObject = g;
                }
            }
        }

        // Gather Data
        Vector3 myPosition = transform.position;
        Vector3 closestPosition = closestGameObject.transform.position;
        Color red = Color.red;

        // Process Data
        Debug.DrawLine(myPosition, closestPosition , red);
    }
    #endregion

    #region Chapter 3.5.3 Thinking in Algorithms
    /*
     * Section 3.4.3.1
     * 
     * "wash rinse repeat."
     * 
     * while(true)
     * {
     *     wash();
     *     rinse();
     * }
     * 
     * a better version:
     * while(hair == dirty)
     * {
     *     wash();
     *     rinse();
     * }
     * 
     * instructions:
     * bring home bacon
     * if there's milk
     * get three.
     * 
     * items = Bacon * 1;
     * if(milk == available)
     * {
     *     items = Bacon * 3;
     * }
     */
    #endregion
}

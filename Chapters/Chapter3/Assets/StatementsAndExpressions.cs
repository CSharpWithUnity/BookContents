// Chapter 3.4 Statements and Expressions

using UnityEngine;

public class StatementsAndExpressions : MonoBehaviour
{
    private enum Food
    {
        kale,
        broccoli
    }
    Food lunch = Food.kale;
    Food dinner = Food.broccoli;

    /*
     * Section 3.4.1 Expressions
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
        float closestDistance = Mathf.Infinity;
        GameObject closestGameObject = null;
        GameObject[] allGameObjects = (GameObject[])GameObject.FindObjectsOfType(typeof(GameObject));
        foreach(GameObject g in allGameObjects)
        {
            if(g != this.gameObject)
            {
                float distanceToG = (g.transform.position - transform.position).magnitude;
                if(distanceToG < closestDistance)
                {
                    closestDistance = distanceToG;
                    closestGameObject = g;
                }
            }
        }

        Debug.DrawLine(transform.position, closestGameObject.transform.position, Color.red);
    }

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

}

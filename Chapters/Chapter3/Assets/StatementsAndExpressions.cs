using UnityEngine;

public class StatementsAndExpressions : MonoBehaviour
{
    /*
     * Section 3.4.1 Expressions
     * 
     *  ┌───────────────┐  ┌────────────────────────┐
     *  │ type of value │  │ identifier for a value │ 
     *  └───────┬───────┘  └────────────┬───────────┘
     *          │                       │
     *          └──────┐   ┌────────────┘
     *                 ┴   ┴
     *               Meal Lunch = Kale;
     *                             ┬
     *                  ┌──────────┘
     *     ┌────────────┴────────────────────┐ 
     *     │ Value of Meal assigned to Lunch │
     *     └─────────────────────────────────┘
     *          
     * The assignment can be arbitrary, and Meal can be
     * written to contain any number of values.
     * 
     * Expressions can also involve processes to assign values.
     * Meal Dinner = Pasta + Broccoli;
     * 
     */
    void ExpressionToInvoke()
    {
        Debug.Log("I've been invoked!");
    }

    void Start()
    {
        /*
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

}

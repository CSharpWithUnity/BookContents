/*
 * Chapter 3.10 UsingTheVariables
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

using UnityEngine;

public class UsingTheVariables : MonoBehaviour
{

    #region Chapter 3.11.2 Variable Assignment
    /* * * * * * * * * * * * * * * * * * * *
     * Section 3.11.2 Variable Assignment  *
     * * * * * * * * * * * * * * * * * * * */
    void UseVariableAssignment()
    {
        {
            /* int declares a new thing         */
            /* assignment operator = assigns    */
            /* the new int thing a value        */
            /*        ┌───┐                     */
            /*      ┌─┤ = ├──┐                  */
            /*      ↓ └───┘  ↑                  */
            int MyVariable = 7;
            /*      ↓                           */
            /*      └─────┐                     */
            /*            ↓                     */
            Debug.Log(MyVariable);
            /* Debug.Log prints to the console  */
            /* what is in it's argument list () */
            // 7
            /*   ┌───────┐ MyVariable           */
            /*   ↓       ↑ gets a new value     */
            MyVariable = 13;
            Debug.Log(MyVariable);
            // 13
            /* the new value is printed         */

            MyVariable = 3;
            Debug.Log(MyVariable);
            // 3
            MyVariable = 73;
            Debug.Log(MyVariable);
            // 73
        }
        {
            int MyVariable = 7;
            /* terms are               then the */
            /* evaluated   ① ( 7 + 7 ) result is*/
            /* first       ②=( 14 )    printed  */
            Debug.Log(MyVariable + MyVariable);
            // 14          ③ 14 appears in the console
            /* this is functionally the same as */
            Debug.Log(7 + 7);/* this            */
                             // 14
        }

        {
            int MyVariable = 7;
            int MyOtherVariable = 3;

            /*  terms are    ( 7 * 3 )          */
            Debug.Log(MyVariable * MyOtherVariable);
            // 21
            /* the same as   ( 7 * 3)           */
            Debug.Log(MyVariable * 3);
            // 21
        }
        {
            int MyVariable = 7;
            int MyOtherVariable = 3;
            Debug.Log(MyVariable * MyOtherVariable);
            // 21
            /*   ┌──←=(3)┐ MyVariable           */
            /*   ↓       ↑ gets a new value     */
            MyVariable = MyOtherVariable;

            /*  terms are    ( 3 * 3 )          */
            Debug.Log(MyVariable * MyOtherVariable);
            // 9
        }
    }
    #endregion

    #region Chapter 3.11.3 Using The Variables
    /* * * * * * * * * * * * * * * * * * * * *
     * Section 3.11.3 Using The Variables    *
     * * * * * * * * * * * * * * * * * * * * */

    public float RotationSpeed;
    public float Rotation;
    public float ForwardSpeed;

	// Use this for initialization
	void Start ()
    {
        UseVariableAssignment();
	}

	// Update is called once per frame
	void Update ()
    {
        /* * * * * * * * * * * * * * * * * * * * * * * * * * *
         * Section 3.11.3 Using The Variables Continued...   *
         * * * * * * * * * * * * * * * * * * * * * * * * * * */

        /* Update the Rotation with RotationSpeed            *
         * multiplied by Time.deltaTime.                     */
        Rotation += RotationSpeed * Time.deltaTime;

        /* now add this to the objects Y rotation            *
         * the second value in the object's local            *
         * euler angles.                                     */
        transform.localEulerAngles = new Vector3(0, Rotation, 0);

        /* the transform.forward value is something provided *
         * by the Unity API.                                 */
        transform.position += transform.forward * (ForwardSpeed * Time.deltaTime);
	}
    #endregion
}

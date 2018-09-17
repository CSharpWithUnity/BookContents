/*
 * Chapter 6.6 Enums
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

using UnityEngine;

public class Enums : MonoBehaviour
{
    /*
     * Section 6.6.1 Using Enums
     */
    public PrimitiveType MyPrimitiveType;
    /*
     * Right Click on PrimitiveType to go to the
     * definition and see what the enum looks like.
     */

    enum YesOrNo
    {
        yes,
        no
    };
    YesOrNo yesOrNoEnum;

    /*
     * Section 6.6.1 Continued...
     */
    public enum MyColors
    {
        red,
        blue,
        green
    };
    // also valid
    // public enum MyColors {red, blue, green };
    public MyColors MyColor;
    GameObject gameObject;
    private void Start()
    {
        {
            /*
             * Section 6.6.1 Using Enums
             */
            if (yesOrNoEnum == YesOrNo.yes)
            {
                Debug.Log("yes");
            }
            bool yesOrNoBool = true;
            if (yesOrNoBool == true)
            {
                Debug.Log("yes");
            }
            int primitiveInt = 0;
            /* 0 = Sphere,
             * 1 = Capsule,
             * 2 = Cylinder,
             * 3 = Cube,
             * 4 = Plane,
             * 5 = Quad
             */
            if (primitiveInt == 0)
            {
                Debug.Log("Sphere");
            }

        }

        {
            /*
             * Section 6.6.1 Continued...
             */
            gameObject = GameObject.CreatePrimitive(MyPrimitiveType);
            MeshRenderer meshRenderer = gameObject.GetComponent(typeof(MeshRenderer)) as MeshRenderer;
            Material material = meshRenderer.material;
            if (MyColor == MyColors.red)
            {
                material.color = Color.red;
            }
            if (MyColor == MyColors.blue)
            {
                material.color = Color.blue;
            }
            if (MyColor == MyColors.green)
            {
                material.color = Color.green;
            }
        }
    }
}

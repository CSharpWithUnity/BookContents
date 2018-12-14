/*
 * Chapter 8.2 Review
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

namespace Chapter8_2
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Review : MonoBehaviour
    {
        void UseHasProperties()
        {
            CanIHasProperties hasProperties = new CanIHasProperties();
            hasProperties.IHasFloat = 5f;
            Debug.Log(hasProperties.IHasFloat);
            // 5
            Debug.Log(hasProperties.IHasHalfFloat);
            // 2.5
            hasProperties.IHasHalfFloat = 9f;
            Debug.Log(hasProperties.IHasFloat);
            // 18
        }
    }

    class CanIHasProperties
    {
        protected float hasFloat;
        public float IHasFloat
        {
            get { return hasFloat; }
            set { hasFloat = value; }
        }
        public float IHasHalfFloat
        {
            get { return hasFloat * 0.5f; }
            set { hasFloat = value * 2; }
        }
    }

}

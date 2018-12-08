/*
 * Chapter 6.7.7 Finite State Machine
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using UnityEngine;

namespace Chapter6_7
{
    public class FiniteStateMachine : MonoBehaviour
    {
        private float ColorTime;
        public enum ColorStates
        {
            Waiting,
            PickingColor,
            ChangingColor,
            ColorChanged
        }
        public ColorStates ColorState;
        private Color MyColor, NextColor;
        private Material MyMaterial;

        // Start is called before the first frame update
        void Start()
        {
            MyMaterial = GetComponent<MeshRenderer>().material;
            ColorTime = Time.time + 1;
        }

        // Update is called once per frame
        void Update()
        {
            switch (ColorState)
            {
                // Hold onto color here for a second
                // then pick a color
                case ColorStates.Waiting:
                    WaitForColor();
                    break;
                // pick a random color, then go to changing color.
                case ColorStates.PickingColor:
                    PickColor();
                    break;
                // allow some time to lerp between colors
                case ColorStates.ChangingColor:
                    ChangeColor();
                    break;
                // finish color change
                case ColorStates.ColorChanged:
                    ColorChanged();
                    break;
                default:
                    break;
            }
        }

        private void WaitForColor()
        {
            if (Time.time > ColorTime)
            {
                ColorState = ColorStates.PickingColor;
                ColorTime = Time.time + 1;
            }
        }

        private void PickColor()
        {
            float r = Random.Range(0f, 1f);
            float b = Random.Range(0f, 1f);
            float g = Random.Range(0f, 1f);
            NextColor = new Color(r, g, b);
            ColorTime = Time.time + 3;
            ColorState = ColorStates.ChangingColor;
        }

        private void ChangeColor()
        {
            MyColor = Color.Lerp(MyColor, NextColor, Time.deltaTime);
            MyMaterial.color = MyColor;
            if (Time.time > ColorTime)
            {
                ColorState = ColorStates.ColorChanged;
            }
        }

        private void ColorChanged()
        {
            ColorTime = Time.time + 1;
            ColorState = ColorStates.Waiting;
        }
    }
}

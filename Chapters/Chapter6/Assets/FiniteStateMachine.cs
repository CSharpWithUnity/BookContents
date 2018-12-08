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
        public enum ChangingStates
        {
            Waiting,
            PickingColor,
            ChangingColor,
            ColorChanged
        }
        public ChangingStates MyState;

        private float ColorTime;
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
            switch (MyState)
            {
                // Hold onto color here for a second
                // then pick a color
                case ChangingStates.Waiting:
                    WaitForColor();
                    if (Time.time > ColorTime)
                    {
                        Debug.Log("Finished Waiting...");
                        MyState = ChangingStates.PickingColor;
                    }
                    break;
                // pick a random color, then go to changing color.
                case ChangingStates.PickingColor:
                    PickColor();
                    Debug.Log("Color Picked...");
                    MyState = ChangingStates.ChangingColor;
                    break;
                // allow some time to lerp between colors
                case ChangingStates.ChangingColor:
                    ChangeColor();
                    if (Time.time > ColorTime)
                    {
                        Debug.Log("Color Changed...");
                        MyState = ChangingStates.ColorChanged;
                    }
                    break;
                // finish color change
                case ChangingStates.ColorChanged:
                    ColorChanged();
                    Debug.Log("Finished Color Change.");
                    MyState = ChangingStates.Waiting;
                    break;
                default:
                    break;
            }
        }

        private void WaitForColor()
        {
            // chill out here.
        }

        private void PickColor()
        {
            float r = Random.Range(0f, 1f);
            float b = Random.Range(0f, 1f);
            float g = Random.Range(0f, 1f);
            NextColor = new Color(r, g, b);
            ColorTime = Time.time + 3;
        }

        private void ChangeColor()
        {
            MyColor = Color.Lerp(MyColor, NextColor, Time.deltaTime);
            MyMaterial.color = MyColor;
        }

        private void ColorChanged()
        {
            ColorTime = Time.time + 1;
        }
    }
}

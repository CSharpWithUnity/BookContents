/*
 * Chapter 7.16 Extension Functions
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

/*
 * Section 7.16.1 Extensions
 */

//public class MyGameObject : GameObject
//{
//}
/* uncomment the class above to see the error */

namespace Extensions
{
    using UnityEngine;
    using Tricks;

    public class ExtensionFunctions : MonoBehaviour
    {
        void Start()
        {
            GameObjectExtensions.UseNewTrick();  // All this magic 
            GameObjectExtensions.UseSetParent(); // happens down below.
            GameObjectExtensions.UseMirror();
        }
    }
}

namespace Tricks
{
    using System.Collections;
    using UnityEngine;
    public static class GameObjectExtensions
    {

        /*
         * Section 7.16.2 A Basic Example
         */
     
        public static void NewTrick(this GameObject gameObject)
        {   /*               ┌─────────────────────────┐ ↓   */
            /*             ┌─┤reference this gameObject├─┘   */
            /*             ↓ └─────────────────────────┘     */
            Debug.Log(gameObject.name + " has a new trick!");
        }

        public static void Move(this GameObject gameObject, Vector3 position)
        {
            gameObject.transform.position = position;
        }

        public static void Reset(this Transform transform)
        {
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
            transform.localScale = Vector3.one;
        }

        public static void Reset(this GameObject gameObject)
        {
            gameObject.transform.position = Vector3.zero;
            gameObject.transform.rotation = Quaternion.identity;
            gameObject.transform.localScale = Vector3.one;
        }

        public static void UseNewTrick()
        {
            GameObject go = new GameObject("Penn");
            go.NewTrick();
            // Penn has a new trick!

            go.Move(new Vector3(0, 1, 0));
            // changes position to 0, 1, 0

            go.transform.Reset();
        }

        /*
         * Section 7.16.3 A Basic Example
         */
        public static void SetParent(this Transform child, Transform parent, bool resetToWorldPosition = true)
        {
            child.SetParent(parent);
            if (resetToWorldPosition)
            {
                child.Reset();
            }
        }
        
        public static void UseSetParent()
        {
            GameObject go = new GameObject("Child");
            Debug.Log(go.transform.localPosition);
            // (0.0, 0.0, 0.0)
            go.transform.position = Vector3.one;
            Debug.Log(go.transform.localPosition);
            // (1.0, 1.0, 1.0)
            GameObject parent = new GameObject("Parent");
            parent.transform.position = new Vector3(0,0,1);
            
            go.transform.SetParent(parent.transform, resetToWorldPosition: true);
            Debug.Log(go.transform.localPosition);
            // (0.0, 0.0, -1.0)

            //go.transform.SetParent(parent.transform, true);
            //Debug.Log(go.transform.localPosition);
            // (1.0, 1.0, 0.0)
        }

        /*
         * Section 7.16.4 Magic Mirror
         */

        public static void UseMirror()
        {
            GameObject original = GameObject.Instantiate(Resources.Load<GameObject>("TransformPrimitive"));
            original.Mirror(new Vector3(-1, 1, 1));
        }

        public static GameObject Mirror(this GameObject original, Vector3 reflection)
        {
            GameObject mirror = GameObject.Instantiate(original, original.transform.position, original.transform.rotation);
            Vector3 reflected = new Vector3()
            {
                x = original.transform.localScale.x * reflection.x,
                y = original.transform.localScale.y * reflection.y,
                z = original.transform.localScale.z * reflection.z
            };
            mirror.transform.localScale = reflected;
            mirror.name = original.name + "_Mirrored";
            UpdateReflection reflector = new UpdateReflection(original, mirror, reflection);
            return mirror;
        }

        public class UpdateReflection
        {
            GameObject Mirror;
            Vector3 Reflection;

            public UpdateReflection(GameObject original, GameObject mirror, Vector3 reflection)
            {
                UpdatesReflected reflector = original.AddComponent<UpdatesReflected>();
                reflector.ReflectionUpdateEvent += OnReflectionUpdated;
                Mirror = mirror;
                Reflection = reflection;
            }

            public void OnReflectionUpdated(Transform t)
            {
                // update the mirrored position
                Vector3 reflectedPosition = new Vector3()
                {
                    x = t.position.x * Reflection.x,
                    y = t.position.y * Reflection.y,
                    z = t.position.z * Reflection.z
                };
                Mirror.transform.position = reflectedPosition;

                // now update the mirrored rotation
                Vector3 reflectedRotation = new Vector3()
                {
                    x = t.localEulerAngles.x * -Reflection.x,
                    y = t.localEulerAngles.y * -Reflection.y,
                    z = t.localEulerAngles.z * -Reflection.z
                };
                Mirror.transform.localEulerAngles = reflectedRotation;
            }
        }

        public class UpdatesReflected : MonoBehaviour
        {
            public delegate void UpdateReflected(Transform transform);
            public event UpdateReflected ReflectionUpdateEvent;
            private void Update()
            {
                ReflectionUpdateEvent?.Invoke(transform);
            }
        }
    }
}

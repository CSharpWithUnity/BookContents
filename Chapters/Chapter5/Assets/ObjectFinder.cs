using UnityEngine;

public class ObjectFinder : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Object[] objects = FindObjectsOfType(typeof(Object));
        foreach (Object o in objects)
        {
            //Debug.Log(o);
            /*
             * uncomment the line above to see all objects
             */

            ObjectParent parent = o as ObjectParent;
            if (parent != null)
            {
                Debug.Log("FoundParent:" + parent);
            }
        }

        /*
         * Section 5.3.4.1 A Type is not an Object
         */

        //FindObjectsOfType(Object);
        
        /*
         * Uncomment the line above to see the error.
         */
        
	}

    /*
     * Section 5.3.5 != null
     */
    public GameObject foundObject;
    /*
     * We'll assign the foundObject when
     * we find a ChildObject script on
     * a GameObject
     */
	
    // Update is called once per frame
	void Update ()
    {
        if (foundObject == null)
        {
            Object[] objects = FindObjectsOfType(typeof(GameObject));
            // a list of all game objects in the scene

            foreach (GameObject o in objects)
            {
                Debug.Log(o);
                ObjectChild child = o.GetComponent(typeof(ObjectChild)) as ObjectChild;
                if (child != null)
                {
                    foundObject = o;
                }
            }
        }
	}
}

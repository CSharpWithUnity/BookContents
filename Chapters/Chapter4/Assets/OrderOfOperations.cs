using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderOfOperations : MonoBehaviour
{
	void Start ()
    {
        /*
         * Section 4.7 Order of Operation: What is calculated and When
         */

        int a = 1;
        Debug.Log(a); // 1
        a = a + 3;
        Debug.Log(a); // 4
        a = a * 7;
        Debug.Log(a); // 28

        int b = 1 + 3 * 7;
        Debug.Log(b); // 22

        /*
         * Section 4.7.1.1 Math
         */

        Debug.Log(10 / 3);
        Debug.Log(10f / 3f);
        Debug.Log(10.0 / 3.0);
        Debug.Log(10000000.0f / 3.0f);
        Debug.Log(1000000000000000.0 / 3.0);

        /*
         * Section 4.7.1.2 Operator Evaluation
         */

        int c = (1 + 3) * 7;
        Debug.Log(c);

        int d = 1 + 3 * 7 + 9;
        Debug.Log(d);

        int e = 1 + 3 * (7 + 9);
        Debug.Log(e);

        int f = (11 * ((9 * 3) * 2));
        Debug.Log(f);

        int g = ((((11 * ((9 * 3) * 2)))));
        Debug.Log(g);

        int h = 9 * 3;
        int i = h * 2;
        int j = i * 11;
        Debug.Log(j);
    }

    // Update is called once per frame
    int mod = 1;
	void Update ()
    {
        /*
         * Section 4.7.1.1 Math Continued...
         */
        int mod12 = mod % 12;
        Debug.Log(mod + " mod 12 = " + mod12);
        mod++;
	}


}

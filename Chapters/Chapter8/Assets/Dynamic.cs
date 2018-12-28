using System;
using System.Collections.Generic;
using UnityEngine;

public class Dynamic : MonoBehaviour
{
    #region Chapter 8.7 Dynamic
    /*
     * Section 8.7 Dynamic
     */
    void UseDynamic()
    {
        dynamic d = "im a string";
        Debug.Log(d.GetType());
        // System.String

        d = 1;
        Debug.Log(d.GetType());
        // System.Int32

        d = (Action)(() => { });
        Debug.Log(d.GetType());
        // System.Action

        d = 1;
        d++;
        Debug.Log(d.GetType() + " " + d);
        // System.Int32 2

        d = d / Mathf.PI;
        Debug.Log(d.GetType() + " " + d);
        // System.Single 0.6366197

        /* in Visual Studio we don't get an error       */
        /* only when you run the game, will an error    */
        /* be produced!                                 */
        d = 1;
        d = "im a string again!";
        //d++;
        // Uncomment the line above to see the error below.
        // RuntimeBinderException:
        // Operator '++' cannot be applied to operand of type 'string'

    }
    #endregion

    #region Chapter 8.7.1 ExpandoObject
    /*
     * Section 8.7.1 Dynamic
     */
    void UseExpandoObject()
    {
        dynamic expando = new System.Dynamic.ExpandoObject();
        expando.thing = "im a thing";
        expando.dodad = 1;
        expando.widget = 1.0f;
        expando.gizmo = (Action)(()=>{ Debug.Log(expando.thing);});

        Debug.Log(expando.thing.GetType() + " " + expando.thing);
        // System.String im a thing
        Debug.Log(expando.dodad.GetType() + " " + expando.dodad);
        // System.Int32 1
        Debug.Log(expando.widget.GetType() + " " + expando.widget);
        // System.Single 1
        expando.gizmo();
        // im a thing
    }
    #endregion

    #region Chapter 8.7.2 Expando Reader
    /*
     * Section 8.7.2 Expando Reader
     */
    void UseExpandoReader()
    {
        /* some data in string format */
        string data = "" +
            "Name:Rob\n" +
            "HP:10\n" +
            "Position:1.23,4.56,7.89";

        dynamic expando = new System.Dynamic.ExpandoObject();
        // convert expando to a dictionary!
        var expandoAsDictionary = (IDictionary<string, object>)expando;

        var parts = data.Split('\n');
        foreach(string part in parts)
        {
            var pair = part.Split(':');
            // ExpandoObject doesn't have Add
            // but Dictionary does!
            expandoAsDictionary.Add(pair[0], pair[1]);
        }

        expando = expandoAsDictionary;
        Debug.Log(expando.Name + ":" + expando.Name.GetType());
        // Rob:System.String

        expando.HP = int.Parse(expando.HP);
        Debug.Log(expando.HP + ":" + expando.HP.GetType());
        // Rob:System.Int32

        Vector3 toVector3(string s)
        {
            var v = s.Split(',');
            return new Vector3()
            {
                x = System.Single.Parse(v[0]),
                y = System.Single.Parse(v[1]),
                z = System.Single.Parse(v[2])
            };
        }
        expando.Position = toVector3(expando.Position);
        Debug.Log(expando.Position + ":" + expando.Position.GetType());
        // (1.2, 4.6, 7.9):UnityEngine.Vector3

        expando.Transform.Position = expando.Position;
        expando.Transform.Rotation = Quaternion.identity;
        expando.Transform.Scale = Vector3.one;
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        /*
         * Section 8.7 Dynamic
         */
        //UseDynamic();

        /*
         * Section 8.7.1 ExpandoObject
         */
        //UseExpandoObject();

        /*
         * Section 8.7.2 Expando Reader
         */
        UseExpandoReader();
    }
}

/*
 * Chapter 8.11 Attributes
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;
using System.Linq;

public class Attributes : MonoBehaviour
{
    /*
     * Section 8.11 Attributes
     * Serializable makes a data
     * structure into something that
     * can be saved.
     * 
     * This includes the Unity Editor!
     */

    /* Serializable attribute will
     * reveal the DataParameters to
     * the Inspector panel in the Editor.
     */
    [Serializable]
    public class DataParameters
    {
        public int Players;
        public int MinRange, MaxRange;
    }

    public DataParameters ParameterData;

    [NonSerialized]
    public int PlainOldInt;

    [Serializable]
    class CharacterData
    {
        public string Name;
        public int HitPoints;
        public int Defense;
        public int Offsense;
    }

    class GameData
    {
        public CharacterData[] Characters;
        public string Town;
        public int players;
        private int GameID;
    }

    void UseSerializedFields()
    {
        // make some data
        GameData data = new GameData();
        data.players = ParameterData.Players;
        data.Characters = new CharacterData[data.players];
        data.Town = "Someville";
        for (int i = 0; i < data.players; i++)
        {
            data.Characters[i] = new CharacterData();
            // give the character some random name.
            string[] nameParts = { "La", "Da", "Fa", "Ma" };
            for (int j = 0; j < 2; j++)
            {
                data.Characters[i].Name += nameParts[UnityEngine.Random.Range(0, 4)];
            }
            // populate the rest of the player's data with random values
            int min = ParameterData.MinRange;
            int max = ParameterData.MaxRange;
            data.Characters[i].HitPoints = UnityEngine.Random.Range(min, max);
            data.Characters[i].Defense = UnityEngine.Random.Range(min, max);
            data.Characters[i].Offsense = UnityEngine.Random.Range(min, max);
        }

        // store the data to file!
        string path = Directory.GetCurrentDirectory() + "/Data.json";
        string text = JsonUtility.ToJson(data);
        Debug.Log(text);
        File.WriteAllText(path, text);

        // to read the file back again
        GameData ReadData(string dataPath)
        {
            string dataText = File.ReadAllText(path);
            return JsonUtility.FromJson<GameData>(dataText);
        }

        data = ReadData(path);
    }

    /*
     * Section 8.11.2 Custom Attributes
     */

    [AttributeUsage(AttributeTargets.All)]
    class CustomAttribute : Attribute
    {
        public string customString = "A Custom Attribute";
    }

    [CustomAttribute]
    class Something
    {
    }

    void UseCustomAttribute()
    {
        // using Reflection, get the custom attributes of the
        // Something class.
        var memberInfos = typeof(Something).GetCustomAttributes(true);
        foreach (var i in memberInfos)
        {
            CustomAttribute custom = i as CustomAttribute;
            Debug.Log(custom.customString);
        }
        // A Custom Attribute
    }

    /*
     * 8.11.2.1 Custom Attributes for Default Values
     */
    [AttributeUsage(AttributeTargets.Field)]
    class DefaultValue : Attribute
    {
        public object Value;
        public string Name;
        public DefaultValue(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }

    class Character
    {
        [DefaultValue("Health", 10)]
        public int HP;
        [DefaultValue("Magic", 10)]
        public int MP;
        // excluded from default settings
        public int XP;
        public float Time;
    }

    void UseDefaultAttribute()
    {
        Character character = new Character();

        var fields = typeof(Character).GetFields();
        foreach (var f in fields)
        {
            DefaultValue d = f.GetCustomAttribute(typeof(DefaultValue)) as DefaultValue;
            if (d != null)
            {
                f.SetValue(character, d.Value);
            }
        }
        Debug.Log("character.HP " + character.HP);
        // character.HP 10
        Debug.Log("character.MP " + character.MP);
        // character.MP 10
        Debug.Log("character.XP " + character.XP);
        // character.XP 0
        Debug.Log("character.Time " + character.Time);
        // character.Time 0
    }

    /*
     * Section 8.11.4 Multiple Attributes
     */
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
    class SpecialAttribute : Attribute
    {
    }
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
    class SuperficialAttribute : Attribute                    /* this keeps the tag from  */
    {                                                         /* being inherited by child */
    }                                                         /* classes                  */
    
    /* Multiple attributes
     * can be added separated by
     * a comma. Also note that
     * these are actually SpecialAttribute
     * and SuperficialAttribute, but
     * the "Attribute" has been trimmed.
     */
    [Special, Superficial]
    class BaseThing
    {
    }

    class SuperThing : BaseThing
    {
    }

    void UseMultipleAttributes()
    {
        {
            Debug.Log("BaseThing's Attributes:");
            var attribs = typeof(BaseThing).GetCustomAttributes(true);
            foreach (var attrib in attribs)
            {
                Debug.Log(attrib);
            }
            // BaseThing's Attributes:
            // Attributes+SpecialAttribute
            // Attributes+SuperficialAttribute
        }
        {
            Debug.Log("SuperThing's Attributes:");
            var attribs = typeof(SuperThing).GetCustomAttributes(true);
            foreach (var attrib in attribs)
            {
                Debug.Log(attrib);
            }
            // SuperThing's Attributes:
            // Attributes+SpecialAttribute
        }
    }

    /*
     * Section 8.11.5 Putting Attributes to Work
     */
    [AttributeUsage(AttributeTargets.Method |
                    AttributeTargets.Event  |
                    AttributeTargets.Delegate,
                    AllowMultiple = true,
                    Inherited = true)]
    class UpdateAttribute : Attribute
    {
        public float Delay;
        public UpdateAttribute(float delay)
        {
            Delay = delay;
        }
    }

    class HasUpdates
    {
        // updates every half a second
        [Update(0.5f)]
        public void RequiresUpdateOften()
        {
            Debug.Log("Got Updated");
        }
        // updates every three seconds
        [Update(3f)]
        public void AlsoRequiresUpdateSlowly()
        {
            Debug.Log("Also Got Updated");
        }

        // doesn't get updated.
        public void DontUpdate()
        {
            Debug.Log("Exclude me.");
        }
    }

    void UseUpdateAttribute()
    {
        // this class has methods 
        // that need updating.
        HasUpdates needsUpdates = new HasUpdates();

        // now we know what method has the attribute
        // in the class type
        var updateMethods = from m in needsUpdates.GetType().GetMethods()
                            where m.GetCustomAttribute<UpdateAttribute>() is UpdateAttribute
                            select m;

        /* hold onto the coroutines incase
         * we want to kill them later.
         */
        List<IEnumerator> routineList = new List<IEnumerator>();

        // has methods with update attribute
        foreach (var method in updateMethods)
        {
            /* inner function for each
             * method with custom attribute
             * inner function can pretty much
             * appear anywhere.
             */
            IEnumerator updater()
            {
                while (true)
                {
                    UpdateAttribute upa = method.GetCustomAttribute<UpdateAttribute>() as UpdateAttribute;
                    method.Invoke(needsUpdates, new object[] { });
                    yield return new WaitForSeconds(upa.Delay);
                }
            }
            routineList.Add(updater());
        }

        foreach (IEnumerator e in routineList)
        {
            StartCoroutine(e);
        }
    }

    void Start()
    {
        /*
         * Section 8.11 Attributes
         */
        UseSerializedFields();

        /*
         * Section 8.11.2 Custom Attributes
         */
        UseCustomAttribute();

        /*
         * Section 8.11.3 Custom Attributes for Default Values
         */
        UseDefaultAttribute();

        /*
         * Section 8.11.4 Multiple Attributes
         */
        UseMultipleAttributes();

        /*
         * Section 8.11.5 Putting Attributes to Work
         */
        UseUpdateAttribute();
    }
}

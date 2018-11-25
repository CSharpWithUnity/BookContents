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
using UnityEngine;

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
        data.players = 3;
        data.Characters = new CharacterData[data.players];
        data.Town = "Someville";
        for (int i = 0; i < data.players; i++)
        {
            data.Characters[i] = new CharacterData();
            string[] nameParts = { "La", "Da", "Fa", "Ma" };
            for (int j = 0; j < 2; j++)
            {
                data.Characters[i].Name += nameParts[UnityEngine.Random.Range(0, 4)];
            }
            data.Characters[i].HitPoints = UnityEngine.Random.Range(1, 10);
            data.Characters[i].Defense   = UnityEngine.Random.Range(1, 10);
            data.Characters[i].Offsense  = UnityEngine.Random.Range(1, 10);
        }

        // store the data to file!
        string path = Directory.GetCurrentDirectory() + "/Data.json";
        string text = JsonUtility.ToJson(data);
        Debug.Log(text);
        File.WriteAllText(path, text);
    }

    void Start()
    {
        /*
         * Section 8.11 Attributes
         */
    UseSerializedFields();
    }
}

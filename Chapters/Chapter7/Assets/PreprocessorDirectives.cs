/*
 * Chapter 7.11 Preprocessor Directives
 *
 * Copyright © 2018 Alex Okita
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 */

/*
 * Section 7.11 Preprocessor Directives
 */
#define   TESTING
/* ↑          ↑          */
/*┌┴────────┐┌┴────────┐ */
/*│creates  ││names    │ */
/*│a new    ││the new  │ */
/*│directive││directive│ */
/*└─────────┘└─────────┘ */

#define START_LOW_HEALTH


//#undef UNITY_EDITOR
/* hides the UNITY_EDITOR define from this file */

/* start of Testing Scope       */
#if TESTING
using DOTNET = System.Diagnostics;
#endif
/* end of Testing Scope         */

using UnityEngine;
using System.IO;

public class PreprocessorDirectives : MonoBehaviour
{
    /*
     * Section 7.11.1 Preprocessor Directives : A Basic Example
     */
    void UseDOTNET()
    {
        Debug.Log("UNITY DEBUG TEST");
#if TESTING
        DOTNET.Debug.WriteLine("DOT NET TEST");
#endif

#if !TESTING
        Debug.Log("Not using TESTING");
#endif
    }

    /*
     * Section 7.11.2 UNITY_EDITOR
     */
    /* define not allowed in body of   */
    /* the class                       */
//#define START_LOW_HEALTH
    /* uncomment line above to see the error */

    void EditorOnly()
    {
#if UNITY_EDITOR
        Debug.Log("im an only editor message");
#endif
    }

    public int Health = 10;
    void EditorCheats()
    {
#if UNITY_EDITOR && START_LOW_HEALTH
        Health = 1;
#elif UNITY_EDITOR
        Health = 1000;
#endif
    }

    public bool unityEditor = false;
    public bool startLowHealth = false;

    void UsingBools()
    {
        if (unityEditor && startLowHealth)
        {
            Health = 1;
        }
        else if (unityEditor)
        {
            Health = 1000;
        }
    }

    /*
     * Section 7.11.3 Mobile Development
     */
    void WriteToDevice()
    {
#if UNITY_EDITOR
        // something like this doesn't work for Android!?
        string filePath = System.IO.Directory.GetCurrentDirectory();
        filePath += "\\fileData.txt";
        string contents = "Editor File Data.";

        Debug.Log(filePath);
        /* android output from filePath*/
        // /\fileData.txt
        // UnityEngine.DebugLogHandler:Internal_Log(LogType, String, Object)
        // UnityEngine.DebugLogHandler:LogFormat(LogType, Object, String, Object[])
        // UnityEngine.Logger:Log(LogType, Object)
        // UnityEngine.Debug:Log(Object)
        // PreprocessorDirectives: WriteToDevice()
        // PreprocessorDirectives: Start()
#elif UNITY_ANDROID && !UNITY_EDITOR
        // Required or the path looks like "/"
        string filePath = Application.persistentDataPath;
        filePath += "/fileData.txt";
        string contents = "Device File Data.";
#endif
        Debug.Log(filePath);
        StreamWriter writer = new StreamWriter(filePath);
        writer.Write(contents);
        writer.Close();
    }
    /*
     * Section 7.11.4 #Warning
     */
    void UseWarning()
    {
#if UNITY_EDITOR && TESTING
#warning TESTING MODE ACTIVE
#endif
    }
    /*
     * Section 7.11.8 Organizing Code
     */
    #region FirstSection
    void FirstFunctionInFirstSection()
    {
        //Do things here
    }
    void InFirstSection()
    {
        //Do other things here
    }
    #endregion

    void Start()
    {
        UseDOTNET();
        EditorOnly();
        EditorCheats();
        WriteToDevice();
        UseWarning();
    }
}


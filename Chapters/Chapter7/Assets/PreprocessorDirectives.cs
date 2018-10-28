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
    void EditorOnly()
    {
#if UNITY_EDITOR
        Debug.Log("im an only editor message");
#endif

    }
    public int Health;
    /* define not allowed in body of   */
    /* the class                       */
#define START_LOW_HEALTH
    /* uncomment line above to see the error */
    void WriteToDevice()
    {
#if UNITY_EDITOR
        // something like this doesn't work for Android!?
        string filePath = System.IO.Directory.GetCurrentDirectory();
        filePath += "\\fileData.txt";
        string contents = "Editor File Data.";
#if UNITY_ANDROID && !UNITY_EDITOR
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

    void Start()
    {
        UseDOTNET();
        EditorOnly();
        WriteToDevice();
    }
}
